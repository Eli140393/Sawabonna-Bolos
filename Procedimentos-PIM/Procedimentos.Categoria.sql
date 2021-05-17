-- Procedimentos Tabela categoria

-- Procedimento Mostrar
exec spmostrar_categoria
CREATE PROC spmostrar_categoria
AS
SELECT TOP 200 
ID_Categoria,
NM_Categoria,
DS_categoria FROM TB_Categoria
ORDER BY ID_Categoria ASC
GO

-- Procedimento Buscar por nome

CREATE PROC spbuscar_categoria
@textobuscar VARCHAR (50)
AS SELECT 
ID_Categoria, 
NM_Categoria,
DS_Categoria FROM TB_Categoria
WHERE NM_Categoria LIKE
@textobuscar + '%'
GO

-- Procedimento inserir categoria

CREATE PROC spinserir_categoria
@ID_Categoria INT OUTPUT,
@NM_Categoria VARCHAR (50),
@DS_Categoria VARCHAR (150)
AS
INSERT INTO TB_Categoria (NM_Categoria,DS_Categoria)
VALUES (@NM_Categoria,@DS_Categoria)
GO

-- Procedimento editar categoria

CREATE PROC speditar_categoria
@ID_Categoria INT,
@NM_Categoria VARCHAR (50),
@DS_Categoria VARCHAR (150)
AS
UPDATE TB_Categoria SET NM_Categoria = @NM_Categoria,
DS_Categoria = @DS_Categoria
WHERE ID_Categoria = @ID_Categoria
GO

-- Procedimento deletar categoria

CREATE PROC spdeletar_categoria
@ID_Categoria INT
AS
DELETE FROM TB_Categoria WHERE
ID_Categoria = @ID_Categoria
GO