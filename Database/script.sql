USE SchoolDB;
GO

CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Budget DECIMAL(18, 2) NOT NULL,
    StartDate DATE NOT NULL
);

CREATE TABLE Instructors (
    InstructorID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    HireDate DATE NOT NULL
);

CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Departments (DepartmentID)
);

CREATE TABLE Students (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    EnrollmentDate DATE NOT NULL
);

CREATE TABLE Enrollments (
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    CourseID INT FOREIGN KEY REFERENCES Courses (CourseID),
    StudentID INT FOREIGN KEY REFERENCES Students (StudentID),
    Grade DECIMAL(3, 2)
);

-- Bảng cho Bài tập 3 (Challenge)
CREATE TABLE tblUser (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100)
);

-- Chèn dữ liệu mẫu
INSERT INTO Departments VALUES ('Computer Science', 120000, '2023-01-01');
INSERT INTO Instructors VALUES ('John', 'Doe', '2020-08-15');
INSERT INTO Courses VALUES ('Introduction to Programming', 3, 1);
INSERT INTO Students VALUES ('Jane', 'Smith', '2023-09-01');
INSERT INTO Enrollments VALUES (1, 1, 3.5);
INSERT INTO tblUser VALUES ('admin', '123456', 'admin@tdtu.edu.vn');