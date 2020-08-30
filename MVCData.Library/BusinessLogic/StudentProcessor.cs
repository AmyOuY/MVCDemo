using MVCData.Library.DataAccess;
using MVCData.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCData.Library.BusinessLogic
{
    public class StudentProcessor
    {
        public static void CreateStudent(int studentId, string firstName, string lastName, string email)
        {
            StudentModel student = new StudentModel
            {
                StudentId = studentId,
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            string sql = @"insert into dbo.Student (StudentId, FirstName, LastName, Email)
                            values (@StudentId, @FirstName, @LastName, @Email);";

            SqlDataAccess.SaveData(sql, student);
        }


        public static List<StudentModel> LoadStudents()
        {
            string sql = @"select Id, StudentId, FirstName, LastName, Email
                        from dbo.Student;";

            return SqlDataAccess.LoadData<StudentModel>(sql);
        }
    }
}

