using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace excelRead
{
    class Program
    {
        /// <summary>
        /// 使用OLEDB方式打开excel
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //设置连接字符串
            string constr = "Provider = Microsoft.ACE.OLEDB.12.0; " + "Data Source = ID.xlsx" + "; " + "; Extended Properties =\"Excel 12.0;HDR=YES;IMEX=1\"";
            //设置连接命令
            string cmdstr = "SELECT * FROM [Sheet1$]";
            //判断数据文件是否存在
            if (!File.Exists("ID.xlsx"))
            {
                Console.WriteLine("文件不存在！");
            }
            while (true)
            {
                string inPut="";
                do
                {
                    Console.WriteLine("输入查询号码！");
                     inPut = Console.ReadLine();
                }
                
                while (!StrIsInt(inPut)) ;
                
                int num = Convert.ToInt32(inPut);
                
                
                try
                {
                    //creat connection
                    OleDbConnection con = new OleDbConnection(constr);
                    con.Open();
                    //set connectioncmd
                    OleDbDataAdapter data = new OleDbDataAdapter(cmdstr, con);
                    DataSet ds = new DataSet();
                    data.Fill(ds, "[Sheet1$]");
                    DataTable dt = ds.Tables[0];
                    DataRow dro = dt.Rows[num];
                    foreach (DataColumn dco in dt.Columns)
                    {
                        Console.WriteLine(dco.ColumnName);
                    }



                }
                catch
                {
                    Console.WriteLine("数据查询失败");

                }

            }

        }
        //判断输入的字符串是不是数字
        public static bool StrIsInt(string Str)
        {
            bool flag = true;
            if (Str != "")
            {
                for (int i = 0; i < Str.Length; i++)
                {
                    if (!Char.IsNumber(Str, i))
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }
    }
}
