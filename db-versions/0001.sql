-- run this file against aspnet-CoursePlanner-20180131110323 to update your database
drop table if exists student;
create table student (
  student_id integer identity primary key -- indicates that the primary key should be autoincremented and unique
);

drop table if exists course;
create table course (
  course_id integer primary key,
  course_name nvarchar(60) not null,
  DEPT_No nvarchar(60) not null,
  credits integer not null
);

drop table if exists student_course;
create table student_course (
  course_id integer not null,
  student_id integer not null,
  semester_id integer not null
);

drop table if exists student_user;
create table student_user (
  student_id integer not null,
  user_id nvarchar(60) not null,
);

--if major than major bit=1 minor=0, if minor major=0 minor=1, and if neither(certificate, etc.) then both 0
drop table if exists degree;
create table degree (
  degree_id integer not null,
  name nvarchar(60) not null,
  dept nvarchar(60) not null,
  major bit not null,
  minor bit not null,
  
  advCoreElectiveNum integer not null, --refers to number of classes needed
  openElectiveNum integer not null,
  techElectiveNum integer not null,
  hssElectiveNum integer not null
);

drop table if exists preReqs;
create table preReqs (
  course_id integer not null,
  preReq_courseId integer not null
)

drop table if exists coReqs;
create table coReqs (
  course_id integer not null,
  coReq_courseId integer not null
)

--Requirement value 0: Core Requirement 1:Advanced Core Elective 2:Open Elective 3:Freshmen ENGR Program 4: Technical Elective 
--5:H/SS Elective 

drop table if exists course_degree;
create table course_degree (
	degree_id integer not null,
	course_id integer not null,
	mandatory bit not null,
	requirement_id integer not null
);

drop table if exists student_degree;
create table student_degree (
	student_id int not null,
	degree_id int not null,
);



