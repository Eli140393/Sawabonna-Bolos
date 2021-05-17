-- Procedimentos tabela funcionario

-- Procedimento Mostrar

CREATE PROC spmostrar_insumo
AS
SELECT ALL
ID_Insumo,
NM_Insumo,
DS_TipoArmazenamento,
FORMAT(PR_Insumo, 'N2') AS PR_Insumo
FROM TB_Insumo
ORDER BY ID_Insumo ASC
GO

 -- Procedimento buscar nome
 
CREATE PROC spbuscar_insumo
@textobuscar VARCHAR (50)
AS 
SELECT
ID_Insumo,
NM_Insumo,
DS_TipoArmazenamento,
FORMAT(PR_Insumo, 'N2') AS PR_Insumo
FROM TB_Insumo 
WHERE NM_Insumo LIKE @textobuscar + '%'


 -- Procedimento inserir

CREATE PROC spinserir_insumo
@ID_Insumo INT OUTPUT,
@NM_Insumo VARCHAR (50),
@DS_TipoArmazenamento VARCHAR (50),
@PR_Insumo DECIMAL (10,2)
AS 
INSERT INTO TB_Insumo(
NM_Insumo,
DS_TipoArmazenamento,
PR_Insumo)
VALUES (
@NM_Insumo,
@DS_TipoArmazenamento,
@PR_Insumo)
GO

-- Procedimento editar estoque insumo

CREATE PROC speditar_insumo
@ID_Insumo INT,
@NM_Insumo VARCHAR (50),
@DS_TipoArmazenamento VARCHAR (150),
@PR_Insumo DECIMAL (7,2)
AS
UPDATE TB_Insumo SET
NM_Insumo = @NM_Insumo,
DS_TipoArmazenamento = @DS_TipoArmazenamento,
PR_Insumo = @PR_Insumo
WHERE ID_Insumo = @ID_Insumo
GO


-- Procedimento deletar estoque insumo

CREATE PROC spdeletar_insumo
@ID_Insumo INT
AS 
DELETE FROM TB_Insumo WHERE
ID_Insumo = @ID_Insumo
GO