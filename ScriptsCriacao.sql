--1-CRIAR BANCO
CREATE DATABASE programacaoDoZero;

--USAR O BANCO
USE programacaoDoZero;

--CRIAR TABELA USUARIO
CREATE TABLE usuario(
   id INT NOT NULL AUTO_INCREMENT,
   nome VARCHAR(40) NOT NULL,
   sobrenome VARCHAR(150) NOT NULL,
   telefone VARCHAR(15) NOT NULL,
   email VARCHAR(50) NOT NULL,
   genero VARCHAR(20) NOT NULL,
   cpf VARCHAR(11) NOT NULL,
   senha VARCHAR(30) NOT NULL,
   PRIMARY KEY (id)

);
--CRIAR TABELA ENDERECO
CREATE TABLE endereco(
id INT NOT NULL auto_increment,
rua VARCHAR(250) NOT NULL,
numero VARCHAR(30) NOT NULL,
bairro VARCHAR(150) NOT NULL,
cidade VARCHAR(150) NOT NULL,
complemento VARCHAR(150) NULL,
cep VARCHAR(10) NOT NULL,
estado VARCHAR(2) NOT NULL,
primary key (id)

--ALTERAR TABELA ENDEREÇO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

--ADICIONAR CHAVE ESTRANGEIRA
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);


--INSERIR USUARIO
INSERT INTO usuario
(nome, sobrenome, cpf, telefone, email, genero, senha)
 VALUES('Guilherme', 'Cunha','233-333-444-32','(51) 99634-8233','guilhermecunha@aulas.com','Masculino','123')
 (nome, sobrenome, telefone, email. genero. cpf. senha)
 VALUES
 ('Guilherme', 'Cunha','(51) 99634-8233','guilhermecunha@aulas.com','Masculino','2334303023','123')
 ('Simone', 'Rosa','(51) 99634-8444','Simonehilario@tia.com','Feminino','2333334443','123')

-- SELECIONAR USUARIOS
SELECT * FROM usuario;

--SELECIONAR USUARIO ESPECIFICO
 SELECT * FROM usuario WHERE email='guilhermecunha@aulas.com';

 --ALTERAR USUARIO
 UPDATE usuario SET email='guilhermecunhaop@aulas.com' WHERE id=1;

 --EXCLUIR USUARIO
DELETE FROM usuario WHERE ID=6 --ou id in(2,3,4) ou id>2