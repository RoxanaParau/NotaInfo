using NotaInfo.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NotaInfo
{
    public partial class Professor : System.Web.UI.Page
    {
        UniversityBL universityBL = new UniversityBL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfessorsGridView.DataSource = universityBL.GetProfessors();
                ProfessorsGridView.DataBind();

            }
        }

        protected void ProfessorsGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ProfessorsGridView.EditIndex = e.NewEditIndex;
            ProfessorsGridView.DataSource = universityBL.GetProfessors();
            ProfessorsGridView.DataBind();
        }

        protected void ProfessorsGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ProfessorsGridView.EditIndex = -1;
            ProfessorsGridView.DataSource = universityBL.GetProfessors();
            ProfessorsGridView.DataBind();
        }

        protected void ProfessorsGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ProfessorsGridView.DataSource = universityBL.GetProfessorsByName(SearchTextBox.Text);
            ProfessorsGridView.DataBind();
        }

        protected void lnkRemove_Click(object sender, EventArgs e)
        {
            LinkButton lnkRemove = (LinkButton)sender;
            int profID = int.Parse(lnkRemove.CommandArgument);
            universityBL.DeleteProfessor(profID);
            ProfessorsGridView.DataSource = universityBL.GetProfessors();
            ProfessorsGridView.DataBind();
        }
    }
}