using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DEMO.WEB.API.Models;

namespace DEMO.WEB.API.Controllers
{
    public class testController : ApiController
    { 
        [Route("get-student-id/{id}")]
        [HttpGet]
        public Student GetStudentByID([FromUri] int id)
        {
            LINQtoSQLDataContext db = new LINQtoSQLDataContext();
        
            var Student = (from student in db.tblStudents where student.id == id select student).FirstOrDefault();
            Student st = new Student()
            {
                ID = Student.id,
                Name = Student.name,
                Address = Student.address,
                Email = Student.email,
                Mark = (double)Student.mark
            };

            return st;
        }

        [Route("add-student")]
        [HttpPost]
        public void PostStudent([FromBody] Student st) {
            LINQtoSQLDataContext db = new LINQtoSQLDataContext();
            var student = new tblStudent()
            {
                name = st.Name,
                address = st.Address,
                email = st.Email,
                mark = st.Mark
            };
            db.tblStudents.InsertOnSubmit(student);
            db.SubmitChanges();
        }

        [Route("delete-student/{id}")]
        [HttpDelete]
        public void DeleteStudentById([FromUri] int id)
        {
            LINQtoSQLDataContext db = new LINQtoSQLDataContext();
            // tblStudent deleteStudent = db.tblStudents.FirstOrDefault(el => el.id == id);
            var dl = (from sts in db.tblStudents where sts.id == id select sts).FirstOrDefault();
            db.tblStudents.DeleteOnSubmit(dl);
            db.SubmitChanges();
        }

        [Route("update-student")]
        [HttpPut]
        public void UpdateStudent([FromBody] Student st)
        {
            LINQtoSQLDataContext db = new LINQtoSQLDataContext();
            tblStudent stUpdate = (db.tblStudents.FirstOrDefault(el => el.id == st.ID));
            stUpdate.name = st.Name;
            stUpdate.email = st.Email;
            stUpdate.address = st.Address;
            stUpdate.mark = st.Mark;
            db.SubmitChanges();
        }

        [Route("list-all-student")]
        [HttpGet]
        public List<Student> GetAllStudent()
        {
            LINQtoSQLDataContext db = new LINQtoSQLDataContext();
            List<Student> listStudent = new List<Student>();
            Student st;

            var Students =  db.tblStudents.ToList();
            
            foreach (var item in Students)
            {
                st = new Student()
                {
                    ID = item.id,
                    Name = item.name,
                    Email = item.email,
                    Mark = (double)item.mark,
                    Address = item.address
                };
                listStudent.Add(st);
            }

            return listStudent;
        }
    }
}
