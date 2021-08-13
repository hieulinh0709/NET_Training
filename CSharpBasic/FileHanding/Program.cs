using System;
using System.IO;
using System.Text;

namespace FileHanding
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileStreamWirterReader
            //FileStreamWirterReader();
            FileInfo();
        }
        #region FileStreamWirterReader
        private static void FileStreamWirterReader()
        {
            try
            {
                string file = @"C:\csharp\filestream.txt";

                //Creating File
                //using: executes them and then releases the objects or resources
                using (FileStream fs = new FileStream(file, FileMode.Create))
                {
                    //Adding current date and time in file
                    byte[] bdata = Encoding.Default.GetBytes(DateTime.Now.ToString());

                    //no method WriteLine
                    fs.Write(bdata, 0, bdata.Length);

                    //Writing file
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine("Hello");
                        writer.WriteLine("Hellow StreamWriter Class");
                        writer.WriteLine("How are you!");
                    }
                }
                
                Console.WriteLine("Data Added: ");

                //Reading File
                string data;
                FileStream fsread = new FileStream(file, FileMode.Open, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fsread))
                {
                    data = sr.ReadToEnd();
                }
                Console.WriteLine(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
        #endregion FileStreamWirterReader

        #region fileinfo
        private static void FileInfo()
        {
            string path = @"C:\csharp\fileinfo.txt";

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            FileInfo file = new FileInfo(path);
            using (StreamWriter sw = file.CreateText())
            {
                sw.WriteLine("Hello FileInfo");
            }

            //Display File Info            
            Console.WriteLine("File Create on : " + file.CreationTime);
            Console.WriteLine("Directory Name : " + file.DirectoryName);
            Console.WriteLine("Full Name of File : " + file.FullName);
            Console.WriteLine("File is Last Accessed on : " + file.LastAccessTime);

            //Deleting File
            Console.WriteLine("Press small y for delete this file");
            try
            {
                char ch = Convert.ToChar(Console.ReadLine());
                if (ch == 'y')
                {
                    if (file.Exists)
                    {
                        file.Delete();
                        Console.WriteLine(path + " Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("File doesn't exist");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Press Enter to Exit");
            }
            Console.ReadKey();
        }
        #endregion fileinfo
    }

}
