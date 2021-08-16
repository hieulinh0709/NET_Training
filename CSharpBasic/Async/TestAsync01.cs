using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    public class TestAsync01
    {
        // Viết ra màn hình thông báo có màu
        public static void WriteLine(string s, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(s);
        }

        // Tạo và chạy Task, sử dụng delegate Func (có kiểu trả về)
        public static async Task<string> Async1(string thamso1, string thamso2)
        {
            // tạo biến delegate trả về kiểu string, có một tham số object
            Func<object, string> myfunc = (object thamso) => {
                // Đọc tham số (dùng kiểu động - xem kiểu động để biết chi tiết)
                dynamic ts = thamso;
                for (int i = 1; i <= 10; i++)
                {
                    //  Thread.CurrentThread.ManagedThreadId  trả về ID của thread đạng chạy
                    WriteLine($"Async1: action: {i} , ThreadId: {Thread.CurrentThread.ManagedThreadId} Tham số {ts.x} {ts.y}",
                        ConsoleColor.Green);
                    Thread.Sleep(500);
                }
                return $"Kết thúc Async1! {ts.x}";
            };

            Task<string> task = new Task<string>(myfunc, new { x = thamso1, y = thamso2 });
            task.Start(); // chạy thread

            await task;

            // Từ đây là code sau await (trong Async1) sẽ chỉ thi hành khi task kết thúc
            TestAsync01.WriteLine("Async1 - làm gì đó khi task chạy xong", ConsoleColor.Red);
            string ketqua = task.Result;       // Đọc kết quả trả về của task - không phải lo block thread gọi Async1

            Console.WriteLine("ketqua: " +ketqua);        // In kết quả trả về của task
            return ketqua;
        }

        // Tạo và chạy Task, sử dụng delegate Action (không kiểu trả về)
        public static async Task Async2()
        {

            Action myaction = () => {
                for (int i = 1; i <= 10; i++)
                {
                    WriteLine($"Async2: action: {i} , ThreadId: {Thread.CurrentThread.ManagedThreadId}",
                        ConsoleColor.Yellow);
                    Thread.Sleep(2000);
                }
            };
            Task task = new Task(myaction);
            task.Start();

            await task;

            // Làm gì đó sau khi chạy Task ở đây
            Console.WriteLine("Async2: Làm gì đó sau khi task kết thúc");

            // Không cần trả về vì gốc đồng bộ trả về void, đồng bộ sẽ trả về Task
        }
    }
}
