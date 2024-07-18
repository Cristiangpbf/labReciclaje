<?php
include "config.php";
include "utils.php";

$dbConn =  connect($db);

$dbConn->exec("set names utf8");
header('Content-Type: application/json; charset=utf-8');

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    if (isset($_GET['id'])) {
        $sql = $dbConn->prepare("SELECT * FROM objeto WHERE id=:id");
        $sql->bindValue(':id', $_GET['id']);
        $sql->execute();
        echo json_encode($sql->fetch(PDO::FETCH_ASSOC));
        exit();
    } else if (isset($_GET['idCategoria'])) {
        $sql = $dbConn->prepare("SELECT * FROM objeto WHERE idCategoria=:idCategoria");
        $sql->bindValue(':idCategoria', $_GET['idCategoria']);
        $sql->execute();
        $sql->setFetchMode(PDO::FETCH_ASSOC);
        echo json_encode($sql->fetchAll());
        exit();
    } else {
        $sql = $dbConn->prepare("SELECT * FROM objeto");
        $sql->execute();
        $sql->setFetchMode(PDO::FETCH_ASSOC);
        echo json_encode($sql->fetchAll());
        exit();
    }
}