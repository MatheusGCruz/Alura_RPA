ALTER TABLE re_course_instructor
ADD FOREIGN KEY (course_id) REFERENCES course(course_id);

ALTER TABLE re_course_instructor
ADD FOREIGN KEY (instructor_id) REFERENCES instructor(instructor_id);