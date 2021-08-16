using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {

            #region basic
            var t1 = TestAsync01.Async1("x", "y");
            var t2 = TestAsync01.Async2();

            // Làm gì đó khi t1, t2 đang chạy
            Console.WriteLine("Task1, Task2 đang chạy");


            await t1; // chờ t1 kết thúc
            Console.WriteLine("Làm gì đó khi t1 kết thúc");

            await t2; // chờ t2 kết thúc
            #endregion basic

            #region downloadfile
            Console.WriteLine("*************************************************************");
            string url = "https://github.com/microsoft/vscode/archive/1.48.0.tar.gz";
            var taskdonload = DownloadAsync.DownloadFile(url);
            //..
            Console.WriteLine("Làm gì đó khi file đang tải");
            //..
            await taskdonload;
            Console.WriteLine("Làm gì đó khi file tải xong");
            #endregion downloadfile
        }
    }
}
