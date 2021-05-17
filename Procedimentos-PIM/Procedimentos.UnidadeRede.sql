-- Procedimentos tabela unidade rede

-- Procedimento Mostrar

CREATE PROC spmostrar_unidade_rede
AS
SELECT ALL
ID_UnidadeRede,
DS_UnidadeRede,
FORMAT(VL_GastoCompra, 'N2') AS VL_GastoCompra,
FORMAT(VL_LucroVenda, 'N2') AS VL_LucroVenda 
FROM TB_UnidadeRede
WHERE Ativo = 1
ORDER BY ID_UnidadeRede ASC
GO

 -- Procedimento buscar  nome
 
CREATE PROC spbuscar_nome_unidade_rede
@textobuscar VARCHAR (10)
AS SELECT
ID_UnidadeRede,
DS_UnidadeRede,
FORMAT(VL_GastoCompra, 'N2') AS VL_GastoCompra,
FORMAT(VL_LucroVenda, 'N2') AS VL_LucroVenda 
FROM TB_UnidadeRede 
WHERE Ativo = 1
AND DS_UnidadeRede LIKE @textobuscar + '%' 


 -- Procedimento inserir

CREATE PROC spinserir_unidade_rede
@ID_UnidadeRede INT OUTPUT,
@DS_UnidadeRede VARCHAR(50),
@VL_GastoCompra DECIMAL(10,2),
@VL_LucroVenda DECIMAL(10,2)
AS 
INSERT INTO TB_UnidadeRede (
DS_UnidadeRede,
VL_GastoCompra,
VL_LucroVenda,
Ativo)
VALUES (
@DS_UnidadeRede,
@VL_GastoCompra,
@VL_LucroVenda,
1);
GO

-- Procedimento editar 

CREATE PROC speditar_unidade_rede
@ID_UnidadeRede INT,
@DS_UnidadeRede VARCHAR(50)
AS
UPDATE TB_UnidadeRede SET
DS_UnidadeRede = @DS_UnidadeRede
WHERE ID_UnidadeRede = @ID_UnidadeRede
GO


-- Procedimento deletar

CREATE PROC spdeletar_unidade_rede
@ID_UnidadeRede INT
AS 
UPDATE TB_UnidadeRede SET
Ativo = 0
WHERE ID_UnidadeRede = @ID_UnidadeRede
GO


CREATE PROC spcarrega_valores_unidaderede
@ID_UnidadeRede INT,
@VL_GastoCompra DECIMAL(10,2),
@VL_LucroVenda DECIMAL(10,2)
AS
UPDATE TB_UnidadeRede SET
VL_GastoCompra = @VL_GastoCompra,
VL_LucroVenda = @VL_LucroVenda
WHERE ID_UnidadeRede = @ID_UnidadeRede
GO