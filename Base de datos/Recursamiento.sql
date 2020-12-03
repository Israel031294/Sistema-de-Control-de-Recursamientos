CREATE DATABASE RECURSAMIENTO
USE RECURSAMIENTO

CREATE TABLE REGISTRO(
UserBoleta NUMERIC(10),
Contraseña NVARCHAR(15),
CONSTRAINT REGISTRO_UserBoleta_pk PRIMARY KEY (UserBoleta))

CREATE TABLE REGISTRO_ADMIN(
Usuario NVARCHAR(10),
Contraseña NVARCHAR(15),
CONSTRAINT REGISTRO_ADMIN_Usuario_pk PRIMARY KEY (Usuario))

CREATE TABLE UNIDADES(
Materia VARCHAR(35),
Semestre VARCHAR(40),
CONSTRAINT MATERIA_Materia_pk PRIMARY KEY (Materia))

CREATE TABLE MATERIA(
ID_Materia INT,
Descripcion VARCHAR(35)
CONSTRAINT MATERIA_ID_Materia_pk PRIMARY KEY (ID_Materia),
CONSTRAINT MATERIA_Descripcion_fk Foreign key (Descripcion) References UNIDADES(Materia))

CREATE TABLE GRUPO(
ID_Grupo INT,
ID_Materia INT,
Grupo NVARCHAR(5),
Salon NUMERIC(5),
Horario VARCHAR(10),
Ocupabilidad NUMERIC(2),
Fech_Inic DATE,
Fech_Fin DATE,
CONSTRAINT GRUPO_ID_Grupo_pk PRIMARY KEY (ID_Grupo),
CONSTRAINT GRUPO_ID_Materia_fk Foreign key (ID_Materia) References MATERIA(ID_Materia))

CREATE TABLE PROFESOR(
ID_Prof INT,
Nombre VARCHAR(50),
Ape_Pat VARCHAR(50),
Ape_Mat VARCHAR(50),
ID_Materia INT,
ID_Grupo INT,
CONSTRAINT PROFESOR_ID_Prof_pk PRIMARY KEY (ID_Prof),
CONSTRAINT PROFESOR_ID_Materia_fk Foreign key (ID_Materia) References MATERIA(ID_Materia),
CONSTRAINT PROFESOR_ID_Grupo_fk Foreign key (ID_Grupo) References GRUPO(ID_Grupo))

CREATE TABLE ALUMNO(
ID_Alum INT,
Boleta NUMERIC(10),
Nombre VARCHAR(50),
Ape_Pat VARCHAR(50),
Ape_Mat VARCHAR(50),
Carrera VARCHAR(15),
Grupo_Actual NVARCHAR(5),
ID_Materia INT,
ID_Grupo INT,
ID_Prof INT,
CONSTRAINT ALUMNO_ID_Alum_pk PRIMARY KEY (ID_Alum),
CONSTRAINT ALUMNO_Boleta_fk Foreign key (Boleta) References REGISTRO(UserBoleta),
CONSTRAINT ALUMNO_ID_Materia_fk Foreign key (ID_Materia) References MATERIA(ID_Materia),
CONSTRAINT ALUMNO_ID_Grupo_fk Foreign key (ID_Grupo) References GRUPO(ID_Grupo),
CONSTRAINT ALUMNO_ID_Prof_fk Foreign key (ID_Prof) References PROFESOR(ID_Prof))

/*STORE REGISTRO*/
CREATE PROCEDURE dbo.InsertarRegistro
(
@Usuario NUMERIC(10), @Contraseña NVARCHAR(15)
)
AS

IF exists (Select UserBoleta From REGISTRO Where UserBoleta = @Usuario)
 BEGIN
   UPDATE REGISTRO
   SET Contraseña = @Contraseña
   Where UserBoleta = @Usuario
 END
 
ELSE
 BEGIN
   INSERT INTO REGISTRO(UserBoleta, Contraseña)
   VALUES (@Usuario, @Contraseña)
 END
 
 /*STORE MATERIA*/
