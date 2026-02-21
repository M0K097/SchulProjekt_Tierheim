## GitHub Action – Automatische Unit-Tests

Die GitHub Action wurde eingerichtet, um bei jedem Push oder Pull Request automatisch alle Unit-Tests auszuführen.  

### Kurze Zusammenfassung der Einrichtung:

1. **Workflow-Verzeichnis erstellen**  
   `.github/workflows` im Repository-Root anlegen.  

2. **Workflow-Datei erstellen**  
   `.github/workflows/dotnet-tests.yml` mit den Schritten: Checkout, .NET Setup, Restore, Build, Test.  

3. **Pfad zur Lösung anpassen**  
   Wenn die Lösung in einem Unterordner liegt, z. B. `Implementierung/Tierhandlung_Projekt.1_Moritz_Kolb`, muss der Pfad im Workflow korrekt sein.  

4. **Testprojekte referenzieren**  
   Das Testprojekt muss in der Lösung enthalten sein und die Implementierungsprojekte referenzieren.  

5. **Push / Pull Request auslösen**  
   Nach Push in den `master`-Branch oder bei PR wird die Action automatisch gestartet.  

6. **Status-Badge einfügen**  
   Badge zeigt den Status der letzten Testausführung in der README an:

   ```markdown
   ![.NET Unit Tests](https://github.com/<USERNAME>/<REPO>/actions/workflows/dotnet-tests.yml/badge.svg)
