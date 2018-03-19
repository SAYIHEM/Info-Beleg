using System.Collections.Generic;

using BasicAPI.Objekte;

namespace Belegaufgabe2016
{
    /// <summary>
    /// Eine einfache Maschinensteuerung zur Veranschaulichung
    /// der Verwendung von vorgefertigten Strukturen in der BasicAPI.
    /// 
    /// Diese Klasse sollte gelöscht und eine eigene Implementierung in einer
    /// gesonderten *.cs-Datei vorgenommen werden.
    /// </summary>
    class EinfacheMaschinenSteuerung : AbstrakteMaschinenSteuerung
    {
        private List<Prozessschritt> _prozessschrittliste;

        /// <summary>
        /// Initialisierung
        /// </summary>
        /// <param name="prozessschrittliste">Prozesschrittliste für die Produktiuon von Teilen</param>
        public EinfacheMaschinenSteuerung(List<Prozessschritt> prozessschrittliste)
            : base("Einfache Maschinensteuerung")
        {
            _prozessschrittliste = prozessschrittliste;
        }

        /// <summary>
        /// Gibt die Prozessschritte aus.
        /// </summary>
        /// <returns>die Prozesschritte als String</returns>
        public override string ErmittleZustandsAusgabe()
        {
            // Beispiel zu Konvertierung einer Liste nach string.
            return "Prozessschritte: " + string.Join(" -> ", _prozessschrittliste);
        }

        /// <summary>
        /// Die in der Simulation durchzuführende Aufgabe.
        /// </summary>
        public override void FuehreAuftragDurch()
        {
            // Deaktiviert das SimulationsObjekt
            // Die Maschinensteuerung wird nun in der Simulation nicht mehr berücksichtigt.
            SetEnabled(false);
        }
    }
}
