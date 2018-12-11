CREATE PROCEDURE [dbo].[TarefaExcluir]
	@id int 

AS

DELETE [dbo].[Tarefa] WHERE id = @id


