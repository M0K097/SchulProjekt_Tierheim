## 1)
Ich habe die Tabellen Tier und Nutzer gewählt, weil das die minimal erforderlichen Akteure in dem Programm sind.
Nutzer sind entweder Interessenten oder Administratoren, und in der Tabelle Tier sind alle Tiere enthalten.
Ein Nutzer bekommt eine ID als Primary Key, um später eindeutig identifiziert werden zu können, sowie außerdem einen Benutzernamen und ein Passwort, um sich anmelden zu können.
Ist ein Nutzer ein Administrator, so ist sein Bit-Attribut (0 oder 1) auf 1, also wahr, gesetzt – wie bei einem Bool.
Tiere bekommen ebenfalls eine ID als Primärschlüssel sowie ihre Art, den Namen, das Geburtsdatum und eine kurze Beschreibung, weil diese Daten für die Nutzer wichtig sind.

## 2)
Ich habe die Beziehung n zu m gewählt, weil ein Nutzer mehrere Anfragen stellen kann, genauso wie ein Tier von mehreren Nutzern gleichzeitig angefragt werden kann.
Eine weitere Tabelle verknüpft die Tier_ID mit der Nutzer_ID indem sie diese dort als Foreign Keys in einer Zeile verknüpft und der Zeile automatisch eine eindeutige ID mit Identity zugewiesen wird.

## 3)
Die IDs beider Tabellen haben den Datentyp int und werden mit IDENTITY automatisch generiert, damit sie eindeutig sind.
Namen, Passwörter und die Beschreibung sind VARCHARs, also Strings, um diese Daten zu speichern.
Das Geburtsdatum des Tieres ist ein DateTime-Datentyp, damit mit Sicherheit nur gültige Daten eingetragen werden können und diese auch verrechnet werden können, um zum Beispiel das Alter des Tieres zu bestimmen.
Das is_ADMIN-Attribut wurde oben bereits beschrieben.
