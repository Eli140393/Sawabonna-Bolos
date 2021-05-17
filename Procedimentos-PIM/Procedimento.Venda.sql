

-- Procedimento Mostrar
exec spmostrar_venda
CREATE PROC spmostrar_venda
@ID_UnidadeRede INT
AS
SELECT ALL
VEN.ID_UnidadeRede,
UNI.DS_UnidadeRede,
VEN.ID_Venda,
FUN.NM_Funcionario,
CLI.NM_Cliente,
VEN.DT_Venda,
VEN.OBS_Venda,
VEN.DS_TipoPagamento,
FORMAT(VEN.VL_TaxaEntrega, 'N2') AS VL_TaxaEntrega,
FORMAT(VEN.VL_Total, 'N2') AS VL_Total
FROM TB_Venda AS VEN
INNER JOIN TB_Cliente AS CLI
ON VEN.ID_Cliente = CLI.ID_Cliente
INNER JOIN TB_Funcionario AS FUN
ON VEN.ID_Funcionario = FUN.ID_Funcionario
INNER JOIN TB_UnidadeRede AS UNI
ON VEN.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE VEN.ID_UnidadeRede = @ID_UnidadeRede
ORDER BY ID_Venda ASC
GO

 -- Procedimento buscar  data
 
CREATE PROC spbuscar_data_venda
 @DataBuscar DATE,
 @ID_UnidadeRede INT
 AS SELECT
VEN.ID_UnidadeRede,
UNI.DS_UnidadeRede,
VEN.ID_Venda,
FUN.NM_Funcionario,
CLI.NM_Cliente,
VEN.DT_Venda,
VEN.OBS_Venda,
VEN.DS_TipoPagamento,
FORMAT(VEN.VL_TaxaEntrega, 'N2') AS VL_TaxaEntrega,
FORMAT(VEN.VL_Total, 'N2') AS VL_Total
FROM TB_Venda AS VEN
INNER JOIN TB_Cliente AS CLI
ON VEN.ID_Cliente = CLI.ID_Cliente
INNER JOIN TB_Funcionario AS FUN
ON VEN.ID_Funcionario = FUN.ID_Funcionario
INNER JOIN TB_UnidadeRede AS UNI
ON VEN.ID_UnidadeRede = UNI.ID_UnidadeRede
WHERE DT_Venda LIKE @DataBuscar 
AND VEN.ID_UnidadeRede = @ID_UnidadeRede
ORDER BY ID_Venda ASC
GO

 -- Procedimento inserir

CREATE PROC spinserir_venda
@ID_Venda INT OUTPUT,
@ID_Funcionario INT,
@ID_Cliente INT,
@ID_UnidadeRede INT
AS INSERT INTO TB_Venda(
ID_Funcionario,
ID_Cliente,
DT_Venda,
ID_UnidadeRede)
VALUES (
@ID_Funcionario,
@ID_Cliente,
GETDATE(),
@ID_UnidadeRede)
GO

-- Procedimento editar 

CREATE PROC speditar_venda
@ID_Funcionario INT,
@ID_Cliente INT,
@OBS_Venda VARCHAR (50),
@DS_TipoPagamento VARCHAR(20),
@VL_TaxaEntrega DECIMAL (10,2),
@VL_Total DECIMAL (10,2),
@ID_UnidadeRede INT
AS
UPDATE TB_Venda SET
ID_Funcionario = @ID_Funcionario,
ID_Cliente = @ID_Cliente,
DT_Venda = GETDATE(),
OBS_Venda = @OBS_Venda,
DS_TipoPagamento = @DS_TipoPagamento,
VL_TaxaEntrega = @VL_TaxaEntrega,
VL_Total = @VL_Total
WHERE ID_Venda = IDENT_CURRENT  ('TB_Venda')
AND ID_UnidadeRede = @ID_UnidadeRede
GO


-- Procedimento deletar

CREATE PROC spdeletar_venda
@ID_UnidadeRede INT
AS 
DELETE FROM TB_Venda
WHERE ID_Venda = IDENT_CURRENT  ('TB_Venda')
AND ID_UnidadeRede = @ID_UnidadeRede
GO

-- Venda com valor nulo

CREATE PROC spvalidar_venda
AS 
DELETE FROM TB_Venda 
WHERE VL_Total IS NULL
GO