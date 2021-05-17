


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_RegistroLogin')
					DROP TABLE TB_RegistroLogin;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Login')
					DROP TABLE TB_Login;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_NivelAcesso')
					DROP TABLE TB_NivelAcesso;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Estoque')
					DROP TABLE TB_Estoque;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Compra')
					DROP TABLE TB_Compra;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_FichaTecnica')
					DROP TABLE TB_FichaTecnica;
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Perda')
					DROP TABLE TB_Perda;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Insumo')
					DROP TABLE TB_Insumo;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_ItemVenda')
					DROP TABLE TB_ItemVenda;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Venda')
					DROP TABLE TB_Venda;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Cliente')
					DROP TABLE TB_Cliente;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Funcionario')
					DROP TABLE TB_Funcionario;
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_EstoqueDiversos')
					DROP TABLE TB_EstoqueDiversos;
GO


IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_CompraDiversos')
					DROP TABLE TB_CompraDiversos;
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Produto')
					DROP TABLE TB_Produto;
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS
					WHERE NAME='TB_Categoria')
					DROP TABLE TB_Categoria;
GO




CREATE TABLE TB_Funcionario
(
	ID_Funcionario INT PRIMARY KEY IDENTITY(1,1),
	NM_Funcionario VARCHAR(50) NOT NULL,
	DS_Sexo VARCHAR(10),
	DT_Nascimento DATE NOT NULL,
	NR_CPF NUMERIC(11) NOT NULL,
	NR_Telefone NUMERIC(11) NOT NULL,
	DS_Email VARCHAR(50),
	NR_CEP VARCHAR(10),
	NM_Rua VARCHAR(50) NOT NULL,
	NR_Casa VARCHAR(5) NOT NULL,
	NM_Bairro VARCHAR(50) NOT NULL,
	DS_Complemento VARCHAR(50),
	NM_Cidade VARCHAR(30),
	DS_UF VARCHAR(2),
	DS_Cargo VARCHAR(30) NOT NULL,
	VL_Salario DECIMAL(10,2) NOT NULL,
	DT_Admissao DATE NOT NULL,
	DT_Demissao DATE,
    Ativo BIT NOT NULL
);
GO


CREATE TABLE TB_NivelAcesso
(
	ID_NivelAcesso INT PRIMARY KEY IDENTITY(1,1),
	DS_NivelAcesso VARCHAR(10) NOT NULL
);
GO


CREATE TABLE TB_Login
(
	ID_Login INT PRIMARY KEY IDENTITY(1,1),
	ID_Funcionario INT NOT NULL,
	ID_NivelAcesso INT NOT NULL,
	DS_Usuario VARCHAR(20) NOT NULL,
	DS_Senha VARCHAR(20) NOT NULL,
	Ativo BIT NOT NULL,
	FOREIGN KEY (ID_NivelAcesso) REFERENCES TB_NivelAcesso(ID_NivelAcesso),
	FOREIGN KEY (ID_Funcionario) REFERENCES TB_Funcionario(ID_Funcionario)
);
GO


CREATE TABLE TB_Cliente
(
	ID_Cliente INT PRIMARY KEY IDENTITY(1,1),
	NM_Cliente VARCHAR(50) NOT NULL,
    DS_Sexo VARCHAR(10),
	DT_Nascimento DATE NOT NULL,
	NR_CPF NUMERIC(11) NOT NULL,
	NR_Telefone NUMERIC(11) NOT NULL,
	DS_Email VARCHAR(50),
	Ativo BIT NOT NULL
);
GO


CREATE TABLE TB_Insumo
(
	ID_Insumo INT PRIMARY KEY IDENTITY(1,1),
	NM_Insumo VARCHAR(50) NOT NULL,
	DS_TipoArmazenamento VARCHAR(50) NOT NULL,
	PR_Insumo DECIMAL(10,2) NOT NULL,
);
GO


