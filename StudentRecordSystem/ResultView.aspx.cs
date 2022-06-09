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
    public partial class WebForm10 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropListDataBind();
                tableId.Visible = false;
            }
            else
            {
                tableId.Visible = true;
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
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                using(con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP",con);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Flag", "ShowSubject");
                    comm.Parameters.AddWithValue("@AName", DrpListId.SelectedValue);
                    SqlDataReader drr = comm.ExecuteReader();
                    string[] names = new string[4];
                    var i = 0;
                    if(drr.HasRows)
                    {
                        while(drr.Read())
                        {
                            names[i] = drr[1].ToString();
                            i++;
                        }
                    }
                    th1.InnerText = names[0];
                    th2.InnerText = names[1];
                    th3.InnerText = names[2];
                    th4.InnerText = names[3];
                    drr.Close();

                    SqlCommand com = new SqlCommand("MGMTSP", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag", "FinalResult");
                    com.Parameters.AddWithValue("@StdRegId", StdRegId.Value);
                    com.Parameters.AddWithValue("@CourseId", DrpListId.SelectedValue);

                    SqlDataReader dr = com.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            td1.InnerText = dr[0].ToString();
                            td2.InnerText = dr[1].ToString();
                            td3.InnerText = dr[2].ToString();
                            td4.InnerText = dr[3].ToString();
                            td5.InnerText = dr[4].ToString();
                            td6.InnerText = dr[5].ToString();
                            td7.InnerText = dr[6].ToString();
                        }
                    }
                    else
                    {
                        tableId.Visible = false;
                        Response.Write("<script>alert('Result not found.')</script>");
                    }
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