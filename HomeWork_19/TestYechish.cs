using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_19
{
    public class TestYechish
    {
        public void TestYech()
        {

            Console.WriteLine("Fanni Tanlang");
            string[] Files = Directory.GetFiles("D:\\Tests");
            int k = 1;
            foreach (var file in Files)
            {
                string s = file.Replace("D:\\Tests\\", "");
                Console.WriteLine("{0} : {1}", k, s);
                k++;
            }
            k = 1;
            string filePath = Files[0];
            int EnterTr = Convert.ToInt32(Console.ReadLine());
            foreach (var file in Files)
            {
                if (k == EnterTr)
                {
                    filePath = file;
                    break;
                }
                k++;
            }


            string[] AllData = File.ReadAllLines(filePath);
            int questionNum = Convert.ToInt32(AllData[0].Trim());
            int variantNum = Convert.ToInt32(AllData[2].Trim());
            int oneQuestion = 1 + variantNum;
            string con = "";
            List<string> Tests = new List<string>();
            //for (int i = 0; i < AllData.Length;i++) Console.Write(AllData[i]);
            for (int i = 4; i < AllData.Length; i++)
            {
                if (AllData[i].StartsWith("-------------------------------"))
                {
                    Tests.Add(con);
                    con = "";
                }
                else
                {
                    con += AllData[i];
                }
            }
            string[,] listOfTests = new string[questionNum, oneQuestion];
            int savolSana = 0;
            Console.WriteLine(Tests.Count);
            for (int i = 0; i < Tests.Count; i++)
            {
                if (i % oneQuestion == 0 && i != 0) savolSana++;
                listOfTests[savolSana, i % oneQuestion] = Tests[i];

            }
            string trueAnswers = "";
            string StudentAnswers = "";
            for (int i = 0; i < questionNum; i++)
            {
                Console.WriteLine(listOfTests[i, 0]);
                for (int j = 1; j < oneQuestion; j++)
                {
                    if ((int)listOfTests[i, j][0] < 91)
                    {
                        trueAnswers += listOfTests[i, j][0];
                    }
                    Console.WriteLine("{0}    {1}", (char)(64 + j), listOfTests[i, j].Substring(1));
                }
                Console.Write("Javobingizni kiriting : ");
                string OquvchiJavobi = Console.ReadLine().ToUpper();
                StudentAnswers += OquvchiJavobi;
            }
            Console.WriteLine("O'quvchining javoblari");
            Console.WriteLine(StudentAnswers);
            Console.WriteLine("haqiqiy Javoblar");
            Console.WriteLine(trueAnswers);
        }

    }
}
