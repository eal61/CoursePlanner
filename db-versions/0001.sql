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
  minor bit not null
);

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
INSERT into course (course_id, course_name, DEPT_No, credits) values (19, 'Computer Architecture', 'CS1541',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (20, 'Special Topcis in CS', 'CS1699',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (21, 'Structure Programming Languages', 'CS1621',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (22, 'Digital Systems Lab', 'COE0501',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (23, 'Digital Logic', 'COE132',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (24, 'Software Engineering', 'COE1186',3);
INSERT into course (course_id, course_name, DEPT_No, credits) values (25, 'Senior Design Project', 'COE1896',3);

INSERT into degree (degree_id, name, dept, major, minor) values (0, 'Computer Science', 'CS', 1, 0); --CS Major
INSERT into degree (degree_id, name, dept, major, minor) values (1, 'Computer Engineering', 'COE', 1, 0);
INSERT into degree (degree_id, name, dept, major, minor) values (2, 'Computer Science', 'CS', 0, 1); --CS Minor

-- TODO I have no idea what the requirement id field means I'm just throwing rand NO's in here
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 0, 0, 5); --degree 0 (CS Major) consists of class 0 (CS1530) and it is not mandatory (requirement # TBD)
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 1, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 2, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 3, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 4, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 5, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 6, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 7, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 8, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 9, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 10, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 11, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 12, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 13, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 14, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 15, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 16, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 17, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 18, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 19, 0 ,5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 20, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (0, 21, 0, 5);

INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 0, 0, 5); 
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 1, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 2, 0, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 3, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 4, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 5, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 6, 0, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 7, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 8, 1, 4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 9, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 10, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 11, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 12, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 13, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 14, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 15, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 16, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 17, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 18, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 19, 1 ,4);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 20, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 21, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 22, 1, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 23, 1, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 24, 0, 5);
INSERT into course_degree (degree_id, course_id, mandatory, requirement_id) values (1, 25, 1, 5);

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
