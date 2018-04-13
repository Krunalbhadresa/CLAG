using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WriterView : System.Web.UI.Page
{
    string WriterId;
    string ReqEmail, ReqTwitter, ReqMedium, ReqStory, ReqReason;
    protected void Page_Load(object sender, EventArgs e)
    {

        ViewFooter.Attributes["class"] = "clsDspNone";

        WriterId = Request.QueryString["Rid"];
        string mode = Request.QueryString["mode"];

        if (mode == "view")
        {
            ViewFooter.Attributes["class"] = ViewFooter.Attributes["class"].Replace("clsDspNone", "clsDspBlock");
            txtRequestEmail.ReadOnly = true;
            txtTwitterHandle.ReadOnly = true;
            txtMediumUsername.ReadOnly = true;
           


            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ViewWriterDetailsbyWriterId", conn))
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WriterId", Convert.ToInt32(WriterId));
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            ReqEmail = row["WriterEmail"].ToString();
                            ReqTwitter = row["WriterTwitterUName"].ToString();
                            ReqMedium = row["WriterMediumUName"].ToString();
                            

                            txtRequestEmail.Text = row["WriterEmail"].ToString();
                            txtTwitterHandle.Text = row["WriterTwitterUName"].ToString();
                            txtMediumUsername.Text = row["WriterMediumUName"].ToString();
                           

                        }


                    }
                }
            }


        }

    }

    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config


    }

    protected void btnProEditor_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd = new SqlCommand("sp_InsertEditorDetails", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EditorName", ReqEmail.ToString());
        cmd.Parameters.AddWithValue("@EEmailAddress", ReqEmail.ToString());
        cmd.Parameters.AddWithValue("@ETwitterHandle", ReqTwitter.ToString());
        cmd.Parameters.AddWithValue("@EMediumUsername", ReqMedium.ToString());
        cmd.Parameters.AddWithValue("@EEnglish", false);
        cmd.Parameters.AddWithValue("@EFrench", false);
        cmd.Parameters.AddWithValue("@ESpanish", false);
        cmd.Parameters.AddWithValue("@EPortuguese", false);
        //      cmd.Parameters.AddWithValue("@EBrazilian", false);
        conn.Open();
        int k = cmd.ExecuteNonQuery();
        if (k != 0)
        {
           

            divMsg.InnerText = "Editor added successfully";

            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
            //"<script>$('#myModal').modal('show');</script>", false);
            // OpenWindow(sender, e);
        }
        conn.Close();



        Response.Redirect("Home.aspx");
    }


    protected void btnProReviwer_Click(object sender, EventArgs e)
    {

        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd = new SqlCommand("sp_InsertReviewerDetails", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ReviewerName", ReqEmail.ToString());
        cmd.Parameters.AddWithValue("@RTwitterHandle",  ReqTwitter.ToString());
        cmd.Parameters.AddWithValue("@RMediumUsername", ReqMedium.ToString());
        cmd.Parameters.AddWithValue("@REmailAddress", ReqEmail .ToString());
        cmd.Parameters.AddWithValue("@REnglish", false);
        cmd.Parameters.AddWithValue("@RFrench", false);
        cmd.Parameters.AddWithValue("@RSpanish", false);
        cmd.Parameters.AddWithValue("@RPortuguese", false);
        //      cmd.Parameters.AddWithValue("@EBrazilian", false);
        conn.Open();
        int k = cmd.ExecuteNonQuery();
        if (k != 0)
        {


            divMsg.InnerText = "Reviewer added successfully";

            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
            //"<script>$('#myModal').modal('show');</script>", false);
            // OpenWindow(sender, e);
        }
        conn.Close();



        Response.Redirect("Home.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");

    }

    protected void btnUpdateCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditorList.aspx");
    }


    protected void OpenWindow(object sender, EventArgs e)
    {
        string url = "Registration.aspx";
        string s = "window.open('" + url + "', 'popup_window', 'width=300,height=100,left=100,top=100,resizable=yes');";
        ClientScript.RegisterStartupScript(this.GetType(), "Registration Successfull", s, true);
    }

}