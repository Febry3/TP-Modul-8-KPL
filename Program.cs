using tpmodul8_1302220084;

internal class Program
{
    private static void Main(string[] args)
    {
        double suhu_badan = 0.0f;
        int hari = 0;

        Console.WriteLine("Berapa suhu badan anda saat ini?");
        suhu_badan = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam");
        hari = Convert.ToInt32(Console.ReadLine());

        CovidConfig covidConfig = new CovidConfig();
       

        bool check = false;
        if (covidConfig.config.satuan_suhu == "celcius") { check = suhu_badan >= 36.5 && suhu_badan <= 37.5; }
        if (covidConfig.config.satuan_suhu == "fahrenheit") { check = suhu_badan >= 97.7 && suhu_badan <= 99.5; }

        if (check && hari < covidConfig.config.batas_hari_demam)
        {
            Console.WriteLine(covidConfig.config.pesan_diterima);
        } else
        {
            Console.WriteLine(covidConfig.config.pesan_ditolak);
        }

        covidConfig.ubahSatuan();
    }
}


