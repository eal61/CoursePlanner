-- run this file against aspnet-CoursePlanner-20180131110323 to update your database
drop table if exists student;
create table student (
  student_id integer primary key,
);

drop table if exists course;
create table course (
  course_id integer primary key,
  course_name text not null,
  DEPT_No text not null,
  credits integer not null
);

drop table if exists student_course;
create table student_course (
  course_id integer not null,
  student_id integer not null,
  semester_id integer not null
);

drop table if exists degree;
create table degree (
  degree_id integer not null,
  name nvarchar(60) not null,
  dept nvarchar(60) not null
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
	major bit not null,
	minor bit not null
);
