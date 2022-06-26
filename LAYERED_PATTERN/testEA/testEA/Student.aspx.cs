using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testEA
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ShowAllStudents();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            BOL objStudent = new BOL();
            BLL objSt = new BLL();

            objStudent.name = txtname.Text;
            objStudent.email = txtemail.Text;
            objStudent.section = txtsection.Text;

            objSt.AddStudent(objStudent);

            ShowAllStudents();
        }

        protected void ShowAllStudents()
        {
            BLL objSt = new BLL();
            dgData.DataSource = objSt.GetStudents();
            dgData.DataBind();
        }
    }
}