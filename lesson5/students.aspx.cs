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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                //query database
                var Students = from s in db.Students
                               select s;

                //bind results
                grdStudents.DataSource = Students.ToList();
                grdStudents.DataBind();
            }
        }

        protected void grdStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdStudents_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 selectedRow = e.RowIndex;
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[selectedRow].Values["StudentID"]);

            using(comp2007Entities db = new comp2007Entities())
            {
                Student s = (from obj in db.Students
                             where obj.StudentID == StudentID
                             select obj).FirstOrDefault();

                db.Students.Remove(s);
                db.SaveChanges();
                
               
            }
            GetStudents();
        }

    }
}