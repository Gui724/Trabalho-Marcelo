create database yeahgames;

use yeahgames;

create table jogo(
	id int primary key auto_increment,
	nome varchar(30),
	categoria varchar(30),
	preco decimal(10,2)
);

select * from jogo