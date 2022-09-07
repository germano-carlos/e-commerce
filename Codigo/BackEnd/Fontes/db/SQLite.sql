--DROP TABLE USUARIO;
--DROP TABLE CATEGORIA;
--DROP TABLE CLASSIFICACAO_ITEM;
--DROP TABLE PRODUTO;
--DROP TABLE PEDIDO;
--DROP TABLE ANEXO_IMAGEM;
--DROP TABLE MARCA;
--DROP TABLE PRODUTO_OPCAO;
--DROP TABLE OPCAO;
--DROP TABLE LOGRADOURO;
--DROP TABLE PRODUTO_CATEGORIA;
--DROP TABLE SUBCATEGORIA;
--DROP TABLE CATEGORIA_SUBCATEGORIA;
--DROP TABLE SUBCATEGORIA_CLASSIFICACAO;
--DROP TABLE PEDIDO_PRODUTO;
--DROP TABLE TAGS;
--DROP TABLE TAGS_PRODUTO;
create table if not exists "USUARIO" (
	id_usuario INTEGER NOT NULL AUTOINCREMENT,
	nome_usuario TEXT NOT NULL,
	data_validade DATETIME NOT NULL,
	senha_usuario TEXT NOT NULL,
	email TEXT NOT NULL,
	status_usuario ----Undefinedsqltype:Generic---- NOT NULL,
	TIPOPERMISSAO ----Undefinedsqltype:Generic---- NOT NULL,
	PRIMARY KEY(id_usuario));
create table if not exists "CATEGORIA" (
	id_categoria INTEGER NOT NULL AUTOINCREMENT,
	nome TEXT NOT NULL,
	data_inclusao DATETIME NOT NULL,
	data_alteracao DATETIME NOT NULL,
	STATUSATIVIDADE INTEGER NOT NULL,
	PRIMARY KEY(id_categoria));
create table if not exists "CLASSIFICACAO_ITEM" (
	id_classificacao INTEGER NOT NULL AUTOINCREMENT,
	nome TEXT NOT NULL,
	data_inclusao DATETIME NOT NULL,
	data_alteracao DATETIME NOT NULL,
	STATUSATIVIDADE INTEGER NOT NULL,
	PRIMARY KEY(id_classificacao));
create table if not exists "PRODUTO" (
	id_produto INTEGER NOT NULL AUTOINCREMENT,
	nome TEXT NOT NULL,
	descricao ----Undefinedsqltype:Text---- NOT NULL,
	data_insercao DATETIME NOT NULL,
	data_atualizacao DATETIME NOT NULL,
	rating REAL(0, 2) NULL,
	STATUSATIVIDADE INTEGER NOT NULL,
	id_marca INTEGER NOT NULL,
	PRIMARY KEY(id_produto));
create table if not exists "PEDIDO" (
	id_pedido INTEGER NOT NULL AUTOINCREMENT,
	data_inclusao DATETIME NOT NULL,
	data_alteracao DATETIME NOT NULL,
	STATUSPEDIDO ----Undefinedsqltype:Generic---- NOT NULL,
	id_usuario INTEGER NOT NULL,
	PRIMARY KEY(id_pedido));
create table if not exists "ANEXO_IMAGEM" (
	id_anexo INTEGER NOT NULL AUTOINCREMENT,
	descricao ----Undefinedsqltype:Text---- NOT NULL,
	id_produto INTEGER NOT NULL,
	PRIMARY KEY(id_anexo));
create table if not exists "MARCA" (
	id_marca INTEGER NOT NULL AUTOINCREMENT,
	nome TEXT NOT NULL,
	logo ----Undefinedsqltype:Text---- NULL,
	PRIMARY KEY(id_marca));
create table if not exists "PRODUTO_OPCAO" (
	id INTEGER NOT NULL AUTOINCREMENT,
	nome TEXT NOT NULL,
	cor TEXT NOT NULL,
	preco REAL(0, 2) NOT NULL,
	quantidade INTEGER NOT NULL,
	id_produto INTEGER NOT NULL,
	id_opcao INTEGER NOT NULL,
	PRIMARY KEY(id));
create table if not exists "OPCAO" (
	id_opcao INTEGER NOT NULL AUTOINCREMENT,
	nome TEXT NOT NULL,
	STATUSATIVIDADE INTEGER NOT NULL,
	PRIMARY KEY(id_opcao));
create table if not exists "LOGRADOURO" (
	id_logradouro INTEGER NOT NULL AUTOINCREMENT,
	rua TEXT NOT NULL,
	bairro TEXT NOT NULL,
	numero TEXT NOT NULL,
	cep TEXT NOT NULL,
	cidade TEXT NOT NULL,
	estado TEXT NOT NULL,
	complemento TEXT NOT NULL,
	uf TEXT NOT NULL,
	apelido TEXT NULL,
	id_usuario INTEGER NULL,
	PRIMARY KEY(id_logradouro));
create table if not exists "PRODUTO_CATEGORIA" (
	id INTEGER NOT NULL AUTOINCREMENT,
	id_categoria INTEGER NOT NULL,
	id_produto INTEGER NOT NULL,
	PRIMARY KEY(id));
create table if not exists "SUBCATEGORIA" (
	id_subcategoria INTEGER NOT NULL AUTOINCREMENT,
	nome TEXT NOT NULL,
	data_inclusao DATETIME NOT NULL,
	data_alteracao DATETIME NOT NULL,
	STATUSATIVIDADE INTEGER NOT NULL,
	PRIMARY KEY(id_subcategoria));
create table if not exists "CATEGORIA_SUBCATEGORIA" (
	id INTEGER NOT NULL AUTOINCREMENT,
	id_categoria INTEGER NOT NULL,
	id_subcategoria INTEGER NOT NULL,
	PRIMARY KEY(id));
create table if not exists "SUBCATEGORIA_CLASSIFICACAO" (
	id INTEGER NOT NULL AUTOINCREMENT,
	id_classificacao INTEGER NOT NULL,
	id_subcategoria INTEGER NOT NULL,
	PRIMARY KEY(id));
create table if not exists "PEDIDO_PRODUTO" (
	id INTEGER NOT NULL AUTOINCREMENT,
	id_produto INTEGER NOT NULL,
	id_pedido INTEGER NOT NULL,
	PRIMARY KEY(id));
create table if not exists "TAGS" (
	id_tag INTEGER NOT NULL AUTOINCREMENT,
	nome TEXT NOT NULL,
	PRIMARY KEY(id_tag));
create table if not exists "TAGS_PRODUTO" (
	id_tag_produto INTEGER NOT NULL AUTOINCREMENT,
	id_tag INTEGER NOT NULL,
	id_produto INTEGER NOT NULL,
	PRIMARY KEY(id_tag_produto));

--<#keep(end)#><#/keep(end)#>