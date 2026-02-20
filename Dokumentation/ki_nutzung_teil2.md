# KI-Dokumentation – Nutzung von KI im Projekt

## Verwendete KI-Tools

Im Rahmen dieses Projekts wurde folgendes KI-Tool verwendet:

- ChatGPT (Free-Version)

---

## Bei welchen Aufgaben wurde KI eingesetzt?

### 1. Verbesserung der Benutzeroberfläche (XAML)
- Mein ursprüngliches XAML-Layout wurde von mir erstellt.
- Ich habe ChatGPT genutzt, um:
  - das Layout optisch zu verbessern
  - Styles einheitlich zu gestalten
  - Schatteneffekte und moderne UI-Elemente hinzuzufügen
  - die Struktur sauberer zu organisieren

### 2. Arbeiten mit Bildern in WPF
- Unterstützung beim Laden von Bildern aus der Datenbank (Byte-Array → BitmapImage)
- Erklärung von:
  - `MemoryStream`
  - `BitmapImage`
  - `CacheOption`
  - `Freeze()`

### 3. Erstellung von Unit-Tests (MSTest)
- Inspiration für geeignete Testfälle
- Strukturierung von Testmethoden

### 4. Code-Refactoring
- Überprüfung meiner Service-Klasse `Tierheim`
- Verbesserungsvorschläge für:
  - Struktur
  - Lesbarkeit
  - saubere Trennung von Logik und UI
  - Vermeidung von redundanten Codeabschnitten

---

## Verwendete Prompts (Beispiele)

### Prompt 1 – UI Verbesserung

„Hier ist mein XAML-Code. Kannst du meine WPF-Oberfläche moderner und optisch ansprechender gestalten, ohne die Funktionalität zu verändern?“

---

### Prompt 2 – Arbeiten mit Bildern

„Wie kann ich ein Bild aus einem Byte-Array in WPF in einem Image-Control anzeigen?“

---

### Prompt 3 – Unit Tests

„Erstelle mir mindestens fünf Unit-Tests mit MSTest für meine Tierheim-Service-Klasse unter Verwendung einer InMemory-Datenbank.“

---

## Beispiel mit mehreren Prompts (Verbesserung)

### Erster Prompt:
„Meine Unit-Tests funktionieren nicht.“

→ Ergebnis: allgemeine Erklärung ohne konkrete Lösung.

### Verbesserter Prompt:
„Mein Testprojekt ist nicht kompatibel mit net9.0-windows7.0. Wie ändere ich das Target Framework, damit ich mein WPF-Projekt referenzieren kann?“

→ Ergebnis: konkrete Lösung mit Anpassung der .csproj-Datei.

Dieses Beispiel zeigt, dass präzisere Prompts zu deutlich besseren und konkreteren Lösungen führen.

---

## Welche KI-generierten Inhalte wurden übernommen, modifiziert oder verworfen?

### Übernommen:
- Struktur der Unit-Tests
- Verbesserungsvorschläge für XAML-Styles
- Beispielcode für Bilddarstellung in WPF
- Hinweise zur Verwendung von EF Core InMemory

### Modifiziert:
- Die generierten Unit-Tests wurden an meine konkrete Projektstruktur angepasst.
- UI-Vorschläge wurden teilweise übernommen und individuell verändert.
- Texte für Dokumentation wurden sprachlich angepasst.

### Verworfen:
- Einige vorgeschlagene Architekturänderungen wurden nicht übernommen, da sie den Projektumfang überschritten hätten.
- Alternative Testframework-Vorschläge (z.B. xUnit) wurden nicht verwendet.

---

## Reflexion: Was habe ich durch den KI-Einsatz gelernt?

Durch den Einsatz von KI habe ich:

- Ein besseres Verständnis für die Struktur von Unit-Tests erhalten.
- Gelernt, wie man eine InMemory-Datenbank für Tests verwendet.
- Mehr Sicherheit im Umgang mit WPF und Bildverarbeitung bekommen.
- Gelernt, wie wichtig präzise und klare Prompts sind.
- Meine Fähigkeit verbessert, KI-Vorschläge kritisch zu bewerten und anzupassen.


Die KI hat mir geholfen, effizienter zu arbeiten, jedoch habe ich alle Inhalte selbst überprüft, verstanden und angepasst.


