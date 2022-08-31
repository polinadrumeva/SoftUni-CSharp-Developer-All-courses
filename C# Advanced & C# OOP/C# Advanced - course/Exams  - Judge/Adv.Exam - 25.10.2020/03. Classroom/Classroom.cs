using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        //  Field students – collection that holds added students
        private List<Student> students;
        public List<Student> Students { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Students.Count; } }

        public Classroom(int capacity)
        {
            this.Students = new List<Student>();
            this.Capacity = capacity;
        }

        //	Method RegisterStudent(Student student) – adds an entity to the students if there is an empty seat for the student.
        public string RegisterStudent(Student student)
        {
            if (!Students.Contains(student) && Students.Count + 1 < Capacity)
            { 
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }


        //	Method DismissStudent(string firstName, string lastName) – removes the student by the given names
        public string DismissStudent(string firstName, string lastName)
        { 
            Student studentToREmove = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (studentToREmove != null)
            { 
                Students.Remove(studentToREmove);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return"Student not found";
            }
        }

        //	Method GetSubjectInfo(string subject) – returns all the students with the given subject in the following format:
        public string GetSubjectInfo(string subject)
        {
           List<Student> withSubject = Students.Where(x => x.Subject == subject).ToList();    
            if (withSubject.Count == 0)
            {
                return "No students enrolled for the subject";
            }
            int count = 0;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var student in withSubject)
            {
                count++;
                if (count == withSubject.Count - 1)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                else
                {
                    sb.Append($"{student.FirstName} {student.LastName}");
                }
            }

            return sb.ToString();
        }


        //	Method GetStudentsCount() – returns the count of the students in the classroom.
        public int GetStudentsCount()
        { 
            return Students.Count;  
        }

        //	Method GetStudent(string firstName, string lastName) – returns the student with the given names. 
        public Student GetStudent(string firstName, string lastName)
        { 
            Student studentToFind = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (studentToFind != null)
            {
                return studentToFind;
            }
            return null;
        }

    }
}
