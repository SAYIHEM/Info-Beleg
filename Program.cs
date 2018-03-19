using System;
using System.Collections.Generic;

using BasicAPI.Eingabe;
using BasicAPI.Ausgabe;
using BasicAPI.Objekte;

namespace Belegaufgabe2016
{
    /// <summary>
    /// Bei diesem Progamm ist ein Beispiel, um die BasicAPI zu benutzen.
    /// Bitte adaptieren Sie dieses Beisiel für Ihren eigenen Entwurf.
    /// 
    /// Grundsätzlich können Sie den kompletten Beispielcode löschen und Ihren eigenen Quelltext schreiben.
    /// 
    /// Allerdings muss folgende Bedingung erfüllt sein:
    /// - der letzte Anweisungsblock muss übernommen werden 
    /// - wobei die Instanziierung der Maschinesteuerung angepasst werden muss
    /// 
    /// Wird dieses Beispiel-Projekt richtig ausgeführt, sehen Sie ein Konsolenfenster in dem die Nachricht
    /// "Starte Simulationsfenster ..." steht.
    /// Anschließend wird das Fenster für die Simulation geöffnet.
    /// Klicken Sie im Fenster auf den Button 'Play', wird die Prozessschrittliste in dem Fenster angezeigt.
    /// 
    /// Durch Schließen des Fensters beenden Sie das Programm.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Beispiel zum Einlesen einer Konfigurationsdatei (in diesem Fall der Fertigungsauftrag)

            //Legt eine neue Liste von Prozessschritten an
            List<Prozessschritt> prozessschrittliste = new List<Prozessschritt>();

            //liest die Datei Fertigungsauftrag.txt ein und speichert diese in Listen
            //die äußere Liste enthält alle Zeilen dieser Datei
            //die innere Liste enthält alle Prozessschritte dieser Zeile, dabei steht in jedem Eintrag in dieser Liste genau ein Prozessschritt
            List<List<string>> textdateiInListen = KonfigurationenLader.LeseKonfiguration(@"Resources/Fertigungsauftrag.txt");
            foreach (List<string> listenZeile in textdateiInListen)
            {
                foreach (string prozessschritt in listenZeile)
                {
                    prozessschrittliste.Add(
                        // Beispiel der Konvertierung von 'string' zu einem Enumerationstyp.
                        (Prozessschritt)Enum.Parse(typeof(Prozessschritt), prozessschritt)
                      );
                }
            }



            // Erzeuge einfache Maschinensteuerung --> muss in Ihre Maschinensteuerung angepasst werden
            AbstrakteMaschinenSteuerung maschinensteuerung = new EinfacheMaschinenSteuerung(prozessschrittliste);

            // Beispiel zum Starten der Testumgebung --> Bitte so verwenden wie es ist und nur die korrekte, zu simulierende Maschinensteuerung anpassen
            Console.WriteLine("Starte Simulationsfenster ...\n");
            //Legt die Maschinensimulation an
            GrafischeMaschinenSimulation simulation = new GrafischeMaschinenSimulation();

            // Dieser Aufruf muss mindestens einmal in ihrem Programm ausgeführt werden.
            simulation.FuegeSimulationsobjektHinzu(maschinensteuerung); // <--  die korrekte, zu simulierende Maschinensteuerung anpassen

            // Dieser Aufruf muss mindestens einmal in ihrem Programm ausgeführt werden.
            simulation.StarteSimulation(TimeSpan.FromSeconds(0));
        }
    }

}
