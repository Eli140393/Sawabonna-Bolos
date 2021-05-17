-- Procedimentos tabela login

-- Procedimento Mostrar

CREATE PROC spmostrar_login
@ID_UnidadeRede INT
AS
SELECT ALL
LGN.ID_Login,
LGN.ID_UnidadeRede,
UNI.DS_UnidadeRede,
LGN.ID_Funcionario,
FUN.NM_Funcionario,
LGN.ID_NivelAcesso,
NVL.DS_NivelAcesso,
LGN.DS_Usuario,
LGN.DS_Senha
FROM TB_Login AS LGN
INNER JOIN TB_Funcionario AS FUN
ON LGN.ID_Funcionario = FUN.ID_Funcionario
INNER JOIN TB_NivelAcesso AS NVL
ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso
INNER JOIN TB_UnidadeRede AS UNI
ON LGN.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE LGN.Ativo = 1
AND LGN.ID_UnidadeRede = @ID_UnidadeRede
ORDER BY ID_Login ASC
GO

 -- Procedimento buscar nome
 
CREATE PROC spbuscar_nome_funcionario_login
@textobuscar VARCHAR (50),
@ID_UnidadeRede INT
AS
SELECT
LGN.ID_Login,
LGN.ID_UnidadeRede,
UNI.DS_UnidadeRede,
LGN.ID_Funcionario,
FUN.NM_Funcionario,
LGN.ID_NivelAcesso,
NVL.DS_NivelAcesso,
LGN.DS_Usuario,
LGN.DS_Senha
FROM TB_Login AS LGN
INNER JOIN TB_Funcionario AS FUN
ON LGN.ID_Funcionario = FUN.ID_Funcionario
INNER JOIN TB_NivelAcesso AS NVL
ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso
INNER JOIN TB_UnidadeRede AS UNI
ON LGN.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE LGN.Ativo = 1
AND DS_Usuario LIKE @textobuscar + '%'
AND LGN.ID_UnidadeRede = @ID_UnidadeRede
GO


CREATE PROC spinserir_registro_login
@ID_Login INT
AS INSERT INTO TB_RegistroLogin(
ID_Login,
DT_RegistroLogin)
VALUES (
@ID_Login,
GETDATE())
GO


CREATE PROC speditar_registro_login
@ID_Login INT
AS
UPDATE TB_RegistroLogin SET
DT_RegistroLogin = GETDATE() 
WHERE ID_Login = @ID_Login
GO


CREATE PROC spmostrar_registro_login
AS
SELECT 
RLGN.ID_Login,
LGN.ID_Funcionario,
FUN.NM_Funcionario,
LGN.ID_NivelAcesso,
NVL.DS_NivelAcesso,
LGN.ID_UnidadeRede,
UNI.DS_UnidadeRede,
RLGN.DT_RegistroLogin
FROM TB_RegistroLogin AS RLGN

INNER JOIN TB_Login AS LGN
ON RLGN.ID_Login = LGN.ID_Login

INNER JOIN TB_Funcionario AS FUN
ON LGN.ID_Funcionario = FUN.ID_Funcionario

INNER JOIN TB_NivelAcesso AS NVL
ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso

INNER JOIN TB_UnidadeRede AS UNI
ON LGN.ID_UnidadeRede = UNI.ID_UnidadeRede
ORDER BY RLGN.DT_RegistroLogin ASC


 -- Procedimento inserir

CREATE PROC spinserir_login
@ID_Login INT OUTPUT,
@ID_Funcionario INT,
@ID_NivelAcesso INT,
@ID_UnidadeRede INT,
@DS_Usuario VARCHAR (20),
@DS_Senha VARCHAR (20)
AS INSERT INTO TB_Login(
ID_Funcionario,
ID_NivelAcesso,
ID_UnidadeRede,
DS_Usuario,
DS_Senha,
Ativo)
VALUES (
@ID_Funcionario,
@ID_NivelAcesso,
@ID_UnidadeRede,
@DS_Usuario,
@DS_Senha,
1)
GO

-- Procedimento editar 

CREATE PROC speditar_login
@ID_Login INT,
@ID_NivelAcesso INT,
@DS_Usuario VARCHAR (20),
@DS_Senha VARCHAR (20)
AS
UPDATE TB_Login SET
ID_NivelAcesso = @ID_NivelAcesso,
DS_Usuario = @DS_Usuario,
DS_Senha = @DS_Senha
WHERE ID_Login = @ID_Login
GO


-- Procedimento deletar

CREATE PROC spdeletar_login
@ID_Login INT
AS 
UPDATE TB_Login SET
Ativo = 0
WHERE ID_Login = @ID_Login
GO


CREATE PROC spvalidar_login
@ID_UnidadeRede INT,
@DS_Usuario VARCHAR (20),
@DS_Senha VARCHAR (20)
AS
SELECT  ALL
LGN.ID_Login,
FUN.NM_Funcionario,
UNI.DS_UnidadeRede,
NVL.DS_NivelAcesso,
LGN.DS_Usuario,
LGN.DS_Senha,
LGN.ID_UnidadeRede,
LGN.ID_Funcionario,
LGN.ID_NivelAcesso
FROM TB_Login AS LGN
INNER JOIN TB_UnidadeRede AS UNI
ON LGN.ID_UnidadeRede = UNI.ID_UnidadeRede
INNER JOIN TB_Funcionario AS FUN
ON LGN.ID_Funcionario = FUN.ID_Funcionario
INNER JOIN TB_NivelAcesso AS NVL
ON LGN.ID_NivelAcesso = NVL.ID_NivelAcesso
WHERE LGN.Ativo = 1
AND LGN.ID_UnidadeRede = @ID_UnidadeRede
AND LGN.DS_Usuario = @DS_Usuario
AND LGN.DS_Senha = @DS_Senha
ORDER BY ID_Login ASC