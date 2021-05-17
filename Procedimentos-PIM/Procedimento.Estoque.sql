
-- PROCEDIMENTO PARA MOSTRAR ESTOQUE

CREATE PROC spmostrar_estoque
@ID_UnidadeRede INT
AS
SELECT 
EST.ID_UnidadeRede,
UNI.DS_UnidadeRede,
EST.ID_Insumo,
INS.NM_Insumo,
FORMAT(EST.QTDE_Estoque, 'N2') AS QTDE_Estoque
FROM TB_Estoque AS EST
INNER JOIN TB_Insumo AS INS
ON EST.ID_UnidadeRede = INS.ID_Insumo
INNER JOIN TB_UnidadeRede AS UNI
ON EST.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE EST.ID_UnidadeRede = @ID_UnidadeRede
ORDER BY ID_Insumo ASC
GO


CREATE PROC spbuscar_insumo_estoque
@ID_UnidadeRede INT,
@textobuscar VARCHAR (50)
AS
SELECT 
EST.ID_UnidadeRede,
UNI.DS_UnidadeRede,
EST.ID_Insumo,
INS.NM_Insumo,
FORMAT(EST.QTDE_Estoque, 'N2') AS QTDE_Estoque
FROM TB_Estoque AS EST
INNER JOIN TB_Insumo AS INS
ON EST.ID_UnidadeRede = INS.ID_Insumo
INNER JOIN TB_UnidadeRede AS UNI
ON EST.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE INS.NM_Insumo LIKE @textobuscar + '%'
AND EST.ID_UnidadeRede = @ID_UnidadeRede
ORDER BY ID_Insumo ASC
GO

-- PROCEDIMENTO INSERIR ESTOQUE

CREATE PROC spinserir_estoque
@ID_Insumo INT,
@QTDE_Estoque DECIMAL (10,2),
@ID_UnidadeRede INT
AS INSERT INTO TB_Estoque(
ID_Insumo,
QTDE_Estoque,
ID_UnidadeRede)
VALUES (
@ID_Insumo,
@QTDE_Estoque,
@ID_UnidadeRede)
GO

-- PROCEDIMENTO EDITAR ESTOQUE

CREATE PROC speditar_estoque
@ID_Insumo INT,
@QTDE_Estoque DECIMAL (10,2),
@ID_UnidadeRede INT
AS UPDATE TB_Estoque SET
QTDE_Estoque +=  @QTDE_Estoque
WHERE ID_Insumo = @ID_Insumo
AND ID_UnidadeRede = @ID_UnidadeRede
GO

-- PROCEDIMENTO BAIXA ESTOQUE

CREATE PROC spbaixa_estoque
@ID_Insumo INT,
@QTDE_Estoque DECIMAL (10,2),
@ID_UnidadeRede INT
AS UPDATE TB_Estoque SET
QTDE_Estoque -=  @QTDE_Estoque
WHERE ID_Insumo = @ID_Insumo
AND ID_UnidadeRede = @ID_UnidadeRede
GO

-- PROCEDIMENTO EXCLUIR ESTOQUE

CREATE PROC spdeletar_estoque
@ID_Insumo INT,
@ID_UnidadeRede INT
AS DELETE FROM TB_Estoque
WHERE ID_Insumo = @ID_Insumo
AND ID_UnidadeRede = @ID_UnidadeRede
GO