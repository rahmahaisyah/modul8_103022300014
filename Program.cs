// See https://aka.ms/new-console-template for more information
using modul8_103022300014;

class Program
{
    static void Main(string[] args)
    {
        // Membuat objek konfigurasi, membaca dari file JSON saat runtime(Runtime Configuration)
        BankTransferConfig config = new BankTransferConfig();

        // Menampilkan nilai konfigurasi setelah perubahan satuan
        Console.WriteLine($"[DEBUG] Satuan suhu yang digunakan sekarang: {config.config.lang}");

        //program dijalankan program akan menampilkan pesan sebagai berikut 
        //tergantung nilai dari CONFIG1 atau JSON untuk key “lang”
        if (config.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");

        } else
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer: ");
        }

        // Input jumlah uang dari user
        int jumlahTF = Convert.ToInt32(Console.ReadLine());

        if(jumlahTF <= config.config.transfer.threshold)
        {
            Console.WriteLine($"transfer sejumlah {config.config.transfer.low_fee}");
            if(config.config.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {config.config.transfer.low_fee} and Total amount = {config.config.transfer.low_fee + jumlahTF}");
            }
            else
            {
                Console.WriteLine($"Biaya t ransfer = {config.config.transfer.low_fee} dan Total biaya = {config.config.transfer.low_fee + jumlahTF}");
            }
            
            
        }

        if (config.config.lang == "en")
        {
            Console.WriteLine($"Select tranfer methode");
        }
        else
        {
            Console.WriteLine($"Pilih metode transfer");
        }

        foreach (var item in config.config.methods)
        {
            Console.WriteLine(item);

        }

        if (config.config.lang == "en")
        {
            Console.WriteLine($"Please type {config.config.confirmation.en} to confirm the transaction:");
            string en = Console.ReadLine();
            if (en == config.config.lang) {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("cancelled");
            }
        }
        else
        {
            Console.WriteLine($"Ketik {config.config.confirmation.id} konfirmasi transaksi:");
            string en = Console.ReadLine();
            if (en == config.config.lang)
            {
                Console.WriteLine("berhasi;");
            }
            else
            {
                Console.WriteLine("batal");
            }
        }


    }
}

