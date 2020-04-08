using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeLibrary
{
    public class Factory
    {
        public static int _objectMaxSize = 2;
        public static Queue<Student> queue = new Queue<Student>(_objectMaxSize);

        public Student GetStudentObject()
        {
            //Student s;
            if (Student.counter >= _objectMaxSize && queue.Count >= 0)
                return RetrieveFromPool();
            else
                return GetNewStudent();
        }

        public Student RetrieveFromPool()
        {
            Student oStu;
            // Check if there are any objects in my collection
            if (queue.Count > 0)
            {
                Console.WriteLine("Object retrieved from the Queue");
                oStu = queue.Dequeue();
                Student.counter--;
            }
            else
            {
                // Return a new object
                Console.WriteLine("Adding new object after removal");
                oStu = new Student();
            }
            return oStu;
        }
        public Student GetNewStudent()
        {
            Student s = new Student();
            queue.Enqueue(s);

            return s;
        }
    }

    public class Student
    {
        public static int counter = 0;
        public Student()
        {
            counter++;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
