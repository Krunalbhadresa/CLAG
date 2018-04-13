using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    string ArticleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        ArticleId = Request.QueryString["Aid"];
        string mode = Request.QueryString["mode"];
        if (!IsPostBack)
        {
            editor.InnerText = "";

            if (mode == "view")
            {
                ViewFooter.Attributes["class"] = ViewFooter.Attributes["class"].Replace("clsDspNone", "clsDspBlock");

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ViewArticlebyArticleId", conn))
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(ArticleId));
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                editor.InnerText = row["ArticleContent"].ToString();
                                title.InnerText = row["ArticleTitle"].ToString();

                                editor.Disabled = true;
                                title.Disabled = true;


                            }


                        }
                    }
                }


            }

            else if (mode == "update")
            {
                UpdateFooter.Attributes["class"] = UpdateFooter.Attributes["class"].Replace("clsDspNone", "clsDspBlock");
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ViewArticlebyArticleId", conn))
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(ArticleId));
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                editor.InnerText = row["ArticleContent"].ToString();
                                title.InnerText = row["ArticleTitle"].ToString();

                                editor.Disabled = false;
                                title.Disabled = false;


                            }


                        }
                    }
                }


            }
            else if (mode == "viewpage")
            {

                ViewPageFooter.Attributes["class"] = ViewPageFooter.Attributes["class"].Replace("clsDspNone", "clsDspBlock");

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ViewArticlebyArticleId", conn))
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(ArticleId));
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                editor.InnerText = row["ArticleContent"].ToString();
                                title.InnerText = row["ArticleTitle"].ToString();

                                editor.Disabled = true;
                                title.Disabled = true;


                            }


                        }
                    }
                }
            }
            else if (mode == "EditorView")
            {
                EditorViewFooter.Attributes["class"] = EditorViewFooter.Attributes["class"].Replace("clsDspNone", "clsDspBlock");

                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ViewArticlebyArticleId", conn))
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(ArticleId));
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);

                            foreach (DataRow row in dt.Rows)
                            {
                                editor.InnerText = row["ArticleContent"].ToString();
                                title.InnerText = row["ArticleTitle"].ToString();

                                editor.Disabled = true;
                                title.Disabled = true;


                            }


                        }
                    }
                }

            }

            else
            {
                UpdateFooter.Attributes["class"] = UpdateFooter.Attributes["class"].Replace("clsDspBlock", "clsDspNone");
                ViewFooter.Attributes["class"] = ViewFooter.Attributes["class"].Replace("clsDspBlock", "clsDspNone");

                AddFooter.Attributes["class"] = AddFooter.Attributes["class"].Replace("clsDspNone", "clsDspBlock");
                editor.Disabled = false;
                title.Disabled = false;
            }
        }
    }
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config


    }

    protected void btnCancel_Click(Object sender, EventArgs e)

    {
        Response.Redirect("Home.aspx");
    }

    protected void btnBack_Click(Object sender, EventArgs e)

    {
        Response.Redirect("ArticleList.aspx");
    }
    
        protected void btnViewBack_Click(Object sender, EventArgs e)

    {
        Response.Redirect("ArticleList.aspx");
    }

    protected void btnEditorBack_Click(Object sender, EventArgs e)

    {
        Response.Redirect("ArticleList.aspx?usertype=editor");
    }

    protected void btnAcceptArticle_Click(object sender, EventArgs e)
    {
        SqlConnection conn1 = new SqlConnection(GetConnectionString());
        SqlCommand cmd1 = new SqlCommand("sp_AcceptArticle", conn1);
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(ArticleId));
        conn1.Open();
        int k = cmd1.ExecuteNonQuery();
        if (k != 0)
        {
            //txtRequestEmail.Text = ReqEmail;
            //txtTwitterHandle.Text = ReqTwitter;
            //txtMediumUsername.Text = ReqMedium;
            //txtStoryLink.Text = ReqStory;
            //txtReason.InnerHtml = ReqReason;



            //SqlConnection conn = new SqlConnection(GetConnectionString());
            //SqlCommand cmd = new SqlCommand("sp_InsertWriterDetails", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@WriterEmail", ReqEmail.ToString());
            //cmd.Parameters.AddWithValue("@WriterTwitterUName", ReqTwitter.ToString());
            //cmd.Parameters.AddWithValue("@WriterMediumUName", ReqMedium.ToString());
            //cmd.Parameters.AddWithValue("@JoiningDate", Convert.ToDateTime(DateTime.Now));

            //conn.Open();
            //int r = cmd.ExecuteNonQuery();
            //if (r != 0)
            //{

            //}
            //conn.Close();

        }
        conn1.Close();
        Response.Redirect("Home.aspx");
    }

    protected void btnRejectArticle_Click(object sender, EventArgs e)
    {
        SqlConnection conn1 = new SqlConnection(GetConnectionString());
        SqlCommand cmd1 = new SqlCommand("sp_RejectArticle", conn1);
        cmd1.CommandType = CommandType.StoredProcedure;
        cmd1.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(ArticleId));
        conn1.Open();
        int k = cmd1.ExecuteNonQuery();
        if (k != 0)
        {
            //txtRequestEmail.Text = ReqEmail;
            //txtTwitterHandle.Text = ReqTwitter;
            //txtMediumUsername.Text = ReqMedium;
            //txtStoryLink.Text = ReqStory;
            //txtReason.InnerHtml = ReqReason;



            //SqlConnection conn = new SqlConnection(GetConnectionString());
            //SqlCommand cmd = new SqlCommand("sp_InsertWriterDetails", conn);
            //cmd.CommandType = CommandType.StoredProcedure;-
            //cmd.Parameters.AddWithValue("@WriterEmail", ReqEmail.ToString());
            //cmd.Parameters.AddWithValue("@WriterTwitterUName", ReqTwitter.ToString());
            //cmd.Parameters.AddWithValue("@WriterMediumUName", ReqMedium.ToString());
            //cmd.Parameters.AddWithValue("@JoiningDate", Convert.ToDateTime(DateTime.Now));

            //conn.Open();
            //int r = cmd.ExecuteNonQuery();
            //if (r != 0)
            //{

            //}
            //conn.Close();

        }
        conn1.Close();
        Response.Redirect("Home.aspx");
    }

    protected void btnSave_Click(Object sender, EventArgs e)
    {
        string articleText,articleTitle;
        articleText = editor.InnerText;
        articleTitle = title.InnerText;

        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd = new SqlCommand("sp_InsertArticleDetails", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ArticleTitle", articleTitle.ToString());
        cmd.Parameters.AddWithValue("@ArticleContent", articleText.ToString());
     //   cmd.Parameters.AddWithValue("@AdditionalFile", null);
        cmd.Parameters.AddWithValue("@WriterId",1);
        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
        cmd.Parameters.AddWithValue("@LMDate", DateTime.Now);   
        cmd.Parameters.AddWithValue("@Status", "Draft");
        
        conn.Open();
        int k = cmd.ExecuteNonQuery();
        if (k != 0)
        {
            editor.InnerHtml= "";
            title.InnerHtml = "";
            

            divMsg.InnerText = "Article saved successfully";

            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
            //"<script>$('#myModal').modal('show');</script>", false);
            // OpenWindow(sender, e);
        }
        conn.Close();



    }


    protected void btnUpdateSave_Click(Object sender, EventArgs e)
    {
        string articleText, articleTitle;
        articleText = editor.InnerText;
        articleTitle = title.InnerText;

        SqlConnection conn = new SqlConnection(GetConnectionString());
        SqlCommand cmd = new SqlCommand("sp_UpdateArticleDetails", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ArticleTitle", articleTitle.ToString());
        cmd.Parameters.AddWithValue("@ArticleContent", articleText.ToString());
        cmd.Parameters.AddWithValue("@ArticleId", Convert.ToInt32(ArticleId));
        cmd.Parameters.AddWithValue("@LMDate", DateTime.Now);
       


        conn.Open();
        int k = cmd.ExecuteNonQuery();
        if (k != 0)
        {
            editor.InnerHtml = "";
            title.InnerHtml = "";


            divMsg.InnerText = "Article updated successfully";
            Response.Redirect("ArticleList.aspx");

        }
        conn.Close();
       




    }
    protected void btnClear_Click(Object sender, EventArgs e)

    {
        editor.InnerHtml = "";

    }
}