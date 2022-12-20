CREATE OR ALTER VIEW vwCarrers AS
    SELECT
        [Career].[Id],
        [Career].[Title],
        [Career].[Url],
        COUNT([Id]) AS [Courses]
    FROM
        [Career]
        INNER JOIN [CareerItem] ON [Career].[Id] = [CareerItem].[CareerId]
    GROUP BY
        [Career].[Id],
        [Career].[Title],
        [Career].[Url]