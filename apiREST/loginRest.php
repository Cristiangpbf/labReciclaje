<?php
include "config.php";
include "utils.php";

$dbConn =  connect($db);
if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    if (isset($_GET['id'])) {
        // Mostrar un usuario por ID
        $sql = $dbConn->prepare("SELECT * FROM usuario WHERE id=:id");
        $sql->bindValue(':id', $_GET['id']);
        $sql->execute();
        echo json_encode($sql->fetch(PDO::FETCH_ASSOC));
        exit();
    } else if (isset($_GET['usuario']) && !isset($_GET['password'])) {
        // Mostrar un usuario por nombre de usuario
        $sql = $dbConn->prepare("SELECT * FROM usuario WHERE usuario=:usuario");
        $sql->bindValue(':usuario', $_GET['usuario']);
        $sql->execute();
        echo json_encode($sql->fetch(PDO::FETCH_ASSOC));
        exit();
    } else if (isset($_GET['usuario']) && isset($_GET['password'])) {
        // Mostrar un usuario por nombre de usuario y contraseÃ±a
        $sql = $dbConn->prepare(
            "SELECT u.id as idUsuario, c.id as idCuenta, u.privilegio, u.usuario, u.estado as estadoUsuario, c.nombres, c.apellidos, c.estado AS estadoCuenta, c.email,c.puntos
             FROM usuario u
             JOIN cuenta c ON u.id = c.idUsuario 
             WHERE u.usuario = :usuario AND u.password = :password"
        );
        $sql->bindValue(':usuario', $_GET['usuario']);
        $sql->bindValue(':password', md5($_GET['password']));
        $sql->execute();
        $usuario = $sql->fetch(PDO::FETCH_ASSOC);
        if ($usuario) {
            $token = bin2hex(random_bytes(16)); 
            $usuario['Token'] = $token;
            echo json_encode($usuario);
        }
        exit();
    } else {
        // Mostrar lista de todos los usuarios
        $sql = $dbConn->prepare("SELECT * FROM usuario");
        $sql->execute();
        $sql->setFetchMode(PDO::FETCH_ASSOC);
        echo json_encode($sql->fetchAll());
        exit();
    }
}
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
  $input = json_decode(file_get_contents('php://input'), true);
  $sql = "INSERT INTO usuario VALUES (0, :usuario, :password, 1,1)";
  $statement = $dbConn->prepare($sql);
  $statement->bindValue(':usuario', $input['usuario']);
  $statement->bindValue(':password', md5($input['password']));
  $statement->execute();

  $postid = $dbConn->lastInsertId();
  if ($postid) {
    $sqlCuenta = "INSERT INTO cuenta VALUES (0, :idUsuario, :nombres, :apellidos, :email, 1,0)";
    $statementCuenta = $dbConn->prepare($sqlCuenta);
    $statementCuenta->bindValue(':idUsuario', $postid);
    $statementCuenta->bindValue(':email', $input['email']);
    $statementCuenta->bindValue(':nombres', $input['nombres']);
    $statementCuenta->bindValue(':apellidos', $input['apellidos']);
    $statementCuenta->execute();
    $postidCuenta = $dbConn->lastInsertId();
    if($postidCuenta){
        $input['id'] = $postid;
        echo json_encode($input);   
    }
    exit();
  }
}

if ($_SERVER['REQUEST_METHOD'] == 'DELETE') {
  $id = $_GET['id'];
  $statement = $dbConn->prepare("DELETE FROM  empleados where id=:id");
  $statement->bindValue(':id', $id);
  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}

if ($_SERVER['REQUEST_METHOD'] == 'PUT') {
  $input = $_GET;
  $postid = $input['idUsuario'];

  if (isset($input['password']) && !empty($input['password'])) {
      $password = $input['password'];

      // Usa par«¡metros para prevenir inyecciones SQL
      $sql = "UPDATE usuario SET password = :password WHERE id = :id";
      $statement = $dbConn->prepare($sql);
      $statement->bindValue(':password', md5($password));
      $statement->bindValue(':id', $postid);
      $statement->execute();
  }

  $email = $input['email'];

  // Usa par«¡metros para prevenir inyecciones SQL
  $sql2 = "UPDATE cuenta SET email = :email WHERE idUsuario = :idUsuario";
  $statement2 = $dbConn->prepare($sql2);
  $statement2->bindValue(':email', $email);
  $statement2->bindValue(':idUsuario', $postid);
  $statement2->execute();

  header("HTTP/1.1 200 OK");
  exit();
}
