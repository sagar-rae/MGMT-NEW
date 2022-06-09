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
    public partial class WebForm12 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
    
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
                    com.Parameters.AddWithValue("@Flag","InsertTeacher");
                    com.Parameters.AddWithValue("@FullName",FnameId.Value);
                    com.Parameters.AddWithValue("@Email",EmailId.Value);
                    com.Parameters.AddWithValue("@PhoneNumber",PhNumId.Value);
                    com.Parameters.AddWithValue("@Address", AddressId.Value);
                    int check = com.ExecuteNonQuery();
                    if (check > 0)
                    {
                        Response.Write("<script>alert('Successfully inserted.')</script>");
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

        protected void Insert_Click(object sender, EventArgs e)
        {
            Insert();
        }
    }
}