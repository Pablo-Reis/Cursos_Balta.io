SELECT
    [CR].Id,
    [CR].[Nome],
    [CR].[CategoriaId],
    [CT].[Id] AS [Categoria],
    [CT].[Nome]
FROM
    [Curso] CR
    INNER JOIN
        [Categoria] CT
    ON
        [CR].[CategoriaId] = [CT].[Id]