using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using lesson5.Models;
using System.Web.ModelBinding;

namespace lesson5
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getDepartments();                
            }
        }

        protected void getDepartments()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                //query database
                var Department = from s in db.Departments
                               select s;

                //bind results
                grdDepartment.DataSource = Department.ToList();
                grdDepartment.DataBind();
            }
        }

        protected void grdDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 selectedRow = e.RowIndex;
            Int32 DepartmentID = Convert.ToInt32(grdDepartment.DataKeys[selectedRow].Values["DepartmentID"]);

            using (comp2007Entities db = new comp2007Entities())
            {
                Department s = (from obj in db.Departments
                             where obj.DepartmentID == DepartmentID
                             select obj).FirstOrDefault();

                db.Departments.Remove(s);
                db.SaveChanges();


            }
            getDepartments();

        }
    }
}