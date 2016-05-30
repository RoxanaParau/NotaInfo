using NotaInfo.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotaInfo.DAL;
using System.Data;

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
                chkLabsBind();
            }
        }
        void chkLabsBind()
        {
             CheckBoxList labs =  (CheckBoxList)ProfessorsGridView.FooterRow.FindControl("chkLabsNewProf") as CheckBoxList;
             labs.DataSource = universityBL.GetLabs().ToList();
             labs.DataTextField = "Name";
             labs.DataValueField = "Id";
             labs.DataBind();

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
            string ProfID = ((Label)ProfessorsGridView.Rows[e.RowIndex]
                             .FindControl("lblProfessorID")).Text;
            string FirstName = ((TextBox)ProfessorsGridView.Rows[e.RowIndex]
                                .FindControl("txtProfessorFirstName")).Text;
            string LastName = ((TextBox)ProfessorsGridView.Rows[e.RowIndex]
                               .FindControl("txtProfessorLastName")).Text;
            DateTime startDate = ((Calendar)ProfessorsGridView.Rows[e.RowIndex]
                                .FindControl("calendarStartDate")).SelectedDates[0];
            List<int> chkLabsIds = ((CheckBoxList)ProfessorsGridView.Rows[e.RowIndex]
                                .FindControl("chkLabs")).Items.Cast<ListItem>().Where(i => i.Selected).Select(t => int.Parse(t.Value)).ToList();
            User prof = new User();
            prof.UserID = int.Parse(ProfID);
            prof.LastName = LastName;
            prof.FirstName = FirstName;
            prof.HireDate = startDate;

            universityBL.UpdateProfessor(prof);

            universityBL.UpdateProfPerLab(int.Parse(ProfID), chkLabsIds);
            ProfessorsGridView.EditIndex = -1;
            ProfessorsGridView.DataSource = universityBL.GetProfessors();
            ProfessorsGridView.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ProfessorsGridView.DataSource = universityBL.GetProfessorsByName(SearchTextBox.Text).ToList();
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



        protected void ProfessorsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    CheckBoxList ddList = (CheckBoxList)e.Row.FindControl("chkLabs");

                    List<Lab> labs = universityBL.GetLabs().ToList();
                    ddList.DataSource = labs;
                    ddList.DataTextField = "Name";
                    ddList.DataValueField = "Id";
                    ddList.DataBind();

                    User dr = e.Row.DataItem as User;
               
                    List<int> labsIds = universityBL.GetProfsPerLabs(int.Parse(dr.UserID.ToString())).Select(s => s.LabId.Value).ToList();

                    foreach (int id in labsIds)
                        ddList.Items.FindByValue(id.ToString()).Selected = true;
                }
                else
                {
                    User dr = e.Row.DataItem as User;

                    Label lblLabs = (Label)e.Row.FindControl("lblLabs");
                    lblLabs.Text = "";
                    List<int> labsIds = universityBL.GetProfsPerLabs(int.Parse(dr.UserID.ToString())).Select(s => s.LabId.Value).ToList();

                    foreach (int id in labsIds)
                        lblLabs.Text += universityBL.GetLabs().FirstOrDefault(l => l.Id == id).Name + " ";

                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            TextBox firstname = (TextBox)ProfessorsGridView.FooterRow.FindControl("txtNewProfFirstName") as TextBox;
            TextBox lastname = (TextBox)ProfessorsGridView.FooterRow.FindControl("txtNewProfLastName") as TextBox;
            Calendar hiredate = (Calendar)ProfessorsGridView.FooterRow.FindControl("cNewProfHireDate") as Calendar;
            CheckBoxList labs = (CheckBoxList)ProfessorsGridView.FooterRow.FindControl("chkLabsNewProf") as CheckBoxList;

            User newProf = new User
            {
                LastName = lastname.Text,
                FirstName = firstname.Text,
                HireDate = hiredate.SelectedDate
            };
         int id =   universityBL.InsertProfessor(newProf);

            universityBL.InsertProfPerLab(id, labs.Items.Cast<ListItem>().Where(i => i.Selected).Select(t => int.Parse(t.Value)).ToList());
            ProfessorsGridView.DataSource = universityBL.GetProfessors();
            ProfessorsGridView.DataBind();
        }
    }
}