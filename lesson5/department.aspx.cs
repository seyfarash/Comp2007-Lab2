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
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && (Request.QueryString.Count) > 0)
            {
                getDepartment();
            }
        }

        protected void getDepartment()
        {

            Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            using (comp2007Entities db = new comp2007Entities())
            {

                Department s = (from obj in db.Departments
                             where obj.DepartmentID == DepartmentID
                             select obj).FirstOrDefault();

                txtBuget.Text = s.Budget.ToString();
                txtDepartment.Text = s.Name;


                //bind results

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                Department s = new Department();
                int DepartmentID = 0;

                if (Request.QueryString["DepartmentID"] != null)
                {
                    DepartmentID = int.Parse(Request.QueryString["DepartmentID"]);

                    s = (from obj in db.Departments
                         where obj.DepartmentID == DepartmentID
                         select obj).FirstOrDefault();
                }

                s.Budget = Convert.ToDecimal(txtBuget.Text);
                s.Name = txtDepartment.Text;

                if (DepartmentID == 0)
                    db.Departments.Add(s);

                db.SaveChanges();

                Response.Redirect("departments.aspx");
            }
        }
    }
}