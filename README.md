# Tierhandlung WPF Anwendung mit Entity Framework

**Autor:** Moritz Kolb

## Kurzbeschreibung

Diese Anwendung ist eine WPF-Desktop-App zur Verwaltung eines Tierheims.  
Benutzer können Tiere einsehen, Anfragen stellen und den Status ihrer Anfragen verfolgen.  
Administratoren können Tiere hinzufügen, bearbeiten oder löschen und den Status aller Anfragen verwalten.

---

## Nutzung

### Anmeldung und Benutzerbereich

1. Starten Sie die Anwendung.
2. Melden Sie sich mit einem bestehenden Benutzerkonto an oder erstellen Sie ein neues.
3. Nach der Anmeldung können Benutzer:
   - Tiere aus der Liste auswählen.
   - Details und Bild des ausgewählten Tieres rechts einsehen.
   - Eine Anfrage zu einem Tier stellen, indem ein Kommentar eingetragen wird.
   - Unterhalb der Tierliste ihre eigenen Anfragen und deren Status einsehen.

### Administratorbereich

1. Administratoren haben zusätzliche Funktionen:
   - Tiere hinzufügen, bearbeiten oder löschen.
   - Status von Benutzeranfragen ändern über ein Dropdown-Menü unterhalb des Anfragen-DataGrids.
2. Änderungen werden direkt in der Datenbank gespeichert.

---

## Screenshots

**Tiere auswählen und Details anzeigen:**  
<img width="946" height="636" alt="user_screenshot" src="https://github.com/user-attachments/assets/9893d960-54aa-49a8-9386-c7e2d7e9f0c6" />


**Admin: Anfragen verwalten und Status ändern:**  
<img width="1382" height="590" alt="screenshot_admin" src="https://github.com/user-attachments/assets/b9aa7774-2192-425f-9b8e-a87e758d6c96" />


---

## Hinweise

- Die Anwendung verwendet **Entity Framework Core** mit **SQLite**.
- Tierbilder werden als **Byte-Array** in der Datenbank gespeichert.

