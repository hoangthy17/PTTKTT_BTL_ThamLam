using System;
using System.Collections.Generic;

class BaiToanNguoiGiaoHang
{

    static double KhoangCach(double[] diem1, double[] diem2)
    {
        return Math.Sqrt(Math.Pow(diem1[0] - diem2[0], 2) + Math.Pow(diem1[1] - diem2[1], 2));
    }


    static List<int> TSP(double[][] cacThanhPho)
    {
        int soThanhPho = cacThanhPho.Length;
        List<int> loTrinh = new List<int>();
        bool[] daTham = new bool[soThanhPho];
        double tongKhoangCach = 0.0;


        int thanhPhoHienTai = 0;
        daTham[thanhPhoHienTai] = true;
        loTrinh.Add(thanhPhoHienTai);

        for (int i = 1; i < soThanhPho; i++)
        {
            double khoangCachNganNhat = double.MaxValue;
            int thanhPhoTiepTheo = -1;


            for (int j = 0; j < soThanhPho; j++)
            {
                if (!daTham[j])
                {
                    double khoangCach = KhoangCach(cacThanhPho[thanhPhoHienTai], cacThanhPho[j]);
                    if (khoangCach < khoangCachNganNhat)
                    {
                        khoangCachNganNhat = khoangCach;
                        thanhPhoTiepTheo = j;
                    }
                }
            }

            thanhPhoHienTai = thanhPhoTiepTheo;
            daTham[thanhPhoHienTai] = true;
            loTrinh.Add(thanhPhoHienTai);
            tongKhoangCach += khoangCachNganNhat;
        }

        tongKhoangCach += KhoangCach(cacThanhPho[thanhPhoHienTai], cacThanhPho[loTrinh[0]]);
        loTrinh.Add(loTrinh[0]);

        Console.WriteLine("Tong khoang cach: " + tongKhoangCach);
        return loTrinh;
    }

    static void Main()
    {
        double[][] cacThanhPho = {
            new double[] {0, 0},
            new double[] {1, 3},
            new double[] {4, 3},
            new double[] {6, 1},
            new double[] {3, 0}
        };

        List<int> ketQua = TSP(cacThanhPho);

        Console.WriteLine("Lo trinh toi uu:");
        foreach (var thanhPho in ketQua)
        {
            Console.Write(thanhPho + " ");
        }
    }
}
