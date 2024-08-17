using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lựa_chọn_HĐ
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            // Nhập số lượng hoạt động
            Console.WriteLine("Nhap so luong hoat dong:");
            int n = int.Parse(Console.ReadLine());

            // Khai báo mảng thời gian bắt đầu và kết thúc
            int[] startTimes = new int[n];
            int[] endTimes = new int[n];

            // Nhập thời gian bắt đầu và kết thúc cho từng hoạt động
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thoi gian bat dau va thoi gian ket thuc {i + 1}:");
                string[] inputs = Console.ReadLine().Split();
                startTimes[i] = int.Parse(inputs[0]);
                endTimes[i] = int.Parse(inputs[1]);
            }

            // Lựa chọn hoạt động
            var selectedActivities = SelectActivities(startTimes, endTimes);

            // In kết quả
            Console.WriteLine("Cac hoat dong duoc chon:");
            foreach (var activity in selectedActivities)
            {
                Console.WriteLine($"Hoat dong {activity}");
            }
        }

        static int[] SelectActivities(int[] startTimes, int[] endTimes)
        {
            int n = startTimes.Length;

            // Tạo một mảng hoạt động và sắp xếp theo thời gian kết thúc
            var activities = Enumerable.Range(0, n)
                                       .Select(i => new { Index = i, Start = startTimes[i], End = endTimes[i] })
                                       .OrderBy(a => a.End)
                                       .ToArray();

            var selectedActivities = new System.Collections.Generic.List<int>();

            // Chọn hoạt động đầu tiên
            int lastEndTime = -1;

            foreach (var activity in activities)
            {
                if (activity.Start > lastEndTime)
                {
                    selectedActivities.Add(activity.Index + 1); // +1 để có số thứ tự bắt đầu từ 1
                    lastEndTime = activity.End;
                }
            }

            return selectedActivities.ToArray();
        }
    }

}
