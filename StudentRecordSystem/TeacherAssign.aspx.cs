using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentRecordSystem
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        string SubjectId, TeacherId;
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropListDataBind();
            }
            else
            {
                SubjectId = SubjectDrop.SelectedValue.ToString();
                TeacherId = TeacherDrop.SelectedValue.ToString();
               
                DropSubjectDataBind();
                DropTeacherDataBind();
            }

        }
        void DropListDataBind()
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sda = new SqlDataAdapter("MGMTSP", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Flag", "DropDownBind");
            DataTable data = new DataTable();
            sda.Fill(data);
            DrpListId.DataSource = data;
            DrpListId.DataTextField = "CourseName";
            DrpListId.DataValueField = "Id";
            DrpListId.DataBind();

            //DropSubjectDataBind();
            //DropTeacherDataBind();
        }
        void DropSubjectDataBind()
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sda = new SqlDataAdapter("MGMTSP", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Flag", "DropDownBindSubject");
            sda.SelectCommand.Parameters.AddWithValue("@CourseId", DrpListId.SelectedValue);
            DataTable data = new DataTable();
            sda.Fill(data);
            SubjectDrop.DataSource = data;
            SubjectDrop.DataTextField = "SubjectName";
            SubjectDrop.DataValueField = "Id";
            SubjectDrop.DataBind();
        }

        void DropTeacherDataBind()
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlDataAdapter sda = new SqlDataAdapter("MGMTSP", con);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@Flag", "DropDownBindTeachers");
            DataTable data = new DataTable();
            sda.Fill(data);
            TeacherDrop.DataSource = data;
            TeacherDrop.DataTextField = "FullName";
            TeacherDrop.DataValueField = "Id";
            TeacherDrop.DataBind();
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            Insert();
        }

        void Insert()
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP",con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag","AssignTeacher");
                    com.Parameters.AddWithValue("@CourseId",DrpListId.SelectedValue);
                    com.Parameters.AddWithValue("@StdRegId",SubjectId);
                    com.Parameters.AddWithValue("@Id",TeacherId);
                    int check = com.ExecuteNonQuery();
                    if(check>0)
                    {
                        Response.Write("<script>alert('Assigned successfully.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error.')</script>");
                    }
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
            finally
            {
                con.Close();
            }
        }

    }
}