CREATE TABLE TB_Compra
(
	ID_Compra INT IDENTITY(1,1),
	ID_Insumo INT NOT NULL,
	DT_Compra DATE NOT NULL,
	QTDE_InsumoCompra DECIMAL(10,2) NOT NULL,
	PRIMARY KEY (ID_Compra, ID_Insumo),
	FOREIGN KEY (ID_Insumo) REFERENCES TB_Insumo(ID_Insumo) ON DELETE CASCADE

);
GO


CREATE TABLE TB_Estoque
(
	ID_Insumo INT NOT NULL,
	QTDE_Estoque DECIMAL(10,2) NOT NULL,
	PRIMARY KEY (ID_Insumo),
	FOREIGN KEY (ID_Insumo) REFERENCES TB_Insumo(ID_Insumo) ON DELETE CASCADE
);



CREATE TABLE TB_Categoria
(
	ID_Categoria INT PRIMARY KEY IDENTITY(1,1),
	NM_Categoria VARCHAR(50) NOT NULL,
	DS_Categoria VARCHAR(150),
	Ativo BIT NOT NULL
);
GO


CREATE TABLE TB_Produto
(
	ID_Produto INT PRIMARY KEY IDENTITY(1,1),
	ID_Categoria INT NOT NULL,
	NM_Produto VARCHAR(50) NOT NULL,
	PR_Unitario DECIMAL(10,2) NOT NULL,
	PR_Custo DECIMAL(10,2),
	DS_Produto VARCHAR(150) NOT NULL,
	IMG_Produto IMAGE,
	Ativo BIT NOT NULL,
	Diversos BIT NOT NULL
	FOREIGN KEY (ID_Categoria) REFERENCES TB_Categoria(ID_Categoria)
);
GO

CREATE TABLE TB_EstoqueDiversos
(
	ID_Produto INT NOT NULL,
	QTDE_Estoque INT NOT NULL,
	PRIMARY KEY (ID_Produto),
	FOREIGN KEY (ID_Produto) REFERENCES TB_Produto(ID_Produto) ON DELETE CASCADE
);


CREATE TABLE TB_CompraDiversos
(
	ID_CompraDiversos INT IDENTITY(1,1),
	ID_Produto INT NOT NULL,
	DT_Compra DATE NOT NULL,
	QTDE_Compra INT NOT NULL,
	PRIMARY KEY (ID_CompraDiversos, ID_Produto),
	FOREIGN KEY (ID_Produto) REFERENCES TB_Produto(ID_Produto) ON DELETE CASCADE,
);
GO



CREATE TABLE TB_FichaTecnica
(
	ID_Produto INT,
	ID_Insumo INT,
	QTDE_Utilizada DECIMAL(10,1) NOT NULL,
	PRIMARY KEY(ID_Produto, ID_Insumo),
	FOREIGN KEY (ID_Produto) REFERENCES TB_Produto(ID_Produto),
	FOREIGN KEY (ID_Insumo) REFERENCES TB_Insumo(ID_Insumo) ON DELETE CASCADE
);

CREATE TABLE TB_Perda
(
	ID_Perda INT PRIMARY KEY IDENTITY(1,1),
	ID_Insumo INT,
	QTDE_Perdida DECIMAL(10,2) NOT NULL,
    DS_Perda VARCHAR(150) NOT NULL,
	DT_Perda DATE NOT NULL,
	FOREIGN KEY (ID_Insumo) REFERENCES TB_Insumo(ID_Insumo) ON DELETE CASCADE
);


CREATE TABLE TB_Venda
(
	ID_Venda INT PRIMARY KEY IDENTITY(1,1),
	ID_Funcionario INT NOT NULL,
	ID_Cliente INT NOT NULL,
	DT_Venda DATETIME NOT NULL,
	OBS_Venda VARCHAR(50),
	DS_TipoPagamento VARCHAR(20),
	VL_TaxaEntrega DECIMAL(10,2),
	VL_Total DECIMAL(10,2),	
	FOREIGN KEY (ID_Cliente) REFERENCES TB_Cliente(ID_Cliente),
	FOREIGN KEY (ID_Funcionario) REFERENCES TB_Funcionario(ID_Funcionario)
);
GO


