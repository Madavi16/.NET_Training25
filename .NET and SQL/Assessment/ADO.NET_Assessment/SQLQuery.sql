


create database EduTrack
go
create table Students
(
StudentId int identity(1,1) primary key,
FullName varchar(100) not null,
Email varchar(100) unique,
Department varchar(50) not null,
YearOfStudy int not null
)
go
create table Courses
(
CourseId int identity(1,1) primary key,
CourseName varchar(100) not null,
Credits int not null,
Semester varchar(100) not null
)

go
create table Enrollments
(
EnrollmentId int Identity(1,1) primary key,
StudentId int foreign key references Students(StudentId),
CourseId int foreign key references Courses(CourseId),
EnrollDate Datetime not null,
Grade Varchar(5) null
)

insert into Students (FullName, Email, Department, YearOfStudy) values
('Maheshwari', 'mahe780@mail.com', 'Biotechnology', 2),
('Bharathh', 'bharathhb30@mail.com', 'Mechanical', 3),
('Chiranjeevi', 'mucherlachiru@mail.com', 'Artificial Intelligence', 1),
('Ramyaa', 'ramyaamohan@mail.com', 'Electrical', 4),
('Balaji', 'balajithamatam@mail.com', 'Computer Science', 2)

go

insert into Courses (CourseName,Credits,Semester) values
('Protein Engineering', 4, 'Even'),
('Strength Of Materials', 3, 'Even'),
('Database Management Systems', 3, 'Odd'),
('Data Structures', 3, 'Odd'),
('Software Engineering', 3, 'Odd'),
('Cyber Networking', 3, 'Even')

go

insert into Enrollments(StudentId,CourseId,EnrollDate,Grade) values
(1, 1, GETDATE(), 'A'),
(1, 3, GETDATE(), NULL),
(2, 2, GETDATE(), 'B'),
(3, 4, GETDATE(), 'C'),
(4, 1, GETDATE(), 'B');


select * from Courses
go
select * from Students
go
select * from Enrollments


-- task 2.3
create procedure sp_SearchByDepartment
    @Dept nvarchar(50)
as
begin
    select StudentId, FullName, Email, YearOfStudy
   from Students
   where Department = @Dept;
end


-- stored procedure to get course by semester 

create procedure sp_GetCoursesBySemester
    @Semester VARCHAR(20)
as
begin
    select CourseId, CourseName, Credits
    from Courses
    where Semester = @Semester
end

