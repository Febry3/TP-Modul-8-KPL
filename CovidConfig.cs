using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302220084
{
    public class Config
    {
        public String satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public String pesan_ditolak { get; set; }
        public String pesan_diterima { get; set; }

        public Config() { }

        public Config(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
 
    }

    public class CovidConfig
    {
        public Config config;
        public const String filepath = "../../../config.json";
        public CovidConfig()
        {
            try
            {
                config = ReadConfigFile();
            }
            catch (Exception ex)
            {
                SetDefault();
                WriteNewConfigFile();
              
            }
        }
        private Config ReadConfigFile()
        {
            String jsonData = File.ReadAllText(filepath);
            Config config = JsonSerializer.Deserialize<Config>(jsonData);
            return config;
        }
        private void SetDefault()
        {
            config = new Config(
                satuan_suhu: "celcius",
                batas_hari_demam: 14,
                pesan_ditolak: "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima: "Anda dipersilahkan untuk masuk ke dalam gedung ini");
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions option = new JsonSerializerOptions() { WriteIndented = true };
            String jsonString = JsonSerializer.Serialize(config, option);
            File.WriteAllText(filepath, jsonString);
        }

        public void ubahSatuan()
        {
            
            if (config.satuan_suhu == "celcius")
            {

                config.satuan_suhu = "fahrenheit";
                WriteNewConfigFile() ;
                
            }
            else if (config.satuan_suhu == "fahrenheit")
            {
                config.satuan_suhu = "celcius";
                WriteNewConfigFile();
            }


        }

    }
}
