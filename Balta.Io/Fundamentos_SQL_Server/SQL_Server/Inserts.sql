USE [Cursos]

INSERT INTO [Categoria]([Nome]) VALUES('Backend')
INSERT INTO [Categoria]([Nome]) VALUES('Frontend')
INSERT INTO [Categoria]([Nome]) VALUES('Angular')
 
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Fundamentos de C#', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Fundamentos de POO', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Angular', 2)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES ('Flutter', 3)