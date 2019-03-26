using System;
using System.IO;

namespace GetPathFileName
{
    class Program
    {
        public static string FileName = "";

        public static void Main(string[] args)
        {
            bool isContinute = true;
            WriteMessage("结束程序请输入1，默认排除文件名：min.js,jquery");
            WriteMessage("请输入要获取文件名的路径：");
            string path = Console.ReadLine();
            do
            {
                if (string.IsNullOrEmpty(path))
                {
                    WriteMessage("路径不存在！请重新输入");
                }
                else
                {
                    DirectoryInfo dir = new DirectoryInfo(path);
                    if (dir.Exists == false)
                    {
                        WriteMessage("路径不存在！请重新输入");
                    }
                    else
                    {
                        FileName = "";
                        GetChildDicsName(dir);
                        WriteMessage(FileName);
                        Console.WriteLine("获取该路径下文件名成功！你可以继续输入新的路径");
                    }
                }
                path = Console.ReadLine();
                isContinute = path != "1";
            } while (isContinute);
        }

        public static DirectoryInfo[] GetChildDicsName(DirectoryInfo dir)
        {
            FileInfo[] fileArray = dir.GetFiles();
            DirectoryInfo[] childDirs = dir.GetDirectories();

            foreach (FileInfo file in fileArray)
            {
                if (!file.Name.Contains("min.js") && !file.Name.Contains("jquery"))
                {
                    FileName += file.Name + ",";
                }
            }
            if (childDirs.Length > 0)
            {
                foreach (DirectoryInfo dirChild in childDirs)
                {
                    GetChildDicsName(dirChild);
                }
            }
            return childDirs;
        }

        public static void WriteMessage(string message)
        {
            Console.WriteLine(message);
            //File.Create(@"C:\Users\Public\Desktop\test.txt");
            FileStream fs = File.Open(@"C:\Users\Administrator\Desktop\fileName.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(message);  //这里是写入的内容
            sw.Close();
            fs.Close();
        }
    }
}