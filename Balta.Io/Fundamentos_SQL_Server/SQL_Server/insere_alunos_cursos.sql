SELECT * FROM [Course]
SELECT * FROM [Student]
SELECT * FROM [StudentCourse]

SELECT NEWID()

INSERT INTO [Student] 
VALUES (
    '02ee4bdf-4e21-49d8-b1c1-67ae40bcb8fc',
    'Pablo Leite',
    'pablo@gmail.com',
    '12345678901',
    '1234456',
    NULL,
    GETDATE()
)

INSERT INTO [StudentCourse]
VALUES(
    '5c33664e-e717-9a7d-1240-58eb00000000',
    '02ee4bdf-4e21-49d8-b1c1-67ae40bcb8fc',
    50,
    0,
    '2020-01-13 12:35:54',
    GETDATE()
)