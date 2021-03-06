USE [STUDENTMGMT]
GO
/****** Object:  StoredProcedure [dbo].[MGMTSP]    Script Date: 6/9/2022 10:48:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   PROCEDURE [dbo].[MGMTSP] 
@StudentID INT = NULL,
@FullName NVARCHAR(55) = NULL,
@PhoneNumber NVARCHAR(55) = NULL,
@Email NVARCHAR(55) = NULL ,
@Address NVARCHAR(55) = NULL,
@DateOfBirth DATE = NULL, 
@FathersName NVARCHAR (55) = NULL,
@MothersName NVARCHAR(55) = NULL,
@CourseName NVARCHAR(55) =  NULL,
@Id INT = NULL,
@Flag NVARCHAR(55) = NULL,
@AName NVARCHAR(55) = NULL,
@Pass NVARCHAR(55) = NULL,
@Sub1 NVARCHAR(55)=NULL,
@Sub2 NVARCHAR(55)=NULL,
@Sub3 NVARCHAR(55)=NULL,
@Sub4 NVARCHAR(55)=NULL,
@StdRegId INT = NULL,
@CourseId INT = NULL,
@Img NVARCHAR(255) = NULL,
@Fee FLOAT = NULL,
@TotalFee FLOAT = NULL

AS 
BEGIN

IF @Flag = 'FeeLoad'
BEGIN
SELECT StudentId,StudentName,TotalFee,FeeDeposited,
(TotalFee - FeeDeposited) AS RemainingFee
FROM Fee WHERE @Id = StudentId
END

IF @Flag = 'CheckUser'
BEGIN
	SELECT * FROM Registration WHERE StudentId = @Id AND FullName = @AName
END

IF @Flag = 'Fee'
BEGIN
	INSERT INTO Fee VALUES(@Id,@AName,@CourseId,@TotalFee,@Fee)
END

IF @Flag = 'PasswordUser'
BEGIN
UPDATE UserLogin
SET UserPass=@Pass 
WHERE Id=1
END

IF @Flag = 'PasswordTUser'
BEGIN
UPDATE TeacherLogin
SET TeacherPass=@Pass 
WHERE Id=1
END


IF @Flag = 'TUserCheck'
BEGIN
	SELECT * FROM TeacherLogin WHERE @AName = TeacherName AND @Pass = TeacherPass
END

IF @Flag = 'UserCheck'
BEGIN
	SELECT * FROM UserLogin WHERE @AName = UserName AND @Pass = UserPass
END

IF @Flag = 'Attendance'
BEGIN
	SELECT * FROM Registration WHERE CourseName = @CourseId
END

IF @Flag = 'ViewTeacher'
BEGIN
	SELECT T.FullName,C.CourseName,S.SubjectName  
	FROM Teachers AS T
	INNER JOIN AssignTeacher AS AT ON T.Id = AT.TeacherId
	INNER JOIN Course as C on C.Id = AT.CourseId 
	INNER JOIN Subjects as S ON s.Id = AT.SubjectId
END

IF @Flag = 'AssignTeacher'
BEGIN
	INSERT INTO AssignTeacher VALUES(@Id, @CourseId, @StdRegId)
END

IF @Flag = 'DropDownBindTeachers'
BEGIN
	SELECT * FROM Teachers
END

IF @Flag = 'InsertTeacher'
BEGIN
	INSERT INTO Teachers VALUES(@FullName,@Email,@PhoneNumber,@Address)
END

IF @Flag = 'DeleteCourse'
BEGIN
	DELETE FROM Course WHERE @Id =Id
END

IF @Flag = 'CheckUser'
BEGIN	
	SELECT * FROM Registration WHERE @StudentID=StudentId AND @AName=CourseName
END

IF @Flag = 'DropDownBindSubject'
BEGIN
SELECT *
FROM Subjects
WHERE @CourseId = CourseId 
END

IF @Flag = 'FinalResult'
BEGIN
SELECT Mark1, Mark2, Mark3, Mark4,
(Mark1+Mark2+Mark3+Mark4) AS Total, 
((Mark1+Mark2+Mark3+Mark4)/4) AS Per
INTO #tempresult
FROM Result 
WHERE StdRegId= @StdRegId AND CourseId=@CourseId
SELECT *, 
CASE WHEN Per >= 80 THEN 'Distinction'
WHEN per <80 AND per >= 60 THEN 'First Division'
WHEN per <60 AND per >= 40 THEN 'Second Division'
ELSE 'fail'
END AS result
FROM #tempresult
END

IF @Flag = 'ResultView'
BEGIN
SELECT * FROM Result 
WHERE @Id = StdRegId AND @AName = CourseId
END

IF @Flag = 'ResultInsert'
BEGIN
INSERT INTO Result VALUES(@Sub1, @Sub2, @Sub3, @Sub4, @AName,@Id)
END

IF @Flag='ShowSubject'
BEGIN
	SELECT * FROM Subjects WHERE @AName=CourseId
END

IF @Flag = 'Subject'
BEGIN
		INSERT INTO Subjects VALUES(@Sub1,@AName)
		INSERT INTO Subjects VALUES(@Sub2,@AName)
		INSERT INTO Subjects VALUES(@Sub3,@AName)
		INSERT INTO Subjects VALUES(@Sub4,@AName)	
END

IF @Flag = 'CourseInsert'
BEGIN
INSERT INTO Course VALUES(@AName)
END

IF @Flag = 'DropDownBind'
BEGIN
SELECT * FROM Course
END

IF @Flag = 'Password'
BEGIN
UPDATE AdminLogin
SET Pass=@Pass 
WHERE Id=1
END

IF @Flag = 'AdminCheck'
BEGIN
SELECT * FROM AdminLogin 
WHERE @AName=AName AND @Pass=Pass
END

IF @Flag = 'Insert'
BEGIN
INSERT INTO Registration
(StudentId,
FullName,
PhoneNumber,
Email,
Address,
DateOfBirth,
FathersName,
MothersName,
CourseName,
ImgLoc)
 VALUES(@StudentId, @FullName, @PhoneNumber, @Email, @Address, @DateOfBirth, @FathersName, @MothersName, @CourseName, @Img)
END


IF @Flag = 'Update'
BEGIN
UPDATE Registration
SET FullName = @FullName,
PhoneNumber= @PhoneNumber,
Email = @Email,
Address = @Address,
DateOfBirth = @DateOfBirth,
FathersName = @FathersName,
MothersName = @MothersName
WHERE  StudentID = @StudentID
END


IF @Flag = 'Select'
BEGIN
SELECT * FROM   Registration
END
      
ELSE IF @Flag = 'Delete'
BEGIN
DELETE FROM Registration
WHERE  StudentId = @StudentId
END
END