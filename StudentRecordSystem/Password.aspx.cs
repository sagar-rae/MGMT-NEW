﻿using System;
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
    public partial class WebForm6 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["MGMTDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        void admin()
        {
            string checkUser = Session["name"].ToString();

            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {


                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP", con);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Flag", "AdminCheck");
                    comm.Parameters.AddWithValue("@AName", checkUser);
                    comm.Parameters.AddWithValue("@Pass", PrevPassId.Value);
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        SqlCommand com = new SqlCommand("MGMTSP", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Flag", "Password");
                        com.Parameters.AddWithValue("@Pass", NewPassId.Value);
                        int check = com.ExecuteNonQuery();
                        if (check > 0)
                        {
                            Response.Write("<script>alert('Password Changed.')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Something went wrong.')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please type correct password.')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>'" + ex.Message + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }
        
        void user()
        {
            string checkUser = Session["name"].ToString();

            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {


                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP", con);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Flag", "UserCheck");
                    comm.Parameters.AddWithValue("@AName", checkUser);
                    comm.Parameters.AddWithValue("@Pass", PrevPassId.Value);
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        SqlCommand com = new SqlCommand("MGMTSP", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Flag", "PasswordUser");
                        com.Parameters.AddWithValue("@Pass", NewPassId.Value);
                        int check = com.ExecuteNonQuery();
                        if (check > 0)
                        {
                            Response.Write("<script>alert('Password Changed.')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Something went wrong.')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please type correct password.')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>'" + ex.Message + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }

        void teacher()
        {
            string checkUser = Session["name"].ToString();

            SqlConnection con = null;
            try
            {
                using (con = new SqlConnection(strcon))
                {


                    con.Open();
                    SqlCommand comm = new SqlCommand("MGMTSP", con);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@Flag", "TUserCheck");
                    comm.Parameters.AddWithValue("@AName", checkUser);
                    comm.Parameters.AddWithValue("@Pass", PrevPassId.Value);
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Close();
                        SqlCommand com = new SqlCommand("MGMTSP", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Flag", "PasswordTUser");
                        com.Parameters.AddWithValue("@Pass", NewPassId.Value);
                        int check = com.ExecuteNonQuery();
                        if (check > 0)
                        {
                            Response.Write("<script>alert('Password Changed.')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Something went wrong.')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Please type correct password.')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>'" + ex.Message + "'</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void PassBtnId_Click(object sender, EventArgs e)
        {
           if(Session["user"].Equals("0"))
            {
                admin();
            }
            else if(Session["user"].Equals("1"))
            {
                user();
            }
            else
            {
                teacher();
            }
        }
    }
}