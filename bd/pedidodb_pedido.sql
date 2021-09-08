CREATE TABLE `pedido` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome_produto` varchar(45) NOT NULL,
  `valor` decimal(10,2) NOT NULL,
  `data_vencimento` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb3;
##povoando inicialmente para testes
INSERT INTO pedido VALUES (null,'a',23.14,'2021-12-18 23:01:23'),(null,'b',223.14,'2021-12-18 23:01:23'),(null,'c',223.14,'2021-12-18 23:01:23');
