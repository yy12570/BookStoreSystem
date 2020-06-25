using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BookMarketSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT UserEMail,UserPassword,UserName,UserFlag from Users", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if ((string)sdr[0] == email.Text && (string)sdr[1] == password.Text)
                {
                    if ((int)sdr[3] == 99)
                    {

                        Response.Write("<script type=\"text/javascript\">alert(\"登录成功！欢迎管理员 " + (string)sdr[2] + " 登录！\");</script>");

                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert(\"登录成功,！欢迎用户 " + (string)sdr[2] + " 登录！\");</script>");
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert(\"邮箱或密码错误！\");</script>");
                }

            }
            sdr.Close();
            conn.Close();
        }
    }
}