CREATE PROCEDURE dbo.InsertarMateria
(
@Id INT, @Descripcion VARCHAR(35)
)
AS

IF exists (Select ID_Materia From MATERIA Where ID_Materia = @Id)
 BEGIN
   UPDATE MATERIA
   SET Descripcion = @Descripcion
   Where ID_Materia = @Id
 END
 
ELSE
 BEGIN
   INSERT INTO MATERIA(ID_Materia, Descripcion)
   VALUES (@Id, @Descripcion)
 END
 
/* DROP PROC dbo.InsertarMateria*/
 
/*STORE GRUPO*/
CREATE PROCEDURE dbo.InsertarGrupo
(
@IdG INT, @IdM INT, @Grupo NVARCHAR(5), @Salon NUMERIC(5), @Horario VARCHAR(10), @Ocup NUMERIC(2), @Inicio DATE, @Fin DATE
)
AS

IF exists (Select ID_Grupo From GRUPO Where ID_Grupo = @IdG)
 BEGIN
   UPDATE GRUPO
   SET Grupo = @Grupo, Salon = @Salon, Horario = @Horario, Ocupabilidad = @Ocup, Fech_Inic = @Inicio, Fech_Fin = @Fin
   Where ID_Grupo = @IdG
 END
 
ELSE
 BEGIN
   INSERT INTO GRUPO(ID_Grupo, ID_Materia, Grupo, Salon, Horario, Ocupabilidad, Fech_Inic, Fech_Fin)
   VALUES (@IdG, @IdM, @Grupo, @Salon,@Horario, @Ocup, @Inicio, @Fin)
 END
 
 /*DROP PROC dbo.InsertarGrupo*/
 
/*STORE PROFESOR*/
CREATE PROCEDURE dbo.InsertarProfesor
(
@IdP INT, @Nombre VARCHAR(50), @ApePat VARCHAR(50), @ApeMat VARCHAR(50), @IdG INT, @IdM INT
)
AS

IF exists (Select ID_Prof From PROFESOR Where ID_Prof = @IdP)
 BEGIN
   UPDATE PROFESOR
   SET Nombre = @Nombre, Ape_Pat = @ApePat, Ape_Mat = @ApeMat, ID_Materia = @IdM, ID_Grupo = @IdG
   Where ID_Prof = @IdP
 END
 
ELSE
 BEGIN
   INSERT INTO PROFESOR(ID_Prof, Nombre, Ape_Pat, Ape_Mat, ID_Materia, ID_Grupo)
   VALUES (@IdP, @Nombre, @ApePat, @ApeMat, @IdM, @IdG)
 END
 
/*STORE ALUMNO*/
CREATE PROCEDURE dbo.InsertarAlumno
(
@IdA INT, @Boleta NUMERIC(10),@Nombre VARCHAR(50), @ApePat VARCHAR(50), @ApeMat VARCHAR(50), @Carrera VARCHAR(15), @GrupoAct NVARCHAR(5), @IdG INT, @IdM INT, @IdP INT
)
AS

IF exists (Select ID_Alum From ALUMNO Where ID_Alum = @IdA)
 BEGIN
   UPDATE ALUMNO
   SET Boleta = @Boleta, Nombre = @Nombre, Ape_Pat = @ApePat, Ape_Mat = @ApeMat, Carrera = @Carrera, Grupo_Actual = @GrupoAct, ID_Materia = @IdM, ID_Grupo = @IdG, ID_Prof = @IdP
   Where ID_Alum = @IdA
 END
 
ELSE
 BEGIN
   INSERT INTO ALUMNO(ID_Alum, Boleta, Nombre, Ape_Pat, Ape_Mat, Carrera, Grupo_Actual, ID_Materia, ID_Grupo, ID_Prof)
   VALUES (@IdA, @Boleta, @Nombre, @ApePat, @ApeMat, @Carrera, @GrupoAct, @IdM, @IdG, @IdP)
 END
 

