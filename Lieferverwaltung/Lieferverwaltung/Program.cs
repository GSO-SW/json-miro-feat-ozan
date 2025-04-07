namespace Lieferverwaltung
{
    class Program
    {
        static List<Lieferung> lieferungen = new List<Lieferung>();
        static void Main(string[] args)
        {
            BeispielobjekteAnlegen();

            StreamWriter sw = new StreamWriter("C:\\Users\\Miro\\Documents\\json-miro-feat-ozan\\Lieferverwaltung\\lieferungen.json");
            sw.Write("{\n");
            sw.Write($"\t\"anzahl\": {lieferungen.Count}");
            sw.Write(",\n");
            sw.Write("\t\"lieferungen\":\n");
            sw.Write("\t[\n");

            for(int i = 0; i < lieferungen.Count; i++)
            {
                Lieferung curLieferung = lieferungen[i];
                
                sw.Write("\t\t{\n");
                sw.Write($"\t\t\t\t\"datum\": \"{curLieferung.Datum}\",\n");
                sw.Write($"\t\t\t\t\"sendungsnummer\": \"{curLieferung.Sendungsnummer}\",\n");
                sw.Write($"\t\t\t\t\"plz\": {Convert.ToInt32(curLieferung.PLZ)}\n");
                sw.Write("\t\t}");

                if(i != lieferungen.Count - 1)
                sw.Write(",\n");
                else
                {
                    sw.Write("\n");
                }
            }

            sw.Write("\t]\n");
            sw.Write("}");
            sw.Close();
        }

        static void BeispielobjekteAnlegen()
        {
            lieferungen.Add(new Lieferung(
                new DateOnly(2024, 06,22)
                , "HHX05NNW0ZP"
                , "86309"
            ));
            
            lieferungen.Add(new Lieferung(
                new DateOnly(2024, 09, 4)
                , "GSV18EDC4BR"
                , "91139"
            ));
            
            lieferungen.Add(new Lieferung(
                new DateOnly(2023, 04, 8)
                , "CQX55KMY5RW"
                , "07708"
            ));
        }
    }
}
