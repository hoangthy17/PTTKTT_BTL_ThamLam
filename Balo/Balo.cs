using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTTKTT_BTL_ThamLam
{
    internal class Balo
    {
        static void Main()
        {
            // Đọc trọng lượng tối đa của ba lô
            Console.WriteLine("Nhap trong luong toi da cua balo:");
            int W = int.Parse(Console.ReadLine());

            // Đọc số loại đồ vật
            Console.WriteLine("Nhap so loai do vat:");
            int n = int.Parse(Console.ReadLine());

            // Khai báo mảng trọng lượng và giá trị
            int[] weights = new int[n];
            int[] values = new int[n];

            // Nhập trọng lượng và giá trị cho từng đồ vật
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap trong luong va gia tri cua do vat {i + 1}:");
                string[] inputs = Console.ReadLine().Split();
                weights[i] = int.Parse(inputs[0]);
                values[i] = int.Parse(inputs[1]);
            }

            // Tính giá trị lớn nhất có thể đạt được
            int maxValue = UnboundedKnapsack(W, weights, values);

            Console.WriteLine("Gia tri lon nhat co the dat duoc la:");
            Console.WriteLine(maxValue);
        }

        static int UnboundedKnapsack(int W, int[] weights, int[] values)
        {
            int n = weights.Length;
            int[] dp = new int[W + 1];

            for (int w = 0; w <= W; w++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (weights[i] <= w)
                    {
                        dp[w] = Math.Max(dp[w], dp[w - weights[i]] + values[i]);
                    }
                }
            }

            return dp[W];
        }
    }

}
