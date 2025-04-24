using System.Globalization;

namespace Lieferverwaltung
{
    class Program
    {
        static List<Lieferung> lieferungen = new List<Lieferung>();
        static List<Lieferung> lieferungenAusJSON = new List<Lieferung>();

        static void Main(string[] args)
        {
            BeispielobjekteAnlegen();
	    ErstelleJSON();
	    ErstelleObjekteAusJSON();
	    JSONObjekteAusgeben();
        }

	static void JSONObjekteAusgeben()
	{
		for(int i = 0; i < lieferungenAusJSON.Count; i++)
		{
			Console.WriteLine($"Lieferung Nr.{i} :");
			Console.WriteLine($"Datum: {lieferungenAusJSON[i].Datum}");
			Console.WriteLine($"Sendungsnummer: {lieferungenAusJSON[i].Sendungsnummer}");
			Console.WriteLine($"PLZ: {lieferungenAusJSON[i].PLZ}");
			Console.WriteLine();
		}
	}

	static void ErstelleObjekteAusJSON()
	{
		bool dateiEnde = false;
		StreamReader sr = new StreamReader(Environment.CurrentDirectory + "\\lieferungen.json");

		while(!(dateiEnde))
		{
			string? aktuelleZeile = "";
			bool inObjects = false;
			bool inObject = false;

			aktuelleZeile = sr.ReadLine();
			
			if(aktuelleZeile == null)
			{
				dateiEnde = true;
				sr.Dispose();
				return;
			}

			if(aktuelleZeile.Contains("["))
			{
				inObjects = true;

				while(inObjects)
				{
					aktuelleZeile = sr.ReadLine();

					if(aktuelleZeile.Contains("]"))
					{
						inObjects = false;
						break;
					}

					if(aktuelleZeile.Contains("{"))
					{
						inObject = true;
						DateOnly datum;
						string sendungsnummer = "";
						string plz = "";

						while(inObject)
						{
							aktuelleZeile = sr.ReadLine();

							if(aktuelleZeile.Contains("}"))
							{
								Lieferung lieferung = new Lieferung(datum, sendungsnummer, plz);
								lieferungenAusJSON.Add(lieferung);
								inObject = false;
								break;
							}

							if(aktuelleZeile.Contains("datum"))
							{
								datum = DateOnly.ParseExact(aktuelleZeile.Split(':')[1].Trim(' ', '\"', ','), "yyyy-MM-d");
							}
							else if(aktuelleZeile.Contains("sendungsnummer"))
							{
								sendungsnummer = Convert.ToString(aktuelleZeile.Split(':')[1].Trim(' ', '\"', ','));
							}
							else if(aktuelleZeile.Contains("plz"))
							{
								plz = Convert.ToString(aktuelleZeile.Split(':')[1].Trim());
							}
						}
					}
				}
			}

		}
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

	    sw.Dispose();
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
