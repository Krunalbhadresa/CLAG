using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ArticleList : System.Web.UI.Page
{
    DataSet ds = null;
    StringBuilder sb = new StringBuilder();

    DataSet ds1 = null;
    StringBuilder sb1 = new StringBuilder();
    string usertype;
    protected void Page_Load(object sender, EventArgs e)
    {

        usertype = Request.QueryString["usertype"]; //usertype = editor
        try
        {
            if (usertype == "editor")
            {
                BindEditorTable();
            }
            else
            { BindTable(); }
            
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
    }

    protected void addArticle_Click(Object sender, EventArgs e)

    {
        Response.Redirect("Login.aspx");
    }
    public string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringName"].ConnectionString;
        //the "ConnStringName" is the name of your Connection String that was set up from the Web.Config


    }

    public void BindTable()
    {
        try
        {
            ds = GetData();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                sb.Append("<table class='display table table-hover' width='100 % ' id='myTable'>");
                sb.Append("<thead>");
                sb.Append("<tr><th></th>");
                sb.Append("<th>Title</th>");
                sb.Append("<th>Status</th>");
                sb.Append("<th>Last Modification Date</th>");
                sb.Append("<th scope='col'>View</th>");
                sb.Append("<th scope='col'>Edit</th>");
                sb.Append("<th scope='col'>Delete</th>");

                sb.Append("</tr>");
                sb.Append("</thead><tbody>");

                //sb.Append("</table>");
                //      sb.Append("<table id='myTable' border='1' cellpadding='0' cellspacing='0' width='100%'>");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.Append("<td>" + Convert.ToString(i + 1) + "</td>");
                    sb.Append("<td class='ArticleTitle'>" + Convert.ToString(ds.Tables[0].Rows[i]["ArticleTitle"]) + "</td>");
                    sb.Append("<td class='Status'>" + Convert.ToString(ds.Tables[0].Rows[i]["Status"]) + "</td>");
                    sb.Append("<td class='LMDate'>" + Convert.ToString(ds.Tables[0].Rows[i]["LMDate"]) + "</td>");
                    sb.Append("<td><button type='button' class='btnViewArticlePage' ArticleId='" + Convert.ToString(ds.Tables[0].Rows[i]["ArticleId"]) + "'>View</button></td>");
                    sb.Append("<td><button type='button' class='btnUpdateArticle' ArticleId='" + Convert.ToString(ds.Tables[0].Rows[i]["ArticleId"]) + "'>Update</button></td>");
                    sb.Append("<td><button type='button' class='btnDeleteArticle' ArticleId='" + Convert.ToString(ds.Tables[0].Rows[i]["ArticleId"]) + "'>Delete</button></td>");

                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                divArticleGrid.InnerHtml = Convert.ToString(sb);
            }
            else
            {
                Response.Write("NO DATA FOUND");
            }
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
        finally
        {
            if (ds != null)
            {
                ds.Dispose();
            }
        }
    }

    public void BindEditorTable()
    {
        try
        {
            ds1 = GetEditorData();
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                sb1.Append("<table class='display table table-hover' width='100 % ' id='myArticleTable'>");
                sb1.Append("<thead>");
                sb1.Append("<tr><th></th>");
                sb1.Append("<th>Title</th>");
                sb1.Append("<th>Status</th>");
                sb1.Append("<th>Last Modification Date</th>");
                sb1.Append("<th scope='col'>View</th>");
                sb1.Append("<th scope='col'>Edit</th>");
                

                sb1.Append("</tr>");
                sb1.Append("</thead><tbody>");

                //sb.Append("</table>");
                //      sb.Append("<table id='myTable' border='1' cellpadding='0' cellspacing='0' width='100%'>");
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    sb1.Append("<tr>");
                    sb1.Append("<td>" + Convert.ToString(i + 1) + "</td>");
                    sb1.Append("<td class='ArticleTitle'>" + Convert.ToString(ds1.Tables[0].Rows[i]["ArticleTitle"]) + "</td>");
                    sb1.Append("<td class='Status'>" + Convert.ToString(ds1.Tables[0].Rows[i]["Status"]) + "</td>");
                    sb1.Append("<td class='LMDate'>" + Convert.ToString(ds1.Tables[0].Rows[i]["LMDate"]) + "</td>");
                    sb1.Append("<td><button type='button' class='btnEditorView' ArticleId='" + Convert.ToString(ds1.Tables[0].Rows[i]["ArticleId"]) + "'>View</button></td>");
                    sb1.Append("<td><button type='button' class='btnArticleEditbyEditor' ArticleId='" + Convert.ToString(ds1.Tables[0].Rows[i]["ArticleId"]) + "'>Update</button></td>");
                   

                    sb1.Append("</tr>");
                }
                sb1.Append("</tbody></table>");
                divEditorGrid.InnerHtml = Convert.ToString(sb1);
            }
            else
            {
                Response.Write("NO DATA FOUND");
            }
        }
        catch (Exception err)
        {
            Response.Write(err.Message);
        }
        finally
        {
            if (ds1 != null)
            {
                ds1.Dispose();
            }
        }
    }

    public DataSet GetData()
    {
        DataSet ds = new DataSet();
        try
        {

            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand("sp_ViewArticleDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            conn.Open();
            da.Fill(ds);
            conn.Close();
        }
        catch (Exception err)
        {
            throw err;
        }
        return ds;
    }
    public DataSet GetEditorData()
    {
        DataSet ds1 = new DataSet();
        try
        {

            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand("sp_ViewArticleDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);

            conn.Open();
            da1.Fill(ds1);
            conn.Close();
        }
        catch (Exception err)
        {
            throw err;
        }
        return ds1;
    }

}