using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the EF Models
using lesson5.Models;
using System.Web.ModelBinding;

namespace lesson5
{
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && (Request.QueryString.Count) > 0)
            {
                GetStudent();
            }
        }

        protected void GetStudent()
        {

            Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            using (comp2007Entities db = new comp2007Entities())
            {

                Student s = (from obj in db.Students
                             where obj.StudentID == StudentID
                             select obj).FirstOrDefault();

                txtLastName.Text = s.LastName;
                txtFirstMidName.Text = s.FirstMidName;
                
                txtEnrollmentDate.Text = (s.EnrollmentDate).ToString("yyyy-MM-dd");

                //bind results
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                Student s = new Student();
                int StudentID = 0;

                if(Request.QueryString["StudentID"] != null)
                {
                    StudentID = int.Parse(Request.QueryString["StudentID"]);

                    s = (from obj in db.Students
                         where obj.StudentID == StudentID
                         select obj).FirstOrDefault();
                }

                s.LastName = txtLastName.Text;
                s.FirstMidName = txtFirstMidName.Text;
                s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                if(StudentID == 0)
                db.Students.Add(s);

                db.SaveChanges();

                Response.Redirect("students.aspx");
            }
        }
    }
}