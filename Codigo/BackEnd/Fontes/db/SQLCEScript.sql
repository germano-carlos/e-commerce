


	create table [USUARIO] (
		id_usuario BIGINT NOT NULL IDENTITY(1,1), 
		nome_usuario VARCHAR(255) NOT NULL, 
		data_validade DATETIME NOT NULL, 
		senha_usuario VARCHAR(255) NOT NULL, 
		email VARCHAR(60) NOT NULL, 
		status_usuario ----Undefinedsqltype:Generic---- NOT NULL, 
		TIPOPERMISSAO ----Undefinedsqltype:Generic---- NOT NULL, 
		CONSTRAINT [PK_USUARIO] PRIMARY KEY (
			id_usuario) 
	);

	create table [CATEGORIA] (
		id_categoria INT NOT NULL IDENTITY(1,1), 
		nome VARCHAR(255) NOT NULL, 
		data_inclusao DATETIME NOT NULL, 
		data_alteracao DATETIME NOT NULL, 
		STATUSATIVIDADE INT NOT NULL, 
		CONSTRAINT [PK_CATEGORIA] PRIMARY KEY (
			id_categoria) 
	);

	create table [CLASSIFICACAO_ITEM] (
		id_classificacao INT NOT NULL IDENTITY(1,1), 
		nome VARCHAR(255) NOT NULL, 
		data_inclusao DATETIME NOT NULL, 
		data_alteracao DATETIME NOT NULL, 
		STATUSATIVIDADE INT NOT NULL, 
		CONSTRAINT [PK_CLASSIFICACAO_ITEM] PRIMARY KEY (
			id_classificacao) 
	);

	create table [PRODUTO] (
		id_produto BIGINT NOT NULL IDENTITY(1,1), 
		nome VARCHAR(255) NOT NULL, 
		descricao ----Undefinedsqltype:Text---- NOT NULL, 
		data_insercao DATETIME NOT NULL, 
		data_atualizacao DATETIME NOT NULL, 
		rating NUMERIC(0, 2) NULL, 
		STATUSATIVIDADE INT NOT NULL, 
		id_marca BIGINT NOT NULL, 
		CONSTRAINT [PK_PRODUTO] PRIMARY KEY (
			id_produto) 
	);

	create table [PEDIDO] (
		id_pedido BIGINT NOT NULL IDENTITY(1,1), 
		data_inclusao DATETIME NOT NULL, 
		data_alteracao DATETIME NOT NULL, 
		STATUSPEDIDO ----Undefinedsqltype:Generic---- NOT NULL, 
		id_usuario BIGINT NOT NULL, 
		CONSTRAINT [PK_PEDIDO] PRIMARY KEY (
			id_pedido) 
	);

	create table [ANEXO_IMAGEM] (
		id_anexo INT NOT NULL IDENTITY(1,1), 
		descricao ----Undefinedsqltype:Text---- NOT NULL, 
		id_produto BIGINT NOT NULL, 
		CONSTRAINT [PK_ANEXO_IMAGEM] PRIMARY KEY (
			id_anexo) 
	);

	create table [MARCA] (
		id_marca BIGINT NOT NULL IDENTITY(1,1), 
		nome VARCHAR(255) NOT NULL, 
		logo ----Undefinedsqltype:Text---- NULL, 
		CONSTRAINT [PK_MARCA] PRIMARY KEY (
			id_marca) 
	);

	create table [PRODUTO_OPCAO] (
		id BIGINT NOT NULL IDENTITY(1,1), 
		nome VARCHAR(5) NOT NULL, 
		cor VARCHAR(20) NOT NULL, 
		preco NUMERIC(0, 2) NOT NULL, 
		quantidade INT NOT NULL, 
		id_produto BIGINT NOT NULL, 
		id_opcao BIGINT NOT NULL, 
		CONSTRAINT [PK_PRODUTO_OPCAO] PRIMARY KEY (
			id) 
	);

	create table [OPCAO] (
		id_opcao BIGINT NOT NULL IDENTITY(1,1), 
		nome VARCHAR(0) NOT NULL, 
		STATUSATIVIDADE INT NOT NULL, 
		CONSTRAINT [PK_OPCAO] PRIMARY KEY (
			id_opcao) 
	);

	create table [LOGRADOURO] (
		id_logradouro INT NOT NULL IDENTITY(1,1), 
		rua VARCHAR(0) NOT NULL, 
		bairro VARCHAR(0) NOT NULL, 
		numero VARCHAR(0) NOT NULL, 
		cep VARCHAR(0) NOT NULL, 
		cidade VARCHAR(0) NOT NULL, 
		estado VARCHAR(0) NOT NULL, 
		complemento VARCHAR(0) NOT NULL, 
		uf VARCHAR(2) NOT NULL, 
		apelido VARCHAR(0) NULL, 
		id_usuario BIGINT NULL, 
		CONSTRAINT [PK_LOGRADOURO] PRIMARY KEY (
			id_logradouro) 
	);

	create table [PRODUTO_CATEGORIA] (
		id BIGINT NOT NULL IDENTITY(1,1), 
		id_categoria INT NOT NULL, 
		id_produto BIGINT NOT NULL, 
		CONSTRAINT [PK_PRODUTO_CATEGORIA] PRIMARY KEY (
			id) 
	);

	create table [SUBCATEGORIA] (
		id_subcategoria INT NOT NULL IDENTITY(1,1), 
		nome VARCHAR(255) NOT NULL, 
		data_inclusao DATETIME NOT NULL, 
		data_alteracao DATETIME NOT NULL, 
		STATUSATIVIDADE INT NOT NULL, 
		CONSTRAINT [PK_SUBCATEGORIA] PRIMARY KEY (
			id_subcategoria) 
	);

	create table [CATEGORIA_SUBCATEGORIA] (
		id BIGINT NOT NULL IDENTITY(1,1), 
		id_categoria INT NOT NULL, 
		id_subcategoria INT NOT NULL, 
		CONSTRAINT [PK_CATEGORIA_SUBCATEGORIA] PRIMARY KEY (
			id) 
	);

	create table [SUBCATEGORIA_CLASSIFICACAO] (
		id BIGINT NOT NULL IDENTITY(1,1), 
		id_classificacao INT NOT NULL, 
		id_subcategoria INT NOT NULL, 
		CONSTRAINT [PK_SUBCATEGORIA_CLASSIFICACAO] PRIMARY KEY (
			id) 
	);

	create table [PEDIDO_PRODUTO] (
		id BIGINT NOT NULL IDENTITY(1,1), 
		id_produto BIGINT NOT NULL, 
		id_pedido BIGINT NOT NULL, 
		CONSTRAINT [PK_PEDIDO_PRODUTO] PRIMARY KEY (
			id) 
	);

	create table [TAGS] (
		id_tag BIGINT NOT NULL IDENTITY(1,1), 
		nome VARCHAR(255) NOT NULL, 
		CONSTRAINT [PK_TAGS] PRIMARY KEY (
			id_tag) 
	);

	create table [TAGS_PRODUTO] (
		id_tag_produto BIGINT NOT NULL IDENTITY(1,1), 
		id_tag BIGINT NOT NULL, 
		id_produto BIGINT NOT NULL, 
		CONSTRAINT [PK_TAGS_PRODUTO] PRIMARY KEY (
			id_tag_produto) 
	);

