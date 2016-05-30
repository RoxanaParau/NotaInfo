using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NotaInfo.DAL;

namespace NotaInfo
{
    public partial class DepartmentsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            DepartmentsDetailsView.EnableDynamicData(typeof(Department));
        }

        protected void DepartmentsObjectDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                
                    var duplicateAdministratorValidator = new CustomValidator();
                    duplicateAdministratorValidator.IsValid = false;
                    duplicateAdministratorValidator.ErrorMessage = "Insert failed: " + e.Exception.InnerException.Message;
                    Page.Validators.Add(duplicateAdministratorValidator);
                    e.ExceptionHandled = true;
             
            }
        }
    }
}