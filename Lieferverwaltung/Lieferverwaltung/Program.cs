using System.Globalization;

namespace Lieferverwaltung
{
    class Program
    {
        static List<Lieferung> lieferungen = new List<Lieferung>();
        static void Main(string[] args)
        {
            BeispielobjekteAnlegen();
	    ErstelleJSON();
        }

	static void ErstelleJSON()
	{

	    StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\lieferungen.json");

	    sw.WriteLine('{');

	    sw.WriteLine($"\t\"anzahl\": {lieferungen.Count},");
	    sw.WriteLine("\t\"lieferungen\":");
	    sw.WriteLine("\t[");

	    for(int i = 0; i < lieferungen.Count; i++)
            {
		    sw.WriteLine("\t\t{");


		    sw.WriteLine($"\t\t\t\"datum\": \"{lieferungen[i].Datum.ToString("yyyy-MM-d", CultureInfo.InvariantCulture)}\",");
		    sw.WriteLine($"\t\t\t\"sendungsnummer\": \"{lieferungen[i].Sendungsnummer}\",");
		    sw.WriteLine($"\t\t\t\"plz\": {Convert.ToInt32(lieferungen[i].PLZ)}");
		    if(i == lieferungen.Count - 1)
                    {
		    	sw.WriteLine("\t\t}");
                    }
		    else
                    {
		    	sw.WriteLine("\t\t},");
                    }
	    }

	    sw.WriteLine("\t]");
	    sw.Write('}');

	    sw.Flush();
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
