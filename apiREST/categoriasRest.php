<?php
include "config.php";
include "utils.php";

$dbConn =  connect($db);

$dbConn->exec("set names utf8");
header('Content-Type: application/json; charset=utf-8');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    if (isset($_GET['id'])) {
        // Mostrar un usuario por ID
        $sql = $dbConn->prepare("SELECT * FROM categoria WHERE id=:id");
        $sql->bindValue(':id', $_GET['id']);
        $sql->execute();
        $result = $sql->fetch(PDO::FETCH_ASSOC);
        if ($result !== false) {
            echo json_encode($result, JSON_UNESCAPED_UNICODE);
        }
        exit();
    } else {
        $sql = $dbConn->prepare("SELECT * FROM categoria");
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
  $postid = $input['id'];
  $fields = getParams($input);

  $sql = "
          UPDATE empleados
          SET $fields
          WHERE id='$postid'
           ";

  $statement = $dbConn->prepare($sql);
  bindAllValues($statement, $input);

  $statement->execute();
  header("HTTP/1.1 200 OK");
  exit();
}
