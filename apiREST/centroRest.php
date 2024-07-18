<?php
include "config.php";
include "utils.php";

$dbConn =  connect($db);

$dbConn->exec("set names utf8");
header('Content-Type: application/json; charset=utf-8');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    if (isset($_GET['id'])) {
        // Mostrar un usuario por ID
        $sql = $dbConn->prepare("SELECT * FROM centro WHERE id=:id");
        $sql->bindValue(':id', $_GET['id']);
        $sql->execute();
        echo json_encode($sql->fetch(PDO::FETCH_ASSOC));
        exit();
    } else if (isset($_GET['usuario'])) {
        // Mostrar un usuario por nombre de centro
        $sql = $dbConn->prepare("SELECT * FROM centro WHERE nombre=:nombre");
        $sql->bindValue(':nombre', $_GET['nombre']);
        $sql->execute();
        echo json_encode($sql->fetch(PDO::FETCH_ASSOC));
        exit();
    } else {
        // Mostrar lista de todos los centro
        $sql = $dbConn->prepare("SELECT * FROM centro WHERE estado=1");
        $sql->execute();
        $sql->setFetchMode(PDO::FETCH_ASSOC);
        echo json_encode($sql->fetchAll());
        exit();
    }
}

/*
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
  $input = json_decode(file_get_contents('php://input'), true);
  $sql = "INSERT INTO usuario VALUES (0, :usuario, :password, 1,1)";
  $statement = $dbConn->prepare($sql);
  $statement->bindValue(':usuario', $input['usuario']);
  $statement->bindValue(':password', md5($input['password']));
  $statement->execute();

  $postid = $dbConn->lastInsertId();
  if ($postid) {
    $sqlCuenta = "INSERT INTO cuenta VALUES (0, :idUsuario, :nombres, :apellidos, :email, 1)";
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

if ($_SERVER['REQUEST_METHOD'] == 'PUT') {
  $input = $_GET;
  $postid = $input['idUsuario'];

  if (isset($input['password']) && !empty($input['password'])) {
      $password = $input['password'];

      // Usa parámetros para prevenir inyecciones SQL
      $sql = "UPDATE usuario SET password = :password WHERE id = :id";
      $statement = $dbConn->prepare($sql);
      $statement->bindValue(':password', md5($password));
      $statement->bindValue(':id', $postid);
      $statement->execute();
  }

  $email = $input['email'];

  // Usa parámetros para prevenir inyecciones SQL
  $sql2 = "UPDATE cuenta SET email = :email WHERE idUsuario = :idUsuario";
  $statement2 = $dbConn->prepare($sql2);
  $statement2->bindValue(':email', $email);
  $statement2->bindValue(':idUsuario', $postid);
  $statement2->execute();

  header("HTTP/1.1 200 OK");
  exit();
}
*/