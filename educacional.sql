USE EDUCACIONAL
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME LIKE 'STUDENTSUBJECT')
	DROP TABLE [STUDENTSUBJECT]
GO
IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME LIKE 'STUDENT')
	DROP TABLE [STUDENT]
GO
IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME LIKE 'SUBJECT')
	DROP TABLE [SUBJECT]
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME LIKE 'USER')
	DROP TABLE [USER]
GO

CREATE TABLE STUDENT
(
ID INT UNIQUE NOT NULL IDENTITY
,NAME VARCHAR(100) NOT NULL
,CONSTRAINT PK_STUDENT PRIMARY KEY(ID)
)

CREATE TABLE [SUBJECT]
(
ID INT UNIQUE NOT NULL IDENTITY
,NAME VARCHAR(100) NOT NULL
,CONSTRAINT PK_SUBJECT PRIMARY KEY(ID)
)

CREATE TABLE [STUDENTSUBJECT]
(
ID INT UNIQUE NOT NULL IDENTITY
,STUDENTID INT NOT NULL
,SUBJECTID INT NOT NULL
,GRADE DECIMAL(4,2)
,FOREIGN KEY (STUDENTID) REFERENCES STUDENT(ID)
,FOREIGN KEY (SUBJECTID) REFERENCES [SUBJECT](ID)
,CONSTRAINT PK_USER_SUJECT PRIMARY KEY(ID)
)

CREATE TABLE [USER]
(
ID INT UNIQUE NOT NULL IDENTITY
,USERNAME VARCHAR(100) NOT NULL
,PASSWORD INT NOT NULL
,CONSTRAINT PK_USER PRIMARY KEY(ID)
)

INSERT INTO [USER] VALUES ('candidato-evolucional',123456)
GO

IF EXISTS(SELECT 1 FROM SYSOBJECTS WHERE NAME LIKE 'STUDENREPORT')
	DROP PROCEDURE [STUDENREPORT]
GO

CREATE PROCEDURE STUDENREPORT
AS
BEGIN
DECLARE @COLUMNS NVARCHAR(MAX)
SET @COLUMNS = N'';
SELECT @COLUMNS += N', P.' + QUOTENAME(NAME)
  FROM (SELECT NAME FROM SUBJECT
) AS X ; 

SELECT @COLUMNS += N', P.[Average]'

DECLARE @COUNTSUBJECTS INT
SELECT @COUNTSUBJECTS = COUNT(*) FROM [SUBJECT]

DECLARE @SQLSTATEMENT NVARCHAR(MAX)
SET @SQLSTATEMENT = N'SELECT * FROM (
SELECT [STUDENT].NAME AS STUDENT,[SUBJECT].NAME AS SUBJECT,[STUDENTSUBJECT].GRADE  FROM STUDENT
	INNER JOIN [STUDENTSUBJECT] ON [STUDENT].ID = [STUDENTSUBJECT].STUDENTID 
	INNER JOIN [SUBJECT] ON [SUBJECT].ID = [STUDENTSUBJECT].SUBJECTID	
	UNION
SELECT STUDENT.NAME, ''Average'' AS SUBJECT, CAST(SUM(GRADE)/' + cast(@COUNTSUBJECTS as varchar(10)) + ' AS decimal(4,2)) AS GRADE  FROM [STUDENT]
INNER JOIN [STUDENTSUBJECT] ON [STUDENT].ID = [STUDENTSUBJECT].STUDENTID
INNER JOIN [SUBJECT] ON [SUBJECT].ID = [STUDENTSUBJECT].SUBJECTID
GROUP BY STUDENT.NAME

	) AS RESULT
PIVOT(
 SUM([GRADE])
  FOR [SUBJECT]
  IN (
  '
  + STUFF(REPLACE(@COLUMNS, ', P.[', ',['), 1, 1, '')
  + '
  )
) AS PIVOTABLE'

EXEC (@SQLSTATEMENT)
END