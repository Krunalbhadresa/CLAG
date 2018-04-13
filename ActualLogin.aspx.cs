using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActualLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config


    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
    
        string Email = txtemail.Text;
        string Password = txtpwd.Text;


        using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        {
            using (SqlCommand cmd = new SqlCommand("CheckLogin", conn))
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@WriterEmail", Email);
                cmd.Parameters.AddWithValue("@Password", Password);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            divMsg.InnerText = "Login successful.";
                            if(Convert.ToInt32( row["UserType"])==3)
                            {
                                Response.Redirect("Home.aspx");
                            }
                            else if(Convert.ToInt32(row["UserType"]) == 0)
                            {
                                Response.Redirect("ArticleList.aspx");
                            }
                            else if (Convert.ToInt32(row["UserType"]) == 1)
                            {
                                Response.Redirect("ArticleList.aspx?usertype=editor");
                            }

                        }
                    }
                    else
                    {
                        txtemail.Text = "";
                        txtpwd.Text = "";
                        divMsg.InnerText = "Invalid username or password.";

                    }


                }
            }
        }






        //SqlConnection conn = new SqlConnection(GetConnectionString());
        //SqlCommand cmd = new SqlCommand("CheckLogin", conn);
        //cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@WriterEmail", Email);
        //cmd.Parameters.AddWithValue("@Password", Password);
        //conn.Open();
        //SqlDataReader rd = cmd.ExecuteReader();
        //if (rd.HasRows)
        //{
        //    rd.Read();
        //    divMsg.InnerText = "Login successful.";
        //    txtemail.Text = "";
        //    txtpwd.Text = "";


        //    Response.Redirect("Home.aspx");
        //}
        //else
        //{
        //    txtemail.Text = "";
        //    txtpwd.Text = "";
        //    divMsg.InnerText = "Invalid username or password.";
        //}
        
        //conn.Close();
      
    }

    protected void btnForgotPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("ForgotPassword.aspx");
    }
}