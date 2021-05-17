-- Procedimento mostrar compra

CREATE PROC spmostrar_compra
@ID_UnidadeRede INT
AS
SELECT ALL
COM.ID_UnidadeRede,
UNI.DS_UnidadeRede,
COM.ID_Compra,
INS.NM_Insumo,
COM.ID_Insumo,
COM.DT_Compra,
FORMAT(COM.QTDE_InsumoCompra, 'N2') AS QTDE_InsumoCompra
FROM TB_Compra AS COM
INNER JOIN TB_Insumo AS INS
ON COM.ID_Insumo = INS.ID_Insumo
INNER JOIN TB_UnidadeRede AS UNI
ON COM.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE COM.ID_UnidadeRede = @ID_UnidadeRede
ORDER BY ID_Compra ASC
GO

-- Procedimento buscar pela data

CREATE PROC spbuscar_data_compra
@DataBuscar DATE,
@ID_UnidadeRede INT
AS SELECT 
COM.ID_UnidadeRede,
UNI.DS_UnidadeRede,
COM.ID_Compra,
INS.NM_Insumo,
COM.ID_Insumo,
COM.DT_Compra,
FORMAT(COM.QTDE_InsumoCompra, 'N2') AS QTDE_InsumoCompra
FROM TB_Compra AS COM
INNER JOIN TB_Insumo AS INS
ON COM.ID_Insumo = INS.ID_Insumo
INNER JOIN TB_UnidadeRede AS UNI
ON COM.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE DT_Compra LIKE @DataBuscar
AND COM.ID_UnidadeRede = @ID_UnidadeRede
GO

-- Procedimento inserir compra

CREATE PROC spinserir_compra
@ID_Compra INT OUTPUT,
@ID_Insumo INT,
@DT_Compra DATE,
@QTDE_InsumoCompra DECIMAL (10,2),
@ID_UnidadeRede INT
AS INSERT INTO TB_Compra(
ID_Insumo,
DT_Compra,
QTDE_InsumoCompra,
ID_UnidadeRede)
VALUES(
@ID_Insumo,
@DT_Compra,
@QTDE_InsumoCompra,
@ID_UnidadeRede)
GO

-- Procedimento editar entrada estoque

CREATE PROC speditar_compra
@ID_Compra INT,
@ID_Insumo INT,
@DT_Compra DATE,
@QTDE_InsumoCompra DECIMAL (10,2),
@ID_UnidadeRede INT
AS
UPDATE TB_Compra SET
ID_Insumo = @ID_Insumo,
DT_Compra = @DT_Compra,
QTDE_InsumoCompra = @QTDE_InsumoCompra
WHERE ID_Compra = @ID_Compra
AND ID_UnidadeRede = @ID_UnidadeRede
GO

-- Procedimento deletar entrada estoque

CREATE PROC spdeletar_compra
@ID_Compra INT,
@ID_UnidadeRede INT
AS
DELETE FROM TB_Compra 
WHERE ID_Compra = @ID_Compra
AND ID_UnidadeRede = @ID_UnidadeRede
GO
