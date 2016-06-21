using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace sqlclient
{
    /// <summary>
    /// 连接数据库
    /// 1.先建立sqlconnection
    /// 2.设置连接字符串，再用open打开链接
    /// 3.操作完成后，关闭数据库连接
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            //链接字符串格式一定要对Data Source可以选localhost或IP或本地的实例名称，
            //Integrated Security=SSPI 表示用本地登录计算机的账户访问数据库（优先选择）可以通过用户名密码链接user id=  password= ，
            //链接字符串中可以设置连接池的大小Max Pool Size 和Min Pool Size  ,Polling开启连接池 .net中默认开启
            string constring = String.Format(@"Data Source=.\SQLEXPRESS;Initial Catalog=lol;Integrated Security=SSPI;");
            con.ConnectionString = constring;
            //为保证性能 ， 先设置 再打开数据库，无论怎么操作，最后一定要关闭数据库
            try
            {                
                con.Open();
                Console.WriteLine(con.ServerVersion.ToString());
                Console.WriteLine(con.State.ToString());

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                con.Close();
                Console.WriteLine(con.State.ToString());
                Console.ReadKey();
            }

        }
    }
}
