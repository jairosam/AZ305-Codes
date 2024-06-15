Create table Course
(
	CourseID int,
	ExamImage varchar(1000),
	CourseName varchar(1000),
	Rating numeric(2,1)
)

Insert Into Course(CourseID,ExamImage,CourseName,Rating) Values(1,'https://appstore33242.blob.core.windows.net/images/AZ-204.jpg','Az-204 Developing Azure solutions', 4.5)
Insert Into Course(CourseID,ExamImage,CourseName,Rating) Values(2,'https://appstore33242.blob.core.windows.net/images/DP-900.jpg','DP-900 Azure Data Fundamentals', 4.6)
Insert Into Course(CourseID,ExamImage,CourseName,Rating) Values(3,'https://appstore33242.blob.core.windows.net/images/DP-203.jpg','DP-203 Azure Data Engineer', 4.7)

select * from course;