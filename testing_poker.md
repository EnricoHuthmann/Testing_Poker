# Texas Hold’Em


## Regeln:


### Kartenset:

- 4 Farben (Herz (Hearts), Karo (Diamonds), Pik (Spades) und Kreuz (Clubs))

- 52 Karten (2 bis 10, Bube, Dame, König, Ass in jeder Farbe)


### Wertigkeit / Spielregeln:

https://www.royal-events.de/images/pdf/Spielregeln/Texas-Holdem-Poker-Regeln-Spielanleitung.pdf


### Eingabeformat

- Besteht aus 2 Teilen, Farbe und Wertigkeit
- Farben: H, D, C, S
- Wertigkeit: 2, 3, 4, 5, 6, 7, 8, 9, X, J, Q, K, A

Beispiele: H2 (Herz-2), DX ( Karo-10), CJ (Kreuz-Bube), SA (Pik-Ass)

Beispieleingabe: [H2, DX, CJ, SA, H5]

## Aufgaben

### Eingabe (alle Aufgaben): 
- Ein Menge an Karten (Minimum 2, Maximum 7), solange nicht anders definiert 

### Ausgabe (alle Aufgaben)
- Erwartete Ausgabe: Gefundene Ergebnisse in absteigender Wertigkeit

### Aufgabe 0: Eingabe validieren

### Aufgabe 1: Paare erkennen

### Aufgabe 2: Drillinge erkennen

### Aufgabe 3: Vierlinge erkennen

### Aufgabe 4: Mehrlinge erkennen
- Anmerkung: Mehrlinge inkludieren Paare bis Vierlinge

### Aufgabe 5: Full House erkennen

### Aufgabe 6: Straight / Straße erkennen

### Aufgabe 7: Flush / Alle Karten einer Farbe erkennen

### Aufgabe 8: Straight Flush erkennen

### Aufgabe 9: Royal Flush erkennen

### Aufgabe 10: Beste 5-Karten-Kombination aus 7 Karten
- Eingabe: 7 verschiedene Karten
- Ausgabe: Die höchstwertige Kombination

### Aufgabe 11: Höchstwertige Kombination aus mehreren 5-Karten-Kombinationen ermitteln
- Eingabe: Mehrere Sets aus 5 verschiedenen Karten [[H2, H5, DQ, ...], [C8, ... ]]
- Ausgabe: Das höchstwertige Set oder bei Gleichstand die höchstwertigen Sets
