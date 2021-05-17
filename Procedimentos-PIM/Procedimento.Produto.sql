-- Procedimentos tabela lote

-- Procedimento Mostrar
CREATE PROC spmostrar_produtos
AS SELECT ALL
PROD.ID_Produto,
CAT.NM_Categoria,
PROD.NM_Produto,
FORMAT(PROD.PR_Unitario, 'N2') AS PR_Unitario,
FORMAT(PROD.PR_Custo, 'N2') AS PR_Custo,
PROD.DS_Produto,
PROD.IMG_Produto
FROM TB_Produto AS PROD
INNER JOIN TB_Categoria AS CAT
ON PROD.ID_Categoria = CAT.ID_Categoria
WHERE PROD.Ativo = 1
ORDER BY ID_Produto
GO

 -- Procedimento buscar  nome
 
CREATE PROC spbuscar_produto
@textobuscar VARCHAR (50)
AS SELECT
PROD.ID_Produto,
CAT.NM_Categoria,
PROD.NM_Produto,
FORMAT(PROD.PR_Unitario, 'N2') AS PR_Unitario,
FORMAT(PROD.PR_Custo, 'N2') AS PR_Custo,
PROD.DS_Produto,
PROD.IMG_Produto
FROM TB_Produto AS PROD
INNER JOIN TB_Categoria AS CAT
ON PROD.ID_Categoria = CAT.ID_Categoria 
WHERE PROD.Ativo = 1
AND NM_Produto LIKE @textobuscar + '%' 


 -- Procedimento inserir

CREATE PROC spinserir_produto
@ID_Produto INT OUTPUT,
@ID_Categoria INT,
@NM_Produto VARCHAR (50),
@PR_Unitario DECIMAL (10,2),
@PR_Custo DECIMAL (10,2),
@DS_Produto VARCHAR (150),
@IMG_Produto IMAGE,
@Diversos BIT
AS INSERT INTO TB_Produto(
ID_Categoria,
NM_Produto,
PR_Unitario,
PR_Custo,
DS_Produto,
IMG_Produto,
Ativo,
Diversos)
VALUES (
@ID_Categoria,
@NM_Produto,
@PR_Unitario,
@PR_Custo,
@DS_Produto,
@IMG_Produto,
1,
@Diversos)
GO

-- Procedimento editar 

CREATE PROC speditar_produto
@ID_Produto INT,
@ID_Categoria INT,
@NM_Produto VARCHAR (50),
@PR_Unitario DECIMAL (10,2),
@PR_Custo DECIMAL (10,2),
@DS_Produto VARCHAR (150),
@IMG_Produto IMAGE
AS
UPDATE TB_Produto SET
ID_Categoria = @ID_Categoria,
NM_Produto = @NM_Produto,
PR_Unitario = @PR_Unitario,
PR_Custo = @PR_Custo,
DS_Produto = @DS_Produto,
IMG_Produto = @IMG_Produto
WHERE ID_Produto = @ID_Produto
GO


-- Procedimento deletar

CREATE PROC spdeletar_produto
@ID_Produto INT
AS 
UPDATE TB_Produto SET
Ativo = 0
WHERE ID_Produto = @ID_Produto
GO


CREATE PROC speditar_produto_preco
@ID_Produto INT,
@PR_Custo DECIMAL (10,2)
AS
UPDATE TB_Produto SET
PR_Custo = @PR_Custo
WHERE ID_Produto = @ID_Produto
GO