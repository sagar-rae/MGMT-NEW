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
    public partial class WebForm17 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropListDataBind();
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

       void CheckStudent()
        {
            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag","CheckUser");
                    com.Parameters.AddWithValue("@Id",StdId.Value);
                    com.Parameters.AddWithValue("@AName",NameId.Value);
                    SqlDataReader dr = com.ExecuteReader();
                    if(dr.HasRows)
                    {
                        Response.Write("<script>alert('Student found.')</script>");
                        LoadFee();
                    }
                    else
                    {
                        Response.Write("<script>alert('No student found.')</script>");
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

        void LoadFee()
        {
            SqlConnection con = null;
            try
            {
                using(con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("MGMTSP",con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Flag","Fee");
                    com.Parameters.AddWithValue("@Id",StdId.Value);
                    com.Parameters.AddWithValue("@AName",NameId.Value);
                    com.Parameters.AddWithValue("@CourseId",DrpListId.SelectedValue);
                    com.Parameters.AddWithValue("@TotalFee",FeeId.Value);
                    com.Parameters.AddWithValue("@Fee",DepositId.Value);
                    int check = com.ExecuteNonQuery();
                    if(check>0)
                    {
                        Response.Write("<script>alert('Fee deposited.')</script>");
                        Response.Redirect("FeeReceipt.aspx");
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

        protected void SubmitId_Click(object sender, EventArgs e)
        {
            CheckStudent();
            //LoadFee();

           
        }
    }
}