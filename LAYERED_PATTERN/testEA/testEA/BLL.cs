using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace testEA
{
    public class BLL
    {

        public void AddStudent(BOL objStudent)
        {
            string query = String.Format("insert into students (name,email,section,created_at,updated_at) values ('" + objStudent.name + "','" + objStudent.email + "','" + objStudent.section + "',sysdate(),sysdate())");

            DAL objDAL = new DAL();
            objDAL.EXECUTE_Command(new MySql.Data.MySqlClient.MySqlCommand(query));
        }

        public DataTable GetStudents()
        {
            DAL objDAL = new DAL();

            return objDAL.LOAD_DT("select * from students");
        }

    }
}