CREATE TABLE TB_ItemVenda
(
	ID_Venda INT,
	ID_Produto INT,
	QTDE_ItemVenda INT NOT NULL,
	VL_SubTotal DECIMAL(10,2) NOT NULL,
	PRIMARY KEY (ID_Venda, ID_Produto),
	FOREIGN KEY (ID_Venda) REFERENCES TB_Venda(ID_Venda) ON DELETE CASCADE,
	FOREIGN KEY (ID_Produto) REFERENCES	TB_Produto(ID_Produto)
);
GO


CREATE TABLE TB_RegistroLogin
(
	ID_Login INT,
	DT_RegistroLogin DATETIME,
	FOREIGN KEY (ID_Login) REFERENCES TB_Login(ID_Login),
	PRIMARY KEY (ID_Login)
);


INSERT INTO 
	TB_Funcionario(
	NM_Funcionario,
	DS_Sexo,
	DT_Nascimento,
	NR_CPF,
	NR_Telefone,
	DS_Email,
	NR_CEP,
	NM_Rua,
	NR_Casa,
	NM_Bairro,
	DS_Complemento,
	NM_Cidade,
	DS_UF,
	DS_Cargo,
	VL_Salario,
	DT_Admissao,
	Ativo)

	VALUES(
		'Caio',
		'Masculino',
		'2001-01-08',
		43867140812,
		15974079495,
		'caio.vcruz@outlook.com',
		18076290,
		'Rubião de Almeida',
		1426,
		'Jardim São Conrado',
		'',
		'Sorocaba',
		'SP',
		'Gerente',
		7000.00,
		'2010-01-08',
		1);
GO


INSERT INTO 
	TB_Funcionario(
		NM_Funcionario,
		DS_Sexo,
		DT_Nascimento,
		NR_CPF,
		NR_Telefone,
		DS_Email,
		NR_CEP,
		NM_Rua,
		NR_Casa,
		NM_Bairro,
		DS_Complemento,
		NM_Cidade,
		DS_UF,
		DS_Cargo,
		VL_Salario,
		DT_Admissao,
		Ativo)

	VALUES(
		'Eliezer',
		'Masculino',
		'1997-01-08',
		44448440869,
		15998388087,
		'eli.defilicibus@gmail.com',
		18025635,
		'Sousa Antunes',
		426,
		'Jardim Acassia',
		'',
		'Sorocaba',
		'SP',
		'Gerente',
		7000.00,
		'2010-01-08',
		1);
GO


INSERT INTO
	TB_NivelAcesso(
		DS_NivelAcesso)

	VALUES(
		'Gerente');
GO


INSERT INTO
	TB_NivelAcesso(
		DS_NivelAcesso)

	VALUES(
		'Atendente');
GO


INSERT INTO
	TB_Login(
		ID_Funcionario,
		ID_NivelAcesso,
		DS_Usuario,
		DS_Senha,
		Ativo)

	VALUES(
		1,
		1,
		'caiovcruz',
		'cruz11',
		1);
GO


INSERT INTO
	TB_Login(
		ID_Funcionario,
		ID_NivelAcesso,
		DS_Usuario,
		DS_Senha,
		Ativo)

	VALUES(
		2,
		1,
		'elidefilicibus',
		'eli11',
		1);
GO


INSERT INTO 
	TB_Cliente(
		NM_Cliente,
		NR_CPF,
		NR_Telefone,
		DS_Email,
		DS_Sexo,
		DT_Nascimento,	
		Ativo)

	VALUES(
		'Caio',
		43867140812,
		15974079495,
		'caio.vcruz@outlook.com',
		'Masculino',
		'2001-01-08',
		1);
GO


