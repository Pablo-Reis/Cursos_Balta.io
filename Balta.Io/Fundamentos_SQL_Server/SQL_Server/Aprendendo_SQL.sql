USE [Curso]

-- Query para dropar um banco
USE [master];

DECLARE @kill varchar(8000) = '';  
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('Teste')

EXEC(@kill);

DROP DATABASE [Teste]
/*******************************************************/

CREATE TABLE [Aluno] (
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Nascimento] DATETIME,
    [Active] BIT
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id])
)
GO
DROP TABLE [Aluno]

CREATE TABLE [Curso] (
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,
    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId])  
    REFERENCES [Categoria]([Id])
)
GO
DROP TABLE [Curso]

CREATE TABLE [ProgressoCurso] (
    [AlunoId] INT NOT NULL,
    [CursoID] INT NOT NULL,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE()),

    --Chave composta, utilizada para verificar dois campos (ou mais) ao mesmo tempo
    CONSTRAINT [PK_ProgressoCurso] PRIMARY KEY([AlunoId], [CursoID])
)
GO
DROP TABLE [ProgressoCurso]

CREATE TABLE [Curso] (
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    
    CONSTRAINT [PK_Curso] PRIMARY KEY([Id])
)
GO
DROP TABLE [Curso]

CREATE TABLE [Categoria] (
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    
    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
)
GO
DROP TABLE [Categoria]

--CRIAÇÃO DE INDEX - São utilizados para campos que são pesquisados de forma massiva.
CREATE INDEX [IX_Aluno_Email] ON [Aluno]([Email])
DROP INDEX [IX_Aluno_Email] ON [Aluno]