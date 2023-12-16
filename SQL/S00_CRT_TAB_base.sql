DROP TABLE IF EXISTS access_url;
DROP TABLE IF EXISTS course;
DROP TABLE IF EXISTS instructor;
DROP TABLE IF EXISTS re_course_instructor;



CREATE TABLE access_url(
acess_url_id	int PRIMARY KEY IDENTITY(1,1),
accessed_url	NVARCHAR(100), 
access_tries	int,
first_access	DATETIME,
last_try		DATETIME,
valid_url		int
)

CREATE TABLE course(
course_id		int PRIMARY KEY IDENTITY(1,1),
title			NVARCHAR(255),
duration		int,
course_desc		NVARCHAR(MAX),
registered_at	DATETIME
)

CREATE TABLE instructor(
instructor_id	int PRIMARY KEY IDENTITY(1,1),
instructor_name	NVARCHAR(100),
registered_at	DATETIME
)

CREATE TABLE re_course_instructor(
relation_id	int PRIMARY KEY IDENTITY(1,1),
course_id		int,
instructor_id	int,
registered_at	DATETIME
)



