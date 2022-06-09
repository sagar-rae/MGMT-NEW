using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentRecordSystem
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"].Equals("2"))
            {
                addTeacherId.Visible = false;
                addCourseId.Visible = false;
                addSubjectId.Visible = false;
                assignTeacherId.Visible = false;
                addStudentId.Visible = false;
                navbarDropdown5.InnerText = Session["name"].ToString();

            }
            else if(Session["user"].Equals("1"))
            {
                addTeacherId.Visible = false;
                addCourseId.Visible = false;
                addSubjectId.Visible = false;
                addAttendanceId.Visible = false;
                addResultId.Visible = false;
                assignTeacherId.Visible = false;
                navbarDropdown.Visible = false;
                navbarDropdown5.InnerText = Session["name"].ToString();
            }
           
        }
    }
}