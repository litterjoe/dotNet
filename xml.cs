
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xml
{
    /// <summary>
    /// xml读写操作
    /// 1.先创建xmldocment
    /// 2.写入/读取xml
    /// 3.关闭xml
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            
            //写xml,创建xmldocment对象并写入xml
            XmlDocument xmlDoc = new XmlDocument();
            //设置xml属性
            XmlDeclaration xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            //将属性加入到xml中
            xmlDoc.AppendChild(xmlDec);
            //写入根元素，一个xml文件只能有一个根元素
            XmlElement xmlEle = xmlDoc.CreateElement("books");
            xmlDoc.AppendChild(xmlEle);
            //写入根下的元素
            XmlElement xmlEle2 = xmlDoc.CreateElement("book");
            xmlEle2.InnerText="第一本书";
            xmlEle.AppendChild(xmlEle2);

            XmlElement xmlEle3 = xmlDoc.CreateElement("book");
            xmlEle.AppendChild(xmlEle3);
            XmlElement xmlEle4 = xmlDoc.CreateElement("titlt");
            xmlEle4.InnerText = "标题";
            xmlEle3.AppendChild(xmlEle4);
            //保存xml文件
            xmlDoc.Save(@"D:\test.xml");

            try
            {
                xmlDoc.Load(@"D:\test.xml");
                XmlElement rootele = xmlDoc.DocumentElement;
                XmlNodeList nodelist = rootele.GetElementsByTagName("book");
                foreach(XmlNode node in nodelist)
                {
                    Console.WriteLine(node.Name);
                    Console.WriteLine(node.InnerText);
                }
            }
            catch(Exception  e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();

        }
    }
}
