using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace Laba1

{ 
  public  class Program
    {

      public static bool f;

        public struct triangle
        {
            public double a, b, gamma, f;
        }

        public static double ToRad(double x)
        {
            x = (x * Math.PI / 180);
            return x;
        }

        public static double ToGrad(double x)
        {
            x = (x * 180 / Math.PI);
            return x;
        }

        static void Main()
        {
           String path = Console.ReadLine();
           String outpath = Console.ReadLine();
           try
            {
                ReadFile(path, outpath);
            }
            catch
            {
                Console.WriteLine("Ошибка");
            }
        }

        public static void ReadFile(string path, string outpath)
        {
                List<triangle> triangles = new List<triangle>();
                List<string> output = new List<string>();
                List<string> log = new List<string>();

                StreamWriter OutFile = new StreamWriter(outpath);

                if (!File.Exists(path))  throw new FileNotFoundException(string.Format("Файл не найден"));
                else
                {                   
                    StreamReader str = new StreamReader(path);
                    string Line = "";                    
                    if (str.BaseStream.Length == 0) 
                     {                        
                        Console.WriteLine("Файл пуст");
                        output.Add("Неправильное количество параметров");
                        log.Add("Неправильное количество параметров"); 
                        throw new FileLoadException();                      
                     }

                    else
                        while ((Line = str.ReadLine()) != null)
                        {
                            Line.Replace('.', ',');
                            string[] Lines = Line.Split(';');
                            if (Lines.Length == 3)
                            {
                                try
                                {
                                    triangles.Add(new triangle
                                    {
                                        a = Convert.ToDouble(Lines[0]),
                                        b = Convert.ToDouble(Lines[1]),
                                        gamma = Convert.ToDouble(Lines[2])
                                    });
                                }
                                catch
                                {
                                    output.Add("Неправильный формат данных");
                                    log.Add("Неправильный формат данных");
                                }
                            }
                            else
                            {
                                output.Add("Неправильное количество параметров");
                                log.Add("Неправильное количество параметров");
                            }
                        }

                    str.Close();

                }
                for (int i = 0; i < triangles.Count; i++)
                {
                    double[] res = Calculate(triangles[i].a, triangles[i].b, triangles[i].gamma);
                    if (res[0] != -1)
                    {
                        output.Add(string.Join("; ", res));
                        log.Add(res[2] + "; " + res[3] + "; " + res[4]);
                    }
                    else
                    {
                        output.Add("Неправильные данные");
                        log.Add("Неправильные данные");
                    }
                }

                for (int i = 0; i < output.Count; i++)
                {
                    OutFile.WriteLine(output[i]); 
                    Console.WriteLine(log[i]);
                }

                OutFile.Close();            

       Console.ReadLine(); 
     }
       
        public static double[] Calculate(double a, double b, double gamma)
        {

            if ((a > 0) && (b > 0) && ((gamma > 0) && (gamma < 180)))
            {
                double gamma1 = ToRad(gamma);
                double c, alpha, betta;

                c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(gamma1));
                alpha = Math.Acos((b * b + c * c - a * a) / (2 * b * c));
                betta = Math.Acos((a * a + c * c - b * b) / (2 * a * c));

                alpha = ToGrad(alpha);
                betta = ToGrad(betta);
                gamma1 = ToGrad(gamma1);
                return new double[] { a, b, Math.Round(c, 4), Math.Round(alpha, 4), Math.Round(betta, 4), Math.Round(gamma1, 4) };
            }
            else
            {
                return new double[] { -1 };
            }
        }


    }
}
