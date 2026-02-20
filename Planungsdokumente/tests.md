# Testfälle – Tierheim Verwaltung

---

## Testfall T02

**ID:** T01  
**Beschreibung:** Anmeldung als Administrator  

**Vorbedingungen:**  
- Die Anwendung ist gestartet.  
- Ein Administrator-Account existiert in der Datenbank.  
- Die Login-Maske ist sichtbar.  

**Test-Schritte:**  
1. Administrator-Benutzername in das Feld „Benutzer“ eingeben.  
2. Korrektes Passwort eingeben.  
3. Button „Anmelden“ klicken.  

**Erwartetes Resultat:**  
- Login-Bereich verschwindet.  
- Admin-Panel wird sichtbar.  
- Liste aller Anfragen wird angezeigt.  
- Tier-Verwaltungsfunktionen sind verfügbar.  

---

## Testfall T02

**ID:** T02  
**Beschreibung:** Anfrage für ein Tier erstellen  

**Vorbedingungen:**  
- Benutzer ist eingeloggt (kein Administrator).  
- Mindestens ein Tier existiert in der Datenbank.  

**Test-Schritte:**  
1. Ein Tier aus der Tierliste auswählen.  
2. Einen Kommentar in das Feld „Dein Kommentar“ eingeben.  
3. Button „Anfragen“ klicken.  

**Erwartetes Resultat:**  
- Anfrage wird gespeichert.  
- Anfrage erscheint in der Liste „Deine Anfragen“.  
- Erfolgsmeldung wird angezeigt.