INSERT into course (course_id, course_name, DEPT_No, credits) values (0, 'Software Engineering', 'CS1530',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (1, 'Intermediate Java', 'CS0401',4);
INSERT into course (course_id, course_name, DEPT_No, credits) values (2, 'Discrete Math', 'CS0441',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (3, 'Data Structures', 'CS0445',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (4, 'Computer Organization', 'CS0447',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (5, 'Systems Software', 'CS0449',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (6, 'Operating Systems', 'CS1550',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (7, 'Algorithms', 'CS1501',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (8, 'Formal Methods', 'CS1502',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (9, 'Web Applications', 'CS1520',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (10, 'Database Management Systems', 'CS1555',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (11, 'Computer Architecture', 'CS1541',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (12, 'Computer Graphics', 'CS1566',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (13, 'Software Quality Assurance', 'CS1632',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (14, 'Machine Learning', 'CS1675',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (15, 'Computer Vision', 'CS1674',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (16, 'Artificial Intelligence', 'CS1571',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (17, 'Compiler Design', 'CS1622',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (18, 'Data Science', 'CS1656',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (19, 'Interface Design Methodology', 'CS1635',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (20, 'Special Topcis in CS', 'CS1699',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (21, 'Structure Programming Languages', 'CS1621',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (22, 'Digital Systems Lab', 'COE0501',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (23, 'Digital Logic', 'COE132',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (24, 'Software Engineering', 'COE1186',4);
INSERT into course (course_id, course_name, DEPT_No, credits) values (25, 'Senior Design Project', 'COE1896',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (36, 'Linear Systems and Circuits 1', 'COE0031',4);
INSERT into course (course_id, course_name, DEPT_No, credits) values (37, 'Analysis and Design of Electronic Circuits', 'COE0257',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (39, 'Advanced Digital Desgin', 'COE1502',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (40, 'ENGR Probability and Statistics', 'ENGR0020',4);

--Freshmen classes
INSERT into course (course_id, course_name, DEPT_No, credits) values (26, 'Calc 1', 'MATH0220',4);
INSERT into course (course_id, course_name, DEPT_No, credits) values (27, 'Calc 2', 'MATH0230',4);
INSERT into course (course_id, course_name, DEPT_No, credits) values (28, 'Calc 3', 'MATH0240',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (29, 'Physics 1', 'PHYS0174',4);
INSERT into course (course_id, course_name, DEPT_No, credits) values (30, 'Physics 2', 'PHYS0175',4);
INSERT into course (course_id, course_name, DEPT_No, credits) values (31, 'Chemistry 1', 'CHEM0960',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (32, 'Chemistry 2', 'CHEM0970',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (33, 'Engineering Analysis', 'ENGR0011',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (34, 'Engineering Analysis 2', 'ENGR0012',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (35, 'Differential Equations', 'MATH0290',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (38, 'Linear Algebra', 'MATH0280',3);

--Humanities
INSERT into course (course_id, course_name, DEPT_No, credits) values (41, 'Modern Greek 1', 'GREEK0231',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (42, 'Mythology in the Ancient World', 'CLASS0030',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (43, 'Intro to Ethics', 'PHIL0300',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (44, 'Intro to Cultural Anthropolgy', 'ANTH0780',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (45, 'Written Professional Communication', 'ENGCMP0400',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (46, 'Seminar in Composition', 'ENGCMP0200',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (47, 'Communication Process', 'COMMRC0300',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (48, 'Interpersonal Communication', 'COMMRC0530',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (49, 'Intro to Micro Economics', 'ECON0100',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (50, 'Intro to Macro Economics', 'ECON0110',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (51, 'Game Theory Principles', 'ECON0200',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (52, 'Game Theory', 'ECON1200',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (53, 'Intermediate Micro Economics', 'ECON1100',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (54, 'Intermediate Macro Economics', 'ECON1110',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (55, 'Intro to International Econ', 'ECON0500',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (56, 'Intro to Econometrics', 'ECON0160',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (57, 'Applied Econometrics 1', 'ECON1150',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (58, 'Intro to Money and Banking', 'ECON0280',3);


--List of degrees into DB
INSERT into degree (degree_id, name, dept, major, minor, advCoreElectiveNum, openElectiveNum, techElectiveNum, hssElectiveNum) values (0, 'Computer Science', 'CS', 1, 0, 5, 0, 0, 26); --CS Major
INSERT into degree (degree_id, name, dept, major, minor, advCoreElectiveNum, openElectiveNum, techElectiveNum, hssElectiveNum) values (1, 'Computer Engineering', 'COE', 1, 0, 4, 2, 3, 7);--COE Major
INSERT into degree (degree_id, name, dept, major, minor, advCoreElectiveNum, openElectiveNum, techElectiveNum, hssElectiveNum) values (2, 'Computer Science', 'CS', 0, 1, 2, 0, 0, 0); --CS Minor
INSERT into degree (degree_id, name, dept, major, minor, advCoreElectiveNum, openElectiveNum, techElectiveNum, hssElectiveNum) values (3, 'Economics', 'ECON', 0, 1, 3, 0, 0, 0); --Econ Minor
INSERT into degree (degree_id, name, dept, major, minor, advCoreElectiveNum, openElectiveNum, techElectiveNum, hssElectiveNum) values (4, 'Mechanical Engineerng', 'MEMS', 1, 0, 4, 0, 1, 6); --MechE Major


--Requirement value 0: Core Requirement(ie specific class is required) 1:Advanced Core Elective 2:Open Elective 3:Freshmen ENGR Program 
--4: Technical Elective 5:H/SS Elective 
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 0, 0, 1); --degree 0 (CS Major) consists of class 0 (CS1530) and it is not mandatory and is part of requirement classs#1:Advance core elective
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 1, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 2, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 3, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 4, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 5, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 6, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 7, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 8, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 9, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 10, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 11, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 12, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 13, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 14, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 15, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 16, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 17, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 18, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 19, 0 ,1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 20, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 21, 0, 1);
--COE Major
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 0, 1, 0); 
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 1, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 2, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 3, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 4, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 5, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 6, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 7, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 8, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 9, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 10, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 11, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 12, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 13, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 14, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 15, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 16, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 17, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 18, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 19, 0 ,1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 20, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 21, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 22, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 23, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 25, 1, 0);


INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 26, 1, 3);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 27, 1, 3);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 28, 0, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 29, 1 ,3);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 30, 1, 3);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 31, 1, 3);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 32, 1, 3);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 33, 1, 3);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 34, 1, 3);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 35, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 38, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 36, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 37, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 39, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 40, 1, 0);

--CS Minor
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (2, 1, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (2, 3, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (2, 4, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (2, 2, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (2, 5, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (2, 7, 1, 0);

--ECON Minor
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 50, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 54, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 53, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 52, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 51, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 55, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 56, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 57, 0, 1);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (3, 58, 0, 1);


--MechE
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 28, 1, 0); --degree, class#, mandatory, classification CALC 3
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (4, 49, 1, 0);


--make a preReq
INSERT into preReqs (course_id, preReq_courseId) values (27, 26); --class 26(Calc1) is a preReq for class 27(Calc2)
INSERT into preReqs (course_id, preReq_courseId) values (28, 27);

INSERT into student default values; -- this inserts a student into the table and auto increments the id so it's unique
select SCOPE_IDENTITY();

INSERT into student_course (course_id, student_id, semester_id) values (0, 1, 6); --Course 0(CS1530) is taken by student 0 in semester index 6 (so semester#7 with 0 indexing)
INSERT into student_course (course_id, student_id, semester_id) values (1, 1, 0);
INSERT into student_course (course_id, student_id, semester_id) values (2, 1, 0);
INSERT into student_course (course_id, student_id, semester_id) values (3, 1, 0);
INSERT into student_course (course_id, student_id, semester_id) values (4, 1, 1);
INSERT into student_course (course_id, student_id, semester_id) values (5, 1, 1);
INSERT into student_course (course_id, student_id, semester_id) values (6, 1, 2);
INSERT into student_course (course_id, student_id, semester_id) values (7, 1, 2);
INSERT into student_course (course_id, student_id, semester_id) values (8, 1, 3);
INSERT into student_course (course_id, student_id, semester_id) values (14, 1, 3);
INSERT into student_course (course_id, student_id, semester_id) values (16, 1, 3);
INSERT into student_course (course_id, student_id, semester_id) values (11, 1, 4);
INSERT into student_course (course_id, student_id, semester_id) values (21, 1, 4);

INSERT into student_degree (student_id, degree_id) values (1, 0); --student 0 has degree 0 (CS major)

--DELETE FROM student_course WHERE (course_id = 0 AND student_id=0 AND semester_id = 0);
