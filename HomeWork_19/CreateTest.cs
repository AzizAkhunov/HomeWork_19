using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19
{
    public class CreateTest
    {
        public void TestTuzuvchi()
        {
            Console.WriteLine("Science name");
            string science = Console.ReadLine();
            string newFolderName = "D:\\Tests";
            DirectoryInfo newFilePath;
            if (Directory.Exists(newFolderName) != true)
            {
                newFilePath = Directory.CreateDirectory(newFolderName);
            }
            string path = String.Format("{0}\\{1}.txt", newFolderName, science);

            FileStream YaratilganFanNomi;
            do
            {
                if (File.Exists(path) != true)
                {
                    YaratilganFanNomi = File.Create(path);
                    YaratilganFanNomi.Close();
                    break;
                }
                else
                {
                    Console.WriteLine("File already exists : ");
                    science = Console.ReadLine();
                }
            } while (true);


            Console.WriteLine("How much Question?");
            int SavolSoni = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How much Variants?");
            int VariantSoni = Convert.ToInt32(Console.ReadLine());

            string sAvoLsonlari = SavolSoni.ToString() + "\n------------------------------------------\n";
            string VariantMiqdori = VariantSoni.ToString() + "\n------------------------------------------\n";
            File.WriteAllText(path, sAvoLsonlari);
            File.AppendAllText(path, VariantMiqdori);
            for (int i = 1; i <= SavolSoni; i++)
            {
                Console.Write("{0}-Question: ", i);
                string savol = Console.ReadLine();
                Console.WriteLine("Answers");
                string[] Javoblar = new string[VariantSoni];

                for (int j = 1; j <= VariantSoni; j++)
                {
                    Console.Write("{0} - variant : ", (char)(j + 64));
                    string javobQismi = Console.ReadLine();
                    Javoblar[j - 1] = javobQismi;
                }

                Console.Write("Enter Correct Answer: ");
                string AniqJavob = Console.ReadLine();
                File.AppendAllText(path, savol);
                File.AppendAllText(path, "\n------------------------------------------\n");

                for (int j = 0; j < VariantSoni; j++)
                {
                    if (AniqJavob.Equals((char)(j + 65) + "") == true || AniqJavob.Equals((char)(j + 97) + "") == true)
                    {
                        File.AppendAllText(path, (char)(j + 65) + Javoblar[j]);
                        File.AppendAllText(path, "\n------------------------------------------\n");
                    }
                    else
                    {
                        File.AppendAllText(path, (char)(j + 97) + Javoblar[j]);
                        File.AppendAllText(path, "\n------------------------------------------\n");
                    }
                }
            }
        }
    }
}
