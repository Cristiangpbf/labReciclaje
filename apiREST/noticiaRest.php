<?php
include "config.php";
include "utils.php";

$dbConn =  connect($db);

$dbConn->exec("set names utf8");
header('Content-Type: application/json; charset=utf-8');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    if (isset($_GET['id'])) {
        $sql = $dbConn->prepare("SELECT * FROM noticia WHERE id=:id");
        $sql->bindValue(':id', $_GET['id']);
        $sql->execute();
        echo json_encode($sql->fetch(PDO::FETCH_ASSOC));
        exit();
    } else if (isset($_GET['titulo'])) {
        $sql = $dbConn->prepare("SELECT * FROM noticia WHERE titulo=:titulo");
        $sql->bindValue(':titulo', $_GET['titulo']);
        $sql->execute();
        echo json_encode($sql->fetch(PDO::FETCH_ASSOC));
        exit();
    } else {
        $sql = $dbConn->prepare("SELECT * FROM noticia WHERE estado=1");
        $sql->execute();
        $sql->setFetchMode(PDO::FETCH_ASSOC);
        echo json_encode($sql->fetchAll());
        exit();
    }
}

