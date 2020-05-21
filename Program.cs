using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace GeraIndiceIPM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gerando índices.");

            string[] arqs;
            string vol;
            StringBuilder sb = new StringBuilder();
            FileInfo f;
            arqs = System.IO.Directory.GetFiles(System.Environment.CurrentDirectory, "VOL*");
            if ((arqs == null) || (arqs.Length == 0))
            {
                Console.WriteLine("Sem arquivos para gerar índice...");
                Console.Read();
                return;
            }

            Console.WriteLine("Encontrado " + arqs.Length + " arquivos...");
            sb.AppendLine("índices gerados em " + DateTime.Now.ToString());

            Array.Sort(arqs, StringComparer.InvariantCultureIgnoreCase);
            vol = "VOL0";
            foreach (string arq in arqs)
            {
                f = new FileInfo(arq);
                if (vol != f.Name.Substring(0, 5))
                {
                    vol = f.Name.Substring(0, 5);
                    sb.AppendLine(vol);
                }
                sb.AppendLine("\t" + f.Name);
            }
            if (File.Exists(System.Environment.CurrentDirectory + "\\Índice.txt"))
                File.Delete(System.Environment.CurrentDirectory + "\\Índice.txt");
            System.IO.File.WriteAllText(System.Environment.CurrentDirectory + "\\Índice.txt", sb.ToString());

            Console.WriteLine("Arquivo de índice gerado com sucesso!");
            Console.Read();

        }
    }
}
