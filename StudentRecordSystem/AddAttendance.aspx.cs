using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.Services;

namespace StudentRecordSystem
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        string SubjectId;
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        StringBuilder sb = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropListDataBind();
            }
            else
            {
                SubjectId = SubjectDrop.SelectedValue.ToString();
                DropSubjectDataBind();
            }
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
        }

        protected void SubmitId_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        void LoadTable()
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag","Attendance");
                    com.Parameters.AddWithValue("@CourseId",DrpListId.SelectedValue);
                    //com.Parameters.AddWithValue("@Id", SubjectId);
                    SqlDataReader dr = com.ExecuteReader();
                    sb.Append("<table class='table table-hover table-bordered text-center'>");
                    sb.Append("<tr>");
                    sb.Append("<th>Num</th><th>StudentName</th><th colspan=2>Status</th>");
                    sb.Append("</tr>");
                    int num = 1;
                    if (dr.HasRows)
                    {
                        while(dr.Read())
                        {                         
                            sb.Append("<tr>");
                            sb.Append("<td>" + num + "</td>");
                            sb.Append("<td>" + dr[2] + "</td>");
                            sb.Append("<td><input type='button' class='btn btn-outline-success dltBtn' value='Present' onclick='test(0)'/></td>");
                            sb.Append("<td><input type='button' class='btn btn-outline-danger dltBtn' value='Absent' onclick='test(1)'/></td>");
                            sb.Append("</tr>");
                            num++;
                        }
                    }
                    sb.Append("</table>");
                    PlaceholderCourse.Controls.Add(new Literal { Text = sb.ToString() });
                    dr.Close();
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
        [WebMethod]
        public static string Attendance(int i)
        {
            string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand com = new SqlCommand("MGMTSP", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Flag", "AddAttendance");
            com.Parameters.AddWithValue("@Id", i);
            int check = com.ExecuteNonQuery();
            if (check > 0)
            {
                con.Close();
                return "Successfully deleted.";
            }
            else
            {
                con.Close();
                return "Error.";
            }
        }
    }
}