﻿using System;
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

            SqlCommand cmd = new SqlCommand("SELECT UserEMail,UserPassword,UserName,UserFlag FROM Users", conn);

            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            // Todo: 直接在网站后端循环遍历有点蠢，如果有时间改成数据库函数
            while (sdr.Read())
            {
                if (Convert.ToString(sdr[0]) == email.Text && Convert.ToString(sdr[1]) == password.Text)
                {
                    if (Convert.ToInt32(sdr[3]) == 99)
                    {

                        Response.Write("<script type=\"text/javascript\">alert(\"登录成功！欢迎管理员 " + Convert.ToString(sdr[2]) + " 登录！\");</script>");

                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert(\"登录成功,！欢迎用户 " + Convert.ToString(sdr[2]) + " 登录！\");</script>");
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
