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

namespace StudentRecordSystem
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTeacher();
        }
        void LoadTeacher()
        {
            StringBuilder sb = new StringBuilder();
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag", "ViewTeacher");
                    SqlDataReader dr = com.ExecuteReader();
                    sb.Append("<table class='table table-hover table-bordered'>");
                    sb.Append("<tr>");
                    sb.Append("<th>Num</th><th>Teacher Name</th><th>Course</th><th>Subject Assigned</th>");
                    sb.Append("</tr>");
                    int id = 1;
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            sb.Append("<tr>");
                            sb.Append("<td>"+id+"</td>");
                            sb.Append("<td>"+dr[0]+"</td>");
                            sb.Append("<td>"+dr[1]+"</td>");
                            sb.Append("<td>"+dr[2]+"</td>");
                            sb.Append("</tr>");
                            id++;
                        }                     
                    }
                    PanelId.Controls.Add(new Literal { Text = sb.ToString() });
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
    }
}