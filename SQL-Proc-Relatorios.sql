CREATE PROC RelatoriosTotais
@TotalVendas FLOAT OUT,
@TotalProdutos INT OUT,
@TotalProdutosDiversos INT OUT,
@TotalCategorias INT OUT,
@TotalClientes INT OUT,
@TotalFuncionarios INT OUT,
@TotalInsumos INT OUT,
@TotalCompras INT OUT


as
set @TotalVendas =( select sum(VL_Total) as TotalVendas from TB_Venda)

set @TotalProdutos = (select count(ID_Produto) as TotalProdutos from TB_Produto
where Diversos = 0)

set @TotalProdutosDiversos =( select count(ID_Produto) as TotalProdutosDiversos from TB_Produto 
where Diversos = 1)

set @TotalCategorias =( select count(ID_Categoria) as TotalCategorias from TB_Categoria)

set @TotalClientes =( select count(ID_Cliente) as TotalClientes from TB_Cliente)

set @TotalFuncionarios =( select count(ID_Funcionario) as TotalFuncionarios from TB_Funcionario
where Ativo = 1)
set @TotalInsumos =( select count(ID_Insumo) as TotalInsumos from TB_Insumo)

set @TotalCompras =( select SUM(INS.PR_Insumo * QTDE_InsumoCompra) AS TotalCompra  from TB_Compra as COM
INNER JOIN TB_Insumo AS INS
ON COM.ID_Insumo = INS.ID_Insumo)

go


-- PRODUTOS PREFERIDOS
CREATE PROC MaisVendidos
AS
SELECT TOP 5 CAT.NM_Categoria + ': ' + PROD.NM_Produto as Produtos, sum(ITEM.QTDE_ItemVenda) AS MaisVendidos
from TB_ItemVenda AS ITEM
INNER JOIN TB_Produto AS PROD ON PROD.ID_Produto = ITEM.ID_Produto
INNER JOIN TB_Categoria AS CAT ON CAT.ID_Categoria = PROD.ID_Categoria
group by ITEM.ID_Produto, CAT.NM_Categoria, PROD.NM_Produto
order by SUM(2) DESC
GO



-- PRODUTOS POR CATEGORIAS
CREATE PROC ProdutosPorCategorias
AS
SELECT C.NM_Categoria AS Categoria , COUNT (C.ID_Categoria) AS Quantidade
from TB_Produto AS PROD
INNER JOIN TB_Categoria AS C ON C.ID_Categoria = PROD.ID_Categoria
GROUP BY C.ID_Categoria, C.NM_Categoria
ORDER BY COUNT(2)
go



-- PRODUTOS PREÇO CUSTO
CREATE PROC PrecoDeCusto
AS
SELECT PROD.NM_Produto AS Produto, SUM((PROD.PR_Custo ) * ITEM.QTDE_ItemVenda) AS TotalCusto,
SUM(ITEM.VL_SubTotal) AS TotalVenda,
SUM(((ITEM.VL_SubTotal) / (PROD.PR_Custo  * ITEM.QTDE_ItemVenda)) - 1) *100 as Lucro
from TB_Produto AS PROD
INNER JOIN TB_ItemVenda AS ITEM
ON PROD.ID_Produto = ITEM.ID_Produto
GROUP BY PROD.PR_Custo, PROD.NM_Produto
go





select * from TB_ItemVenda

select * from TB_Produto

select count(ID_Produto) as TotalProdutos from TB_Produto



--	Venda---

SELECT 
VEN.ID_Venda,
VEN.DT_Venda,
CLI.NM_Cliente,
SUM(ITEM.QTDE_ItemVenda* PROD.PR_Unitario ) + VEN.VL_TaxaEntrega AS VL_Total
FROM TB_Venda AS VEN
INNER JOIN TB_Cliente as CLI
ON VEN.ID_Cliente = CLI.ID_Cliente
INNER JOIN TB_ItemVenda AS ITEM
ON VEN.ID_Venda = ITEM.ID_Venda
INNER JOIN TB_Produto as PROD
ON PROD.ID_Produto = ITEM.ID_Produto
GROUP BY VEN.ID_Venda, VEN.DT_Venda, CLI.NM_Cliente, VEN.VL_TaxaEntrega
ORDER BY VEN.ID_Venda




				SELECT 
                VEN.ID_Venda,
                VEN.DT_Venda,
                CLI.NM_Cliente,
				FUN.NM_Funcionario,
				string_agg(PROD.NM_Produto, ',  ') as NM_Produtos,
                SUM(ITEM.QTDE_ItemVenda* PROD.PR_Unitario ) + VEN.VL_TaxaEntrega AS VL_Total,
				SUM((PROD.PR_Custo ) * ITEM.QTDE_ItemVenda) AS TotalCusto
                FROM TB_Venda AS VEN
                INNER JOIN TB_Cliente as CLI
                ON VEN.ID_Cliente = CLI.ID_Cliente
				INNER JOIN TB_Funcionario AS FUN
				ON VEN.ID_Funcionario = FUN.ID_Funcionario
                INNER JOIN TB_ItemVenda AS ITEM
                ON VEN.ID_Venda = ITEM.ID_Venda
                INNER JOIN TB_Produto as PROD
                ON PROD.ID_Produto = ITEM.ID_Produto
                WHERE VEN.DT_Venda BETWEEN '2021-18-04' AND '2021-15-05'
                GROUP BY VEN.ID_Venda, VEN.DT_Venda, CLI.NM_Cliente, VEN.VL_TaxaEntrega, FUN.NM_Funcionario
                ORDER BY VEN.ID_Venda ASC

SELECT 
                VEN.ID_Venda, 
                VEN.DT_Venda, 
                CLI.NM_Cliente, 
				FUN.NM_Funcionario, 
				string_agg(PROD.NM_Produto, ',  ') as NM_Produtos, 
                SUM(ITEM.QTDE_ItemVenda * PROD.PR_Unitario ) + VEN.VL_TaxaEntrega AS VL_Total 
                FROM TB_Venda AS VEN 
                INNER JOIN TB_Cliente as CLI 
                ON VEN.ID_Cliente = CLI.ID_Cliente 
				INNER JOIN TB_Funcionario AS FUN 
				ON VEN.ID_Funcionario = FUN.ID_Funcionario 
                INNER JOIN TB_ItemVenda AS ITEM 
                ON VEN.ID_Venda = ITEM.ID_Venda 
                INNER JOIN TB_Produto as PROD 
                ON PROD.ID_Produto = ITEM.ID_Produto 
                GROUP BY VEN.ID_Venda, VEN.DT_Venda, CLI.NM_Cliente, VEN.VL_TaxaEntrega, FUN.NM_Funcionario 
                ORDER BY VEN.ID_Venda ASC