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
    public partial class WebForm18 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        StringBuilder sb = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            //LoadFee();
        }

        void LoadFee()
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP",con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag","FeeLoad");
                    com.Parameters.AddWithValue("@Id",StdRegId.Value);
                    SqlDataReader dr = com.ExecuteReader();
                    sb.Append("<a id='Download' href='#'><img src='ImageFolder/1653641330541.JPEG' style='width:20px;height:20px;float:right' class='mb-1'/></a>");
                    sb.Append("<table id='tableId' class='table table-hover table-bordered'>");                 
                    sb.Append("<tr>");
                    sb.Append("<th>Sn</th><th>StudentId</th><th>FullName</th><th>TotalFee</th><th>FeeDeposited</th><th>RemainingFee</th>");
                    sb.Append("</tr>");
                    int sn = 1;
                    if (dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            sb.Append("<tr>");
                            sb.Append("<td>"+sn+"</td>");
                            sb.Append("<td>"+dr[0]+"</td>");
                            sb.Append("<td>" + dr[1] + "</td>");
                            sb.Append("<td>" + dr[2] + "</td>");
                            sb.Append("<td>" + dr[3] + "</td>");
                            sb.Append("<td>" + dr[4] + "</td>");
                            sb.Append("</tr>");
                            sn++;
                        }
                    }
                    sb.Append("</table>");
                    dr.Close();
                    PanelId.Controls.Add(new Literal { Text = sb.ToString() });
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

        protected void SubmitId_Click(object sender, EventArgs e)
        {
            LoadFee();
        }
    }
}