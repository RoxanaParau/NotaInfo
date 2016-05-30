using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotaInfo.BLL;
using NotaInfo.DAL;

namespace NotaInfo
{
    public partial class Departments : System.Web.UI.Page
    {
        UniversityBL universityBL = new UniversityBL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DepartmentsGridView.DataSource = universityBL.GetDepartments();
                DepartmentsGridView.DataBind();

            }

        }


        protected void SearchButton_Click(object sender, EventArgs e)
        {
            DepartmentsGridView.DataSource = universityBL.GetDepartmentsByName(SearchTextBox.Text);
            DepartmentsGridView.DataBind();
        }

        protected void DepartmentsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DepartmentsGridView.EditIndex = e.NewEditIndex;
            DepartmentsGridView.DataSource = universityBL.GetDepartments();
            DepartmentsGridView.DataBind();

        }

        protected void DepartmentsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string DepartmentID = ((Label)DepartmentsGridView.Rows[e.RowIndex]
                              .FindControl("lblDepartmentID")).Text;
            string Name = ((TextBox)DepartmentsGridView.Rows[e.RowIndex]
                                .FindControl("txtDepartmentName")).Text;
            DateTime startDate = ((Calendar)DepartmentsGridView.Rows[e.RowIndex]
                                .FindControl("calendarStartDate")).SelectedDates[0];
            Department dep = new Department();
            dep.DepartmentID =int.Parse( DepartmentID);
            dep.Name = Name;
            dep.StartDate = startDate;
            universityBL.UpdateDepartment(dep);
            DepartmentsGridView.EditIndex = -1;
            DepartmentsGridView.DataSource = universityBL.GetDepartments();
            DepartmentsGridView.DataBind();
        }

        protected void DepartmentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DepartmentsGridView.DataSource = universityBL.GetDepartments();
            DepartmentsGridView.DataBind();
            DepartmentsGridView.PageIndex = e.NewPageIndex;
            DepartmentsGridView.DataBind();
        }

        protected void DepartmentsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DepartmentsGridView.EditIndex = -1;
            DepartmentsGridView.DataSource = universityBL.GetDepartments();
            DepartmentsGridView.DataBind();
        }

        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            int deptID = int.Parse(lnkRemove.CommandArgument);
            universityBL.DeleteDepartment(deptID);
            DepartmentsGridView.DataSource = universityBL.GetDepartments();
            DepartmentsGridView.DataBind();
        }

     
    
    }
}