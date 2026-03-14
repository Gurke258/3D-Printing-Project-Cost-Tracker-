# 3D Printing Project & Cost Tracker

Ein moderner Desktop-Client zur Verwaltung von 3D-Druck-Projekten und zur präzisen Berechnung von Material- und Stromkosten. Dieses Projekt dient als Referenz für moderne Softwarearchitektur mit **C#, .NET und WPF**.

## 🚀 Status des Projekts
Dieses Projekt befindet sich in der aktiven Entwicklung. Aktuell ist die **Master-Detail-Ansicht** implementiert, die eine Übersicht der Druckprojekte sowie eine detaillierte Ansicht des ausgewählten Projekts ermöglicht.

## 🛠 Technische Highlights

*   **Architektur:** Saubere Trennung der Belange (Separation of Concerns) durch Aufteilung in mehrere Projekte:
    *   `.Core`: Enthält das Domänenmodell und die Geschäftslogik.
    *   `.Common`: Ein eigenes kleines MVVM-Framework mit Basisklassen für `INotifyPropertyChanged`.
    *   `.Wpf`: Die Benutzeroberfläche, konsequent nach dem **MVVM-Muster** umgesetzt.
*   **UI/UX:** Dynamisches Layout mittels WPF `Grid` und `DataTrigger` zur Steuerung der Sichtbarkeit von Elementen.
*   **Data Binding:** Tiefgehende Nutzung von `ObservableCollection`, `SelectedItems` und komplexen Bindings mit `StringFormat`.

## 📸 Vorschau
![App Preview](https://via.placeholder.com/800x450.png?text=Screenshot+kommt+bald)

## 🏗 Geplante Features
- [x] **Data Persistence:** Speichern der Projektdaten in JSON-Dateien oder einer lokalen SQLite-Datenbank.
- [x] **Cost Calculation:** Automatisierte Berechnung der Gesamtkosten pro Druck (Strom + Filament).
- [x] **Commanding:** Implementierung von `RelayCommand` zum Hinzufügen und Löschen von Projekten.
- [x] **Charts:** Visualisierung des Filamentverbrauchs über die Zeit.

## ⚙️ Installation
1. Klone das Repository:  
   `git clone https://github.com/DEIN_USERNAME/3DPrint-Cost-Tracker.git`
2. Öffne die Solution in **Visual Studio 2022**.
3. Stelle sicher, dass das Projekt `PrintLog.Wpf` als Startprojekt festgelegt ist.
4. Drücke `F5`, um die Anwendung zu starten.

## 📄 Lizenz
Dieses Projekt ist unter der **GNU GPL v3** lizenziert. Siehe die [LICENSE](LICENSE) Datei für Details.
