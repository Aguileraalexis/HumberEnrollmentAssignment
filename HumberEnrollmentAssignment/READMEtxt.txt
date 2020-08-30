POST https://localhost:44374/api/course -> {"Id":1, "Name": "Course 1"} //adding one course
POST https://localhost:44374/api/student -> {"Id":1, "Name": "Student 1"} //adding one student
POST https://localhost:44374/api/enrollment -> {"StudentId":1, "CourseId": 1} //enrolling the student in the course

GET https://localhost:44374/api/student/1 -> Shows the student is there, with enrollment
GET https://localhost:44374/api/course/1 -> Shows the course is there, with enrollment
GET https://localhost:44374/api/enrollment -> Shows the enrollment list

DELETE https://localhost:44374/api/enrollment/1/1 -> delete enrollment for Student 1/Course 1 (in that order)

GET https://localhost:44374/api/student/1 -> Shows the student is there, no longer enrolled
