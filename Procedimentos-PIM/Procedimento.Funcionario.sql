-- Procedimentos tabela funcionario

-- Procedimento mostrar funcionário
CREATE PROC spmostrar_funcionario
@ID_UnidadeRede INT
AS
SELECT  ALL
FUN.ID_UnidadeRede,
UNI.DS_UnidadeRede,
FUN.ID_Funcionario,
FUN.NM_Funcionario,
FUN.DS_Sexo,
FUN.NR_CPF,
FUN.DT_Nascimento,
FUN.NR_Telefone,
FUN.DS_Email,
FUN.DS_Cargo,
FORMAT(FUN.VL_Salario, 'N2') AS VL_Salario,
FUN.DT_Admissao,
FUN.NM_Rua,
FUN.NR_Casa,
FUN.DS_Complemento,
FUN.NM_Bairro,
FUN.NR_CEP,
FUN.NM_Cidade,
FUN.DS_UF
FROM TB_Funcionario AS FUN
INNER JOIN TB_UnidadeRede AS UNI
ON FUN.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE ISNULL(DT_Demissao, '') = ''
AND FUN.ID_UnidadeRede = @ID_UnidadeRede
ORDER BY ID_Funcionario ASC
GO

 -- Procedimento buscar nome
  
CREATE PROC spbuscar_nome_funcionario
@textobuscar VARCHAR (50),
@ID_UnidadeRede INT
AS SELECT
FUN.ID_UnidadeRede,
UNI.DS_UnidadeRede,
FUN.ID_Funcionario,
FUN.NM_Funcionario,
FUN.DS_Sexo,
FUN.NR_CPF,
FUN.DT_Nascimento,
FUN.NR_Telefone,
FUN.DS_Email,
FUN.DS_Cargo,
FORMAT(FUN.VL_Salario, 'N2') AS VL_Salario,
FUN.DT_Admissao,
FUN.NM_Rua,
FUN.NR_Casa,
FUN.DS_Complemento,
FUN.NM_Bairro,
FUN.NR_CEP,
FUN.NM_Cidade,
FUN.DS_UF
FROM TB_Funcionario AS FUN
INNER JOIN TB_UnidadeRede AS UNI
ON FUN.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE NM_Funcionario LIKE @textobuscar + '%'
AND ISNULL(DT_Demissao, '') = ''
AND FUN.ID_UnidadeRede = @ID_UnidadeRede
GO

-- Procedimento buscar pelo cpf
 
CREATE PROC spbuscar_cpf_funcionario
@textobuscar VARCHAR (11),
@ID_UnidadeRede INT
AS SELECT
FUN.ID_UnidadeRede,
UNI.DS_UnidadeRede,
FUN.ID_Funcionario,
FUN.NM_Funcionario,
FUN.DS_Sexo,
FUN.NR_CPF,
FUN.DT_Nascimento,
FUN.NR_Telefone,
FUN.DS_Email,
FUN.DS_Cargo,
FORMAT(FUN.VL_Salario, 'N2') AS VL_Salario,
FUN.DT_Admissao,
FUN.NM_Rua,
FUN.NR_Casa,
FUN.DS_Complemento,
FUN.NM_Bairro,
FUN.NR_CEP,
FUN.NM_Cidade,
FUN.DS_UF
FROM TB_Funcionario AS FUN
INNER JOIN TB_UnidadeRede AS UNI
ON FUN.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE NR_CPF LIKE @textobuscar + '%'
AND ISNULL(DT_Demissao, '') = ''
AND FUN.ID_UnidadeRede = @ID_UnidadeRede
GO

 -- Procedimento inserir funcionário

CREATE PROC spinserir_funcionario
@ID_Funcionario INT OUTPUT,
@NM_Funcionario VARCHAR(50),
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
@DS_UF VARCHAR(2),
@DS_Cargo VARCHAR(30),
@VL_Salario DECIMAL(10,2),
@DT_Admissao DATE,
@ID_UnidadeRede INT
AS 
INSERT INTO TB_Funcionario(
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
ID_UnidadeRede) 
VALUES(
@NM_Funcionario,
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
@DS_Cargo,
@VL_Salario,
@DT_Admissao,
@ID_UnidadeRede)
GO

-- Procedimento editar funcionário

CREATE PROC speditar_funcionario
@ID_Funcionario INT,
@NM_Funcionario VARCHAR(50),
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
@DS_UF VARCHAR(2),
@DS_Cargo VARCHAR(30),
@VL_Salario DECIMAL(10,2),
@DT_Admissao DATE,
@ID_UnidadeRede INT
AS
UPDATE TB_Funcionario SET
@NM_Funcionario = @NM_Funcionario,
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
DS_UF = @DS_UF,
DS_Cargo = @DS_Cargo,
VL_Salario = @VL_Salario,
DT_Admissao = @DT_Admissao
WHERE ID_Funcionario = @ID_Funcionario
AND ID_UnidadeRede = @ID_UnidadeRede
GO


-- Procedimento deletar funcionário

CREATE PROC spdeletar_funcionario
@ID_Funcionario INT,
@ID_UnidadeRede INT
AS
UPDATE TB_Funcionario SET
DT_Demissao = GETDATE()
WHERE ID_Funcionario = @ID_Funcionario
AND ID_UnidadeRede = @ID_UnidadeRede
GO