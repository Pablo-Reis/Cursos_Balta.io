CREATE OR ALTER PROCEDURE spStudentProgress (
    @StudentId UNIQUEIDENTIFIER
)
AS
    SELECT
        [Student].[Name],
        [Course].[Title],
        [StudentCourse].[Progress],
        [StudentCourse].[LastUpdateDate]
    FROM
        [StudentCourse]
        INNER JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]
        INNER JOIN [Course] ON [StudentCourse].[CourseId] = [Course].[Id]
    WHERE
        [StudentCourse].[StudentId] = @StudentId
        AND [StudentCourse].[Progress] < 100