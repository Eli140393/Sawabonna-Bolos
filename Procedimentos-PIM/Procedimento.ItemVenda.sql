-- Procedimentos tabela Item Venda

-- Procedimento Mostrar

CREATE PROC spmostrar_item_venda
@ID_Venda INT
AS
SELECT 
ITEM.ID_Venda,
ITEM.ID_Produto,
PROD.NM_Produto,
ITEM.QTDE_ItemVenda,
FORMAT(ITEM.VL_SubTotal, 'N2') AS VL_SubTotal
FROM  TB_ItemVenda AS ITEM
INNER JOIN TB_Produto AS PROD
ON ITEM.ID_Produto = PROD.ID_Produto
WHERE ID_Venda = @ID_Venda
ORDER BY ITEM.ID_Venda
GO


CREATE PROC spmostrar_todos_item_venda
AS
SELECT 
ITEM.ID_Venda,
ITEM.ID_Produto,
PROD.NM_Produto,
ITEM.QTDE_ItemVenda,
FORMAT(ITEM.VL_SubTotal, 'N2') AS VL_SubTotal
FROM  TB_ItemVenda AS ITEM
INNER JOIN TB_Produto AS PROD
ON ITEM.ID_Produto = PROD.ID_Produto
ORDER BY ITEM.ID_Venda
GO

 -- Procedimento buscar  nome
 
CREATE PROC spbuscar_nome_item_venda
@textobuscar VARCHAR (50)
AS SELECT
PD.ID_Venda,			
PROD.NM_Produto,
PD.QTDE_ItemVenda,
VL_SubTotal
FROM  TB_ItemVenda AS PD
INNER JOIN TB_Produto AS PROD
ON PD.ID_Produto =PROD.ID_Produto
WHERE PROD.NM_Produto LIKE @textobuscar + '%'


 -- Procedimento inserir

CREATE PROC spinserir_item_venda
@ID_Venda INT,
@ID_Produto INT,
@QTDE_ItemVenda INT,
@VL_SubTotal DECIMAL (10,2)
AS INSERT INTO TB_ItemVenda(
ID_Venda,
ID_Produto,
QTDE_ItemVenda,
VL_SubTotal)
VALUES (
@ID_Venda,
@ID_Produto,
@QTDE_ItemVenda,
@VL_SubTotal)
GO

-- Procedimento editar 

CREATE PROC speditar_item_venda
@ID_Venda INT,
@ID_Produto INT ,
@QTDE_ItemVenda INT,
@VL_SubTotal DECIMAL (7,2)
AS
UPDATE TB_ItemVenda SET
ID_Produto = @ID_Produto,
QTDE_ItemVenda = @QTDE_ItemVenda,
VL_SubTotal = @VL_SubTotal
WHERE ID_Venda = @ID_Venda AND
ID_Produto = @ID_Produto
GO


-- Procedimento deletar todos os do ultimo pedido
CREATE PROC spdeletar_item_venda_todos
@ID_Venda INT
AS 
DELETE FROM TB_ItemVenda WHERE
ID_Venda = @ID_Venda
GO


-- Procedimento deletar  um
CREATE PROC spdeletar_item_venda_um
@ID_Venda INT,
@ID_Produto INT
AS  
DELETE FROM TB_ItemVenda WHERE
ID_Venda = @ID_Venda AND
ID_Produto = @ID_Produto
GO