/*STORE CONSULTA*/
CREATE PROCEDURE dbo.Consultagrupo
(
@Descripcion VARCHAR(35)
)
AS
 BEGIN
   SELECT GRUPO.ID_Grupo, MATERIA.ID_Materia, MATERIA.Descripcion, GRUPO.Salon, GRUPO.Horario, GRUPO.Ocupabilidad, GRUPO.Fech_Inic, GRUPO.Fech_Fin
   FROM GRUPO
   INNER JOIN MATERIA
   ON GRUPO.ID_Materia = MATERIA.ID_Materia
   WHERE MATERIA.Descripcion = @Descripcion
   ORDER BY GRUPO.ID_Grupo
 END

EXEC dbo.Consultagrupo @Descripcion = 'ALGEBRA'

/*STORE CONSULTA GRUPOS*/
CREATE PROCEDURE dbo.ConsultaInscripcion
(
@Horario VARCHAR(10)
)
AS
 BEGIN
   SELECT PROFESOR.ID_Prof, (PROFESOR.Nombre + ' ' + PROFESOR.Ape_Pat + ' '+ PROFESOR.Ape_Mat) AS 'Profesor', GRUPO.ID_Grupo, GRUPO.Grupo, GRUPO.Salon, MATERIA.ID_Materia, MATERIA.Descripcion
   FROM PROFESOR
   INNER JOIN GRUPO
   ON PROFESOR.ID_Grupo = GRUPO.ID_Grupo
   INNER JOIN MATERIA
   ON PROFESOR.ID_Materia = MATERIA.ID_Materia
   WHERE GRUPO.Horario = @Horario
   ORDER BY GRUPO.Grupo
 END
 
 exec dbo.ConsultaInscripcion @Horario = 'SEMANAL'
 
 /*STORE CONSULTA ALUMNO*/
CREATE PROCEDURE dbo.ConsultaAlumno
(
@Boleta NUMERIC(10)
)
AS
 BEGIN
   SELECT ALUMNO.Boleta, ALUMNO.ID_Alum, (ALUMNO.Nombre + ' ' + ALUMNO.Ape_Pat + ' ' + ALUMNO.Ape_Mat) AS Alumno, MATERIA.Descripcion, (PROFESOR.Nombre + ' ' + PROFESOR.Ape_Pat + ' ' + PROFESOR.Ape_Mat) AS Profesor, GRUPO.Horario
   FROM ALUMNO
   INNER JOIN GRUPO
   ON ALUMNO.ID_Grupo = GRUPO.ID_Grupo
   INNER JOIN MATERIA
   ON ALUMNO.ID_Materia = MATERIA.ID_Materia
   INNER JOIN PROFESOR
   ON ALUMNO.ID_Prof = PROFESOR.ID_Prof
   WHERE ALUMNO.Boleta = @Boleta
   ORDER BY ALUMNO.ID_Alum
 END
 
EXEC dbo.ConsultaAlumno @Boleta = 2011130858

SELECT COUNT(*)
FROM MATERIA
WHERE Descripcion = 'QUIMICA I'

SELECT ID_Materia
FROM MATERIA
WHERE Descripcion = 'ALGEBRA'

SELECT ID_Materia
FROM MATERIA
WHERE Descripcion = 'ALGEBRA'

SELECT Descripcion
FROM MATERIA
WHERE ID_Materia = 1
                           
SELECT COUNT (ID_Prof) + 1
FROM PROFESOR

SELECT PROFESOR.ID_Prof, (PROFESOR.Nombre + ' ' + PROFESOR.Ape_Pat + ' '+ PROFESOR.Ape_Mat) AS 'Profesor', GRUPO.ID_Grupo, GRUPO.Grupo, GRUPO.Salon, MATERIA.ID_Materia, MATERIA.Descripcion
FROM PROFESOR
INNER JOIN GRUPO
ON PROFESOR.ID_Grupo = GRUPO.ID_Grupo
INNER JOIN MATERIA
ON PROFESOR.ID_Materia = MATERIA.ID_Materia
WHERE MATERIA.DESCRIPCION='ANALISIS VECTORIAL'
ORDER BY GRUPO.Grupo


SELECT COUNT (ID_Prof)
FROM PROFESOR
WHERE ID_Materia = 1 and ID_Grupo = 1

