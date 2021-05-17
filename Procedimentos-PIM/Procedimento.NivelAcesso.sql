-- Procedimentos tabela lote

-- Procedimento Mostrar

CREATE PROC spmostrar_nivel_acesso
AS
SELECT ALL
ID_NivelAcesso,
DS_NivelAcesso
FROM TB_NivelAcesso
ORDER BY ID_NivelAcesso ASC
GO

 -- Procedimento buscar  nome
 
CREATE PROC spbuscar_nome_nivel_acesso
@textobuscar VARCHAR (10)
AS SELECT
ID_NivelAcesso,
DS_NivelAcesso
FROM TB_NivelAcesso WHERE DS_NivelAcesso LIKE @textobuscar + '%' 


 -- Procedimento inserir

CREATE PROC spinserir_nivel_acesso
@ID_NivelAcesso INT OUTPUT,
@DS_NivelAcesso INT
AS INSERT INTO TB_NivelAcesso (DS_NivelAcesso)
VALUES (@DS_NivelAcesso)
GO

-- Procedimento editar 

CREATE PROC speditar_nivel_acesso
@ID_NivelAcesso INT,
@DS_NivelAcesso VARCHAR (10)
AS
UPDATE TB_NivelAcesso SET
DS_NivelAcesso = @DS_NivelAcesso
WHERE ID_NivelAcesso = @ID_NivelAcesso
GO


-- Procedimento deletar

CREATE PROC spdeletar_nivel_acesso
@ID_NivelAcesso INT
AS 
DELETE FROM TB_NivelAcesso WHERE
ID_NivelAcesso = @ID_NivelAcesso
GO