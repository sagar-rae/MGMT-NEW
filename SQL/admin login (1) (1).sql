---ADMINLOGIN---
CREATE TABLE AdminLogin(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
AName NVARCHAR(55) NOT NULL,
Pass NVARCHAR(55) NOT NULL
)
--INSERT---
INSERT INTO AdminLogin VALUES('admin','admin123');

--REGISTRATION---
CREATE TABLE Registration (
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
StudentId INT NOT NULL,
FullName NVARCHAR(555),
PhoneNumber NVARCHAR(50),
Email NVARCHAR(50),
Address NVARCHAR(50),
DateOfBirth DATE,
FathersName NVARCHAR (555),
MothersName NVARCHAR(555), 
CourseName NVARCHAR(55),
ImgLoc NVARCHAR(255) NOT NULL
);

---INSERT-- 
INSERT INTO Registration VALUES (1001,'Bivek khatiwada',9862211600,'linktobivek@gmail.com','Nepal','1997/10/10','Bishnu Khatiwada','Bishnu Maya Khatiwada',1)
INSERT INTO Registration VALUES (1002,'Sagar rai',9810454215,'sagar@gmail.com','Canada','1997/1/10','Ram Hari','Shyam Rai',1)

--COURSE---
CREATE TABLE Course(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
CourseName NVARCHAR(50) NOT NULL
)
--INSERT COURSE---
INSERT INTO Course VALUES ('CSIT')
INSERT INTO Course VALUES ('BIT')
INSERT INTO Course VALUES ('MIT')


---RESULT--
CREATE TABLE Result (
id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
Mark1 FLOAT NOT NULL,
Mark2 FLOAT NOT NULL,
Mark3 FLOAT  NOT NULL,
Mark4 FLOAT NOT NULL,
CourseId NVARCHAR NOT NULL,
StdRegId INT NOT NULL,
)

--SUBJECTS----
CREATE TABLE Subjects(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
SubjectName NVARCHAR(50) NOT NULL,
CourseId NVARCHAR(50) NOT NULL
)


---INSERT INTO SUBJECTS---
INSERT INTO Subjects VALUES ('Digital Logics',1)
INSERT INTO Subjects VALUES('Advanced Database',1)
INSERT INTO Subjects VALUES('Advanced Cyber Security',1)
INSERT INTO Subjects VALUES('Advanced C++',1)
INSERT INTO Subjects VALUES ('Not Digital Logics',2)
INSERT INTO Subjects VALUES('Not Advanced Database',2)
INSERT INTO Subjects VALUES('Not Advanced Cyber Security',2)
INSERT INTO Subjects VALUES('Artificial Intelligence',2)
INSERT INTO Subjects VALUES ('Very Advanced Database',3)
INSERT INTO Subjects VALUES('Very Advanced Digital Logic',3)
INSERT INTO Subjects VALUES('Very Advanced Java',3)
INSERT INTO Subjects VALUES('Very Advanced C++',3)



--TEACHERS --------
CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
FullName NVARCHAR(50) NOT NULL,
Email NVARCHAR(50) NOT NULL,
PhoneNumber NVARCHAR(50) NOT NULL,
Address NVARCHAR(50) NOT NULL
)

-- INSERT TEACHERS ---------
INSERT INTO Teachers VALUES('Rabindra','rabin@gmail.com','9810433818','Kapan')


-- ASSIGN TEACHERS ---------
CREATE TABLE AssignTeacher(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
TeacherId INT NOT NULL,
CourseId INT NOT NULL,
SubjectId INT NOT NULL
)

-- USER LOGIN -----------------
CREATE TABLE UserLogin(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
UserName NVARCHAR(50) NOT NULL,
UserPass NVARCHAR(50) NOT NULL
)

-- USER INSERT ----------------
INSERT INTO UserLogin VALUES('user','user123')

-- TEACHER LOGIN ------------------------
CREATE TABLE TeacherLogin(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
TeacherName NVARCHAR(50) NOT NULL,
TeacherPass NVARCHAR(50) NOT NULL
)

-- TEACHER INSERT ----------------------
INSERT INTO TeacherLogin VALUES('teacher','tuser123')


-- FEE ------------------
CREATE TABLE Fee(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
StudentId INT NOT NULL,
StudentName NVARCHAR(50) NOT NULL,
CourseId NVARCHAR(50) NOT NULL,
TotalFee FLOAT NOT NULL,
FeeDeposited FLOAT NOT NULL
)

drop table Fee

--SELECT----
SELECT * FROM AdminLogin
SELECT * FROM UserLogin
SELECT * FROM TeacherLogin


SELECT * FROM Registration

SELECT * FROM Result
SELECT * FROM Teachers
SELECT * FROM AssignTeacher
SELECT * FROM Course
SELECT * FROM Subjects
SELECT * FROM Fee






---joins---
SELECT T.FullName,C.CourseName,S.SubjectName  
FROM Teachers AS T
INNER JOIN AssignTeacher AS AT ON T.Id = AT.TeacherId
INNER JOIN Course as C on C.Id = AT.CourseId 
INNER JOIN Subjects as S ON s.Id = AT.SubjectId


INSERT INTO AssignTeacher VALUES (2,3,9)

TRUNCATE TABLE REGISTRATION
insert into Registration


SELECT * FROM Registration






select StudentId,StudentName,TotalFee,FeeDeposited,
(TotalFee - FeeDeposited) AS RemainingFee
from Fee

 