INSERT INTO 
	TB_Cliente(
		NM_Cliente,
		NR_CPF,
		NR_Telefone,
		DS_Email,
		DS_Sexo,
		DT_Nascimento,
		Ativo)

	VALUES(
		'Eliezer',
		44448440869,
		15998388087,
		'eli.defilicibus@gmail.com',
		'Masculino',
		'2001-01-08',
		1);
GO


INSERT INTO
	TB_Insumo(
		NM_Insumo,
		DS_TipoArmazenamento,
		PR_Insumo)
	
	VALUES(
		'Farinha',
		'KG(s)',
		30.00);
GO


INSERT INTO
	TB_Insumo(
		NM_Insumo,
		DS_TipoArmazenamento,
		PR_Insumo)
	
	VALUES(
		'Ovo',
		'Unidade(s)',
		20.00);
GO


INSERT INTO
	TB_Compra(
		ID_Insumo,
		DT_Compra,
		QTDE_InsumoCompra)

	VALUES(
		1,
		GETDATE(),
		3000.00);
GO


INSERT INTO
	TB_Compra(
		ID_Insumo,
		DT_Compra,
		QTDE_InsumoCompra)

	VALUES(
		2,
		GETDATE(),
		12.00);
GO


INSERT INTO
	TB_Estoque(
		ID_Insumo,
		QTDE_Estoque)
	VALUES(
		1,
		3000);
GO


INSERT INTO
	TB_Estoque(
		ID_Insumo,
		QTDE_Estoque)
	VALUES(
		2,
		12);
GO


INSERT INTO 
	TB_Categoria(
		NM_Categoria,
		DS_Categoria,
		Ativo)

	VALUES(
		'Pizza',
		'Pizzas Salgadas e Doces',
		1);
GO


INSERT INTO 
	TB_Categoria(
		NM_Categoria,
		DS_Categoria,
		Ativo)

	VALUES(
		'Refrigerante',
		'Refrigerante em geral',
		1);
GO


INSERT INTO
	TB_Produto(
		ID_Categoria,
		NM_Produto,
		PR_Unitario,
		PR_Custo,
		DS_Produto,
		Ativo,
		Diversos)

	VALUES(
		1,
		'Pizza bb',
		35.00,
		20.00,
		'Ingredientes Pizza bb: massa, molho, presunto, queijo, milho, ovo, palmito, calabresa',
		1,
		0);
GO


INSERT INTO
	TB_Produto(
		ID_Categoria,
		NM_Produto,
		PR_Unitario,
		PR_Custo,
		DS_Produto,
		Ativo,
		Diversos)

	VALUES(	
		1,
		'Pizza Portuguesa',
		35.00,
		20.00,
		'Ingredientes Pizza Portuguesa: massa, molho, presunto, queijo, milho, ovo, palmito, calabresa',
		1,
		0);
GO

INSERT INTO
	TB_Produto(
		ID_Categoria,
		NM_Produto,
		PR_Unitario,
		PR_Custo,
		DS_Produto,
		Ativo,
		Diversos)

	VALUES(
		2,
		'Coca-Cola',
		6.50,
		7.50,
		'Coca-Cola Lata 350ML',
		1,
		1);
GO

INSERT INTO 
	TB_FichaTecnica(
		ID_Produto,
		ID_Insumo,
		QTDE_Utilizada)

	VALUES(
		1,
		1,
		250.10);
GO


INSERT INTO 
	TB_FichaTecnica(
		ID_Produto,
		ID_Insumo,
		QTDE_Utilizada)

	VALUES(
		1,
		2,
		2);
GO


INSERT INTO 
	TB_FichaTecnica(
		ID_Produto,
		ID_Insumo,
		QTDE_Utilizada)

	VALUES(
		2,
		1,
		250);
GO


INSERT INTO 
	TB_FichaTecnica(
		ID_Produto,
		ID_Insumo,
		QTDE_Utilizada)

	VALUES(
		2,
		2,
		1);
GO


