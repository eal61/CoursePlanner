drop table if exists student;
create table student (
  student_id integer primary key autoincrement,
  username text not null,
  pw_hash text not null
);

drop table if exists course;
create table course (
  course_id integer primary key autoincrement,
  secondary_id integer,
  course_name text not null
);

drop table if exists student_courses;
create table student_courses (
  course_id integer not null,
  student_id integer not null
);

