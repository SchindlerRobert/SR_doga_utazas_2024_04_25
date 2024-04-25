using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SR_doga_utazas_2024_04_25
{
    class UtazasRepository
    {
        public static string Path { get; set; }
        public static char Separator { get; set; } = ',';
        public static bool SkipHeader { get; set; } = true;

        public static List<Utazas> FindAll()
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                List<Utazas> utazasok = new List<Utazas>();

                if (SkipHeader)
                {
                    reader.ReadLine();
                }

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Utazas utazas = Utazas.CreateFromLine(line, Separator);
                    utazasok.Add(utazas);
                }

                return utazasok;
            }
        }

        public static Utazas FindById(int id)
        {
            List<Utazas> utazasok = FindAll();
            foreach (Utazas utazas in utazasok)
            {
                if (utazas.Id == id)
                {
                    return utazas;
                }
            }
            return null;
        }

        public static void Save(Utazas NewUtazas)
        {
            int maxId = 0;
            List<Utazas> utazasok = FindAll();

            for (int i = 0; i < utazasok.Count; i++)
            {
                if (utazasok[i].Id == NewUtazas.Id)
                {
                    utazasok[i] = NewUtazas;
                }
                if (utazasok[i].Id > maxId)
                {
                    maxId = utazasok[i].Id;
                    maxId++;
                }
            }
            if (NewUtazas.Id == 0)
            {
                NewUtazas.Id = maxId;
                utazasok.Add(NewUtazas);
            }

            using (StreamWriter writer = new StreamWriter(Path))
            {
                writer.WriteLine("id,orszag,honap,nap,hossz,ar,ellatas");
                foreach (var item in utazasok)
                {
                    writer.WriteLine(item.ToCSVLine());
                }
            };
        }
    }
}
