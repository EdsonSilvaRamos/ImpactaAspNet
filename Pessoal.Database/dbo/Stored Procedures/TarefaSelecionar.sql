CREATE PROCEDURE [dbo].[TarefaSelecionar]
	@id int = null

AS

SELECT [Id]
      ,[Nome]
      ,[Prioridade]
      ,[Concluida]
      ,[Observacoes]
  FROM [dbo].[Tarefa]
WHERE id = ISNULL(@id, Id)
ORDER BY Concluida, Prioridade


