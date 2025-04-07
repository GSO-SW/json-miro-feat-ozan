# 13.3-json
Das bestehende Projekt soll so erweitert werden, dass vorhandene Lieferungs-Objekte in einem json exportiert werden. In der `Program.cs`werden drei Objekte erzeugt, deren Export als json exakt so aussehen sollte:
```json
{
	"anzahl": 3,
	"lieferungen":
	[
		{
			"datum": "2024-06-22",
			"sendungsnummer": "HHX05NNW0ZP",
			"plz": 86309
		},
		{
			"datum": "2024-09-4",
			"sendungsnummer": "GSV18EDC4BR",
			"plz": 91139
		},
		{
			"datum": "2023-04-8",
			"sendungsnummer": "CQX55KMY5RW",
			"plz": 7708
		}
	]
}
```

## Arbeitsauftrag
- **Informieren Sie sich über den allgemeinen Aufbau von json-Dateien.**  

JSON (JavaScript Object Notation) ist ein **Datenformat**, welches zur **Übertragung von Daten zwischen Systemen erstellt wurde.**  
Es verwendet eine hierarschische **Schlüssel-Wert-Struktur**.  

Der Schlüssel muss **immer mit Anführungszeichen geschrieben werden (string)** und wird **mit einem Doppelpunkt** von dem Wert getrennt.  

Die Grundlagen der JSON-Syntax umfassen **Objekte und Arrays**.  

Objekte werden von **geschweiften Klammern umschlossen {}** und
definieren **eine Sammlung von Schlüssel-Wert-Paaren**.  

Arrays werden **immer in eckigen Klammern []** definiert, diese **halten eine geordnete Liste von Werten**.  

Sowohl **in Objekten als auch in Arrays werden Werte durch Kommata** getrennt.  
- **Fassen Sie Ihre Erkenntnisse in einem kurzen "Spickzettel" zusammen.**   
Siehe Edumaps (https://nrw.edumaps.de/125247/42655/84hbgds7j3/7l5am5insj)  
- **Erweitern Sie Ihr Programm so, dass eine JSON-Datei nach obigem Vorbild erstellt wird.**
- **Nutzen Sie, nach Möglichkeit, keine fertige Bibliothek.**
- **Ob die Datei korrekt formatiert ist, können Sie z.B. [hier](https://jsonlint.com/) überprüfen.**