INSERT INTO
	TB_Venda(
		ID_Funcionario,
		ID_Cliente,
		DT_Venda,
		OBS_Venda,
		DS_TipoPagamento,
		VL_TaxaEntrega,
		VL_Total)

	VALUES(
		2,
		1,
		GETDATE(),
		'Sem milho',
		'Dinheiro',
		5.00,
		200.00);
GO


INSERT INTO
	TB_Venda(
		ID_Funcionario,
		ID_Cliente,
		DT_Venda,
		OBS_Venda,
		DS_TipoPagamento,
		VL_TaxaEntrega,
		VL_Total)

	VALUES(
		2,
		1,
		GETDATE(),
		'Sem ervilha',
		'Débito',
		5.00,
		520.00);
GO


INSERT INTO 
	TB_ItemVenda(
		ID_Venda,
		ID_Produto,
		QTDE_ItemVenda,
		VL_SubTotal)

	VALUES(
		1,
		1,
		2,
		70.00);
GO


INSERT INTO 
	TB_ItemVenda(
		ID_Venda,
		ID_Produto,
		QTDE_ItemVenda,
		VL_SubTotal)

	VALUES(
		1,
		2,
		5,
		175.00);
GO


INSERT INTO 
	TB_ItemVenda(
		ID_Venda,
		ID_Produto,
		QTDE_ItemVenda,
		VL_SubTotal)

	VALUES(
		2,
		2,
		11,
		1520.00);
GO


INSERT INTO 
	TB_ItemVenda(
		ID_Venda,
		ID_Produto,
		QTDE_ItemVenda,
		VL_SubTotal)

	VALUES(
		2,
		1,
		6,
		786.00);
GO


INSERT INTO
	TB_RegistroLogin(
		ID_Login,
		DT_RegistroLogin)

		VALUES(
		1,
		GETDATE());
GO


INSERT INTO
	TB_Perda(
	ID_Insumo,
	QTDE_Perdida,
	DS_Perda,
	DT_Perda)

	VALUES(
	1,
	200.00,
	'Insumo descartado pois passou da data de validade',
	GETDATE());
GO


SELECT * FROM TB_RegistroLogin
SELECT * FROM TB_Funcionario
SELECT * FROM TB_NivelAcesso
SELECT * FROM TB_Login
SELECT * FROM TB_Cliente
SELECT * FROM TB_Insumo
SELECT * FROM TB_Compra
SELECT * FROM TB_Estoque
SELECT * FROM TB_Categoria
SELECT * FROM TB_Produto
SELECT * FROM TB_FichaTecnica
SELECT * FROM TB_Perda
SELECT * FROM TB_ItemVenda


SELECT 

	VEN.ID_Venda,
	VEN.ID_Funcionario, 
	VEN.ID_Cliente, 
	VEN.DT_Venda,
	VEN.OBS_Venda,
	VEN.DS_TipoPagamento, 
	VEN.VL_TaxaEntrega, 
	VEN.VL_Total
	
FROM TB_Venda AS VEN


SELECT

	VEN.ID_Venda, 
	FUN.NM_Funcionario,
	CLI.NM_Cliente, 
	VEN.DT_Venda,
	PROD.NM_Produto,
	ITEM.QTDE_ItemVenda,
	VEN.OBS_Venda, 
	VEN.DS_TipoPagamento,
	VEN.VL_TaxaEntrega, 
	VEN.VL_Total

FROM TB_Venda AS VEN
	
	INNER JOIN TB_Cliente AS CLI
	ON VEN.ID_Cliente = CLI.ID_Cliente
	INNER JOIN TB_Funcionario AS FUN
	ON VEN.ID_Funcionario = FUN.ID_Funcionario
	INNER JOIN TB_ItemVenda AS ITEM
	ON VEN.ID_Venda = ITEM.ID_Venda
	INNER JOIN TB_Produto AS PROD
	ON ITEM.ID_Produto = PROD.ID_Produto


