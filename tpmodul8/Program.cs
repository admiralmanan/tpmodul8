using System;
using tpmodul8_103022300060;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = CovidConfig.LoadConfig("covid_config.json");

        Console.Write($"Berapa suhu badan anda saat ini? (dalam {config.satuan_suhu}): ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hari = Convert.ToInt32(Console.ReadLine());

        double batasMin, batasMax;

        if (config.satuan_suhu.ToLower() == "celcius")
        {
            batasMin = 36.5;
            batasMax = 37.5;
        }
        else
        {
            batasMin = 97.7;
            batasMax = 99.5;
        }

        if (suhu >= batasMin && suhu <= batasMax && hari < Convert.ToInt32(config.batas_hari_deman))
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        // Panggil UbahSatuan di akhir
        config.UbahSatuan();
        Console.WriteLine($"Satuan suhu sekarang diubah menjadi: {config.satuan_suhu}");
        double suhuSetelahKonversi;

        if (config.satuan_suhu == "fahrenheit")
        {
            suhuSetelahKonversi = (suhu * 9 / 5) + 32;
        }
        else
        {
            suhuSetelahKonversi = (suhu - 32) * 5 / 9;
        }

        Console.WriteLine($"Suhu badan anda setelah dikonversi: {suhuSetelahKonversi:F1}° {config.satuan_suhu}");

    }
}