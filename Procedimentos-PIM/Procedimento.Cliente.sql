-- Procedimentos tabela cliente


-- Procedimento mostrar cliente

CREATE PROC spmostrar_cliente
AS
SELECT  ALL
ID_Cliente,
NM_Cliente,
DS_Sexo,
NR_CPF,
DT_Nascimento,
NR_Telefone,
DS_Email,
NM_Rua,
NR_Casa,
DS_Complemento,
NM_Bairro,
NR_CEP,
NM_Cidade,
DS_UF
FROM TB_Cliente 
WHERE Ativo = 1
ORDER BY ID_Cliente ASC
GO

-- Procedimento buscar pelo nome

CREATE PROC spbuscar_nome_cliente
@textobuscar VARCHAR (50)
AS SELECT
ID_Cliente,
NM_Cliente,
DS_Sexo,
NR_CPF,
DT_Nascimento,
NR_Telefone,
DS_Email,
NM_Rua,
NR_Casa,
--DS_Complemento,
NM_Bairro,
NR_CEP,
NM_Cidade,
DS_UF
FROM TB_Cliente 
WHERE Ativo = 1
AND NM_Cliente LIKE @textobuscar + '%'
GO

-- procedimento buscar pelo cpf

CREATE PROC spbuscar_cpf_cliente
@textobuscar VARCHAR (11)
AS SELECT
ID_Cliente,
NM_Cliente,
DS_Sexo,
NR_CPF,
DT_Nascimento,
NR_Telefone,
DS_Email,
NM_Rua,
NR_Casa,
DS_Complemento,
NM_Bairro,
NR_CEP,
NM_Cidade,
DS_UF
FROM TB_Cliente 
WHERE Ativo = 1
AND NR_CPF LIKE @textobuscar + '%'
GO

--Procedimento inserir cliente

CREATE PROC spinserir_cliente
@ID_Cliente INT OUTPUT,
@NM_Cliente VARCHAR(50),
@DS_Sexo VARCHAR(1),
@DT_Nascimento DATE,
@NR_CPF NUMERIC(11,0),
@NR_Telefone NUMERIC(11,0),
@DS_Email VARCHAR(35),
@NR_CEP VARCHAR(10),
@NM_Rua VARCHAR(50),
@NR_Casa VARCHAR(5),
@NM_Bairro VARCHAR(50),
@DS_Complemento VARCHAR(50),
@NM_Cidade VARCHAR(30),
@DS_UF VARCHAR(2)
AS 
INSERT INTO TB_Cliente (
NM_Cliente,
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
Ativo) 
VALUES(
@NM_Cliente,
@DS_Sexo,
@DT_Nascimento,
@NR_CPF,
@NR_Telefone,
@DS_Email,
@NR_CEP,
@NM_Rua,
@NR_Casa,
@NM_Bairro,
@DS_Complemento,
@NM_Cidade,
@DS_UF,
1)
GO

-- Procedimento editar cliente

CREATE PROC speditar_cliente
@ID_Cliente INT,
@NM_Cliente VARCHAR(50),
@DS_Sexo VARCHAR(1),
@DT_Nascimento DATE,
@NR_CPF NUMERIC(11,0),
@NR_Telefone NUMERIC(11,0),
@DS_Email VARCHAR(35),
@NR_CEP VARCHAR(10),
@NM_Rua VARCHAR(50),
@NR_Casa VARCHAR(5),
@NM_Bairro VARCHAR(50),
@DS_Complemento VARCHAR(50),
@NM_Cidade VARCHAR(30),
@DS_UF VARCHAR(2)
AS
UPDATE TB_Cliente SET
NM_Cliente = @NM_Cliente,
DS_Sexo = @DS_Sexo,
DT_Nascimento = @DT_Nascimento,
NR_CPF = @NR_CPF,
NR_Telefone = @NR_Telefone,
DS_Email = @DS_Email,
NR_CEP = @NR_CEP,
NM_Rua = @NM_Rua,
NR_Casa = @NR_Casa,
NM_Bairro = @NM_Bairro,
DS_Complemento = @DS_Complemento,
NM_Cidade = @NM_Cidade,
DS_UF = @DS_UF
WHERE ID_Cliente = @ID_Cliente
GO

-- Procedimento deletar cliente

CREATE PROC spdeletar_cliente
@ID_Cliente INT
AS
UPDATE TB_Cliente SET
Ativo = 0
WHERE ID_Cliente = @ID_Cliente
GO