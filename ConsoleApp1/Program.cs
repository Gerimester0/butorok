using System.Text.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string file = File.ReadAllText("butorok.json");
                Gyoker gy = JsonSerializer.Deserialize <Gyoker>(file);
                //Mely bútorok vannak fából
                foreach (var t in gy.targyak)
                {
                    if (t.anyag .ToLower().Contains("fa"))
                    {
                        Console.WriteLine(t);
                    }
                }
                //Melyik butornak van a elgnagyobb terfogata?
                Targyak max = gy.targyak[0];
                foreach (var t in gy.targyak)
                {
                    if (t.Terfogat() > max.Terfogat())
                    {
                        max = t;
                    }
                }
                Console.WriteLine("Legnagyobb:" + max);
                //A keszleten levok osszara mennyi?

                int osszeg = 0;
                foreach (var t in gy.targyak)
                {
                    if (t.keszleten)
                    {
                        osszeg += t.ar;
                    }
                }

            }
            catch (JsonException ex)
            {
                Console.WriteLine("JSON fájl feldolgozási hiba:" + ex.Message);
            }

            catch (FileNotFoundException ex) 
            {
                Console.WriteLine("Fájl elérési hiba." + ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Fájlkezelési hiba." + ex.Message);
            }

        }
    }
}
