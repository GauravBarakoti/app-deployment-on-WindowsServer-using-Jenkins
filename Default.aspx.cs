using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // You don't have any code for the Page_Load event, so you can remove it.
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string connectionString = "Data Source=dotnetdb1.cvyxdllt3sz6.us-east-1.rds.amazonaws.com;";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string query = "SELECT * FROM info";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", TextBox1.Text);
                cmd.Parameters.AddWithValue("@password", TextBox2.Text);

                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        Response.Redirect("Redirectform.aspx");
                    }
                    else
                    {
                        Label1.Text = "Your username and password are incorrect";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}
