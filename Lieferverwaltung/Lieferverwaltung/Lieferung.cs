namespace Lieferverwaltung
{
    public class Lieferung
    {
        private DateOnly datum;
        private string sendungsnummer;
        private string plz;
	
        public Lieferung(DateOnly datum, string sendungsnummer, string plz)
        {
            this.datum = datum;
            this.sendungsnummer = sendungsnummer;
            this.plz = plz;
        }
        
        public DateOnly Datum { get { return datum; } }
        public string Sendungsnummer { get { return sendungsnummer; } }
        public string PLZ { get { return plz; } }
    }
}
