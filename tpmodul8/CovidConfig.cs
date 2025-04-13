using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_103022300060
{
    class CovidConfig
    {
        public string satuan_suhu { get; set; } = "celcius";
        public int batas_hari_deman { get; set; } = 14;
        public string pesan_ditolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string pesan_diterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        public static CovidConfig LoadConfig(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var config = JsonSerializer.Deserialize<CovidConfig>(json);

                // Assign default jika masih CONFIG1-4
                if (config.satuan_suhu == "CONFIG1") config.satuan_suhu = "celcius";
                if (config.batas_hari_deman == 0 || config.batas_hari_deman.ToString() == "CONFIG2") config.batas_hari_deman = 14;
                if (config.pesan_ditolak == "CONFIG3") config.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
                if (config.pesan_diterima == "CONFIG4") config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

                return config;
            }

            // fallback default
            return new CovidConfig();
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
                satuan_suhu = "fahrenheit";
            else
                satuan_suhu = "celcius";
        }
    }
}
