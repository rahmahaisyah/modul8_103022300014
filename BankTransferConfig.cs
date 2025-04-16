using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300014
{
    // Kelas ini merepresentasikan konfigurasi Transfer bank yang dapat dibaca dan disimpan ke file eksternal.
    // Menerapkan konsep Runtime Configuration (nilai bisa berubah tanpa compile ulang).
    internal class BankTransferConfig
    {
        public class Transfer
        {

            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }

        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }

        public class Config
        {
            // Properti konfigurasi yang akan disimpan/dibaca dari file JSON
            public string lang { get; set; }
            public Transfer transfer { get; set; }

            public List<string> methods { get; set; }
            public Confirmation confirmation { get; set; }
        }


        // Lokasi file konfigurasi
        public const string filePath = @"bank_transfer_config.json";
        //konstructor convig
        public Config config;

        //set semua velue defult
        public void SetDefault() {
            config = new Config();
            config.lang = "en";
            config.transfer.threshold = 25000000;
            config.transfer.low_fee = 6500;
            config.transfer.high_fee = 15000;
            config.methods = ["“RTO", "(real-time)”", "“SKN”", "“RTGS”", "“BI", "FAST”"];
            config.confirmation.en = "yes";
            config.confirmation.id = "ya";
        }

        public Config ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
    }
}