SELECT *
FROM PROFESOR

SELECT COUNT (ID_Grupo)
FROM GRUPO
WHERE Grupo = '1IX3' OR (Salon = 45 AND Horario = 'SABATINO')

SELECT COUNT (ID_Alum)
                           FROM ALUMNO
                           WHERE ID_Materia = 1 or ID_Grupo = 2
SELECT *
FROM ALUMNO   

SELECT COUNT (Boleta)
                           FROM ALUMNO
                           WHERE Boleta = 2011130858
                           
SELECT ALUMNO.Boleta, ALUMNO.ID_Alum, (ALUMNO.Nombre + ' ' + ALUMNO.Ape_Pat + ' ' + ALUMNO.Ape_Mat) AS Alumno, MATERIA.Descripcion, (PROFESOR.Nombre + ' ' + PROFESOR.Ape_Pat + ' ' + PROFESOR.Ape_Mat) AS Profesor, GRUPO.Horario
FROM ALUMNO
INNER JOIN GRUPO
ON ALUMNO.ID_Grupo = GRUPO.ID_Grupo
INNER JOIN MATERIA
ON ALUMNO.ID_Materia = MATERIA.ID_Materia
INNER JOIN PROFESOR
ON ALUMNO.ID_Prof = PROFESOR.ID_Prof
WHERE ALUMNO.Boleta = 2014630140
ORDER BY ALUMNO.ID_Alum


SELECT Grupo, Salon, Horario, Ocupabilidad, Fech_Inic AS 'Inicio Curso', Fech_Fin AS 'Fin Curso'
FROM GRUPO

SELECT Nombre, Ape_Pat AS 'Apellido Paterno', Ape_Mat AS 'Apellido Materno'
FROM PROFESOR

SELECT Nombre, Ape_Pat AS 'Apellido Paterno', Ape_Mat AS 'Apellido Materno', Carrera, Grupo_Actual AS 'Grupo Actual'
FROM ALUMNO

SELECT ALUMNO.Boleta, ALUMNO.ID_Alum, (ALUMNO.Nombre + ' ' + ALUMNO.Ape_Pat + ' ' + ALUMNO.Ape_Mat) AS Alumno, MATERIA.Descripcion, (PROFESOR.Nombre + ' ' + PROFESOR.Ape_Pat + ' ' + PROFESOR.Ape_Mat) AS Profesor, GRUPO.Horario
FROM ALUMNO
INNER JOIN GRUPO
ON ALUMNO.ID_Grupo = GRUPO.ID_Grupo
INNER JOIN MATERIA
ON ALUMNO.ID_Materia = MATERIA.ID_Materia
INNER JOIN PROFESOR
ON ALUMNO.ID_Prof = PROFESOR.ID_Prof
WHERE ALUMNO.Boleta = 2014640140
ORDER BY ALUMNO.ID_Alum


SELECT PROFESOR.ID_Prof, (PROFESOR.Nombre + ' ' + PROFESOR.Ape_Pat + ' '+ PROFESOR.Ape_Mat) AS 'Profesor', GRUPO.ID_Grupo, GRUPO.Grupo, GRUPO.Salon, MATERIA.ID_Materia, MATERIA.Descripcion
FROM PROFESOR
INNER JOIN GRUPO
ON PROFESOR.ID_Grupo = GRUPO.ID_Grupo
INNER JOIN MATERIA
ON PROFESOR.ID_Materia = MATERIA.ID_Materia
WHERE MATERIA.DESCRIPCION='ANALISIS VECTORIAL'
ORDER BY GRUPO.Grupo


SELECT ID_Materia from MATERIA WHERE Descripcion= 'ANALISIS VECTORIAL'

SELECT ID_Prof from PROFESOR WHERE ID_Materia=7

SELECT ID_Grupo from GRUPO where ID_Materia=7 


create procedure id_profesor
@ID_Materia int
as
SELECT ID_Prof from PROFESOR WHERE ID_Materia=@ID_Materia


select * from ALUMNO

ALTER TABLE ALUMNO DROP COLUMN Carrera