GO

ALTER TABLE [PRODUTO] ADD CONSTRAINT [FK_PRODUTO_MARCA/*Marca*/] FOREIGN KEY ([id_marca]) REFERENCES[MARCA]([id_marca]);
CREATE INDEX IN_PRODUTO_MARCA ON [PRODUTO] ([id_marca]);
ALTER TABLE [PEDIDO] ADD CONSTRAINT [FK_PEDIDO_USUARIO/*Usuario*/] FOREIGN KEY ([id_usuario]) REFERENCES[USUARIO]([id_usuario]);
CREATE INDEX IN_PEDIDO_USUARIO ON [PEDIDO] ([id_usuario]);
ALTER TABLE [ANEXO_IMAGEM] ADD CONSTRAINT [FK_ANEXO_IMAGEM_PRODUTO/*Produto*/] FOREIGN KEY ([id_produto]) REFERENCES[PRODUTO]([id_produto]);
CREATE INDEX IN_ANEXO_IMAGEM_PRODUTO ON [ANEXO_IMAGEM] ([id_produto]);
ALTER TABLE [PRODUTO_OPCAO] ADD CONSTRAINT [FK_PRODUTO_OPCAO_PRODUTO/*Produto*/] FOREIGN KEY ([id_produto]) REFERENCES[PRODUTO]([id_produto]);
CREATE INDEX IN_PRODUTO_OPCAO_PRODUTO ON [PRODUTO_OPCAO] ([id_produto]);
ALTER TABLE [PRODUTO_OPCAO] ADD CONSTRAINT [FK_PRODUTO_OPCAO_OPCAO/*Opcao*/] FOREIGN KEY ([id_opcao]) REFERENCES[OPCAO]([id_opcao]);
CREATE INDEX IN_PRODUTO_OPCAO_OPCAO ON [PRODUTO_OPCAO] ([id_opcao]);
ALTER TABLE [LOGRADOURO] ADD CONSTRAINT [FK_LOGRADOURO_USUARIO/*Usuario*/] FOREIGN KEY ([id_usuario]) REFERENCES[USUARIO]([id_usuario]);
CREATE INDEX IN_LOGRADOURO_USUARIO ON [LOGRADOURO] ([id_usuario]);
ALTER TABLE [PRODUTO_CATEGORIA] ADD CONSTRAINT [FK_PRODUTO_CATEGORIA_CATEGORIA/*Categoria*/] FOREIGN KEY ([id_categoria]) REFERENCES[CATEGORIA]([id_categoria]);
CREATE INDEX IN_PRODUTO_CATEGORIA_CATEGORIA ON [PRODUTO_CATEGORIA] ([id_categoria]);
ALTER TABLE [PRODUTO_CATEGORIA] ADD CONSTRAINT [FK_PRODUTO_CATEGORIA_PRODUTO/*Produto*/] FOREIGN KEY ([id_produto]) REFERENCES[PRODUTO]([id_produto]);
CREATE INDEX IN_PRODUTO_CATEGORIA_PRODUTO ON [PRODUTO_CATEGORIA] ([id_produto]);
ALTER TABLE [CATEGORIA_SUBCATEGORIA] ADD CONSTRAINT [FK_CATEGORIA_SUBCATEGORIA_CATEGORIA/*Categoria*/] FOREIGN KEY ([id_categoria]) REFERENCES[CATEGORIA]([id_categoria]);
CREATE INDEX IN_CATEGORIA_SUBCATEGORIA_CATEGORIA ON [CATEGORIA_SUBCATEGORIA] ([id_categoria]);
ALTER TABLE [CATEGORIA_SUBCATEGORIA] ADD CONSTRAINT [FK_CATEGORIA_SUBCATEGORIA_SUBCATEGORIA/*SubCategoria*/] FOREIGN KEY ([id_subcategoria]) REFERENCES[SUBCATEGORIA]([id_subcategoria]);
CREATE INDEX IN_CATEGORIA_SUBCATEGORIA_SUBCATEGORIA ON [CATEGORIA_SUBCATEGORIA] ([id_subcategoria]);
ALTER TABLE [SUBCATEGORIA_CLASSIFICACAO] ADD CONSTRAINT [FK_SUBCATEGORIA_CLASSIFICACAO_CLASSIFICACAO_ITEM/*ClassificacaoItem*/] FOREIGN KEY ([id_classificacao]) REFERENCES[CLASSIFICACAO_ITEM]([id_classificacao]);
CREATE INDEX IN_SUBCATEGORIA_CLASSIFICACAO_CLASSIFICACAOITEM ON [SUBCATEGORIA_CLASSIFICACAO] ([id_classificacao]);
ALTER TABLE [SUBCATEGORIA_CLASSIFICACAO] ADD CONSTRAINT [FK_SUBCATEGORIA_CLASSIFICACAO_SUBCATEGORIA/*SubCategoria*/] FOREIGN KEY ([id_subcategoria]) REFERENCES[SUBCATEGORIA]([id_subcategoria]);
CREATE INDEX IN_SUBCATEGORIA_CLASSIFICACAO_SUBCATEGORIA ON [SUBCATEGORIA_CLASSIFICACAO] ([id_subcategoria]);
ALTER TABLE [PEDIDO_PRODUTO] ADD CONSTRAINT [FK_PEDIDO_PRODUTO_PRODUTO/*Produto*/] FOREIGN KEY ([id_produto]) REFERENCES[PRODUTO]([id_produto]);
CREATE INDEX IN_PEDIDO_PRODUTO_PRODUTO ON [PEDIDO_PRODUTO] ([id_produto]);
ALTER TABLE [PEDIDO_PRODUTO] ADD CONSTRAINT [FK_PEDIDO_PRODUTO_PEDIDO/*Pedido*/] FOREIGN KEY ([id_pedido]) REFERENCES[PEDIDO]([id_pedido]);
CREATE INDEX IN_PEDIDO_PRODUTO_PEDIDO ON [PEDIDO_PRODUTO] ([id_pedido]);
ALTER TABLE [TAGS_PRODUTO] ADD CONSTRAINT [FK_TAGS_PRODUTO_PRODUTO/*Produto*/] FOREIGN KEY ([id_produto]) REFERENCES[PRODUTO]([id_produto]);
CREATE INDEX IN_TAGS_PRODUTO_PRODUTO ON [TAGS_PRODUTO] ([id_produto]);
ALTER TABLE [TAGS_PRODUTO] ADD CONSTRAINT [FK_TAGS_PRODUTO_TAGS/*Tags*/] FOREIGN KEY ([id_tag]) REFERENCES[TAGS]([id_tag]);
CREATE INDEX IN_TAGS_PRODUTO_TAGS ON [TAGS_PRODUTO] ([id_tag]);

--<#keep(end)#><#/keep(end)#>