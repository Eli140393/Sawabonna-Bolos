-- Procedimentos tabela ficha técnica

-- Procedimento Mostrar

CREATE PROC spmostrar_ficha_tecnica
@ID_Produto INT
AS
SELECT ALL
FTEC.ID_Produto,
INS.ID_Insumo,
INS.NM_Insumo,
INS.DS_TipoArmazenamento,
FORMAT(FTEC.QTDE_Utilizada, 'N2') AS QTDE_Utilizada
FROM TB_FichaTecnica AS FTEC
INNER JOIN TB_Insumo AS INS
ON FTEC.ID_Insumo = INS.ID_Insumo
WHERE FTEC.ID_Produto = @ID_Produto
ORDER BY ID_Produto ASC
GO

 -- Procedimento inserir

CREATE PROC spinserir_ficha_tecnica
@ID_Produto INT,
@ID_Insumo INT,
@QTDE_Utilizada DECIMAL(10,2)
AS INSERT INTO TB_FichaTecnica(
ID_Produto,
ID_Insumo,
QTDE_Utilizada)
VALUES (
@ID_Produto,
@ID_Insumo,
@QTDE_Utilizada)
GO

-- Procedimento editar

CREATE PROC speditar_ficha_tecnica
@ID_Produto INT,
@ID_Insumo INT,
@QTDE_Utilizada DECIMAL(10,2)
AS
UPDATE TB_FichaTecnica SET
QTDE_Utilizada = @QTDE_Utilizada
WHERE ID_Produto = @ID_Produto 
AND ID_Insumo = @ID_Insumo
GO


-- Procedimento deletar 

CREATE PROC spdeletar_ficha_tecnica
@ID_Produto INT,
@ID_Insumo INT
AS 
DELETE FROM TB_FichaTecnica 
WHERE ID_Produto = @ID_Produto
AND ID_Insumo = @ID_Insumo
GO