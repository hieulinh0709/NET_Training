using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    public class DownloadAsync
    {
        public static async Task DownloadFile(string url)
        {
            Action downloadaction = () => {
                //WebClient có sẵn phương thức đồng bộ
                using (var client = new WebClient())
                {
                    Console.WriteLine("Starting download ..." + url);
                    // mảng byte tải về
                    byte[] data = client.DownloadData(new Uri(url));

                    // Lấy tên file để lưu
                    string filename = System.IO.Path.GetFileName(url);
                    System.IO.File.WriteAllBytes(filename, data);
                }
            };

            Task task = new Task(downloadaction);
            task.Start();

            await task;
            Console.WriteLine("Đã hoàn thành tải file");
        }
    }
}
