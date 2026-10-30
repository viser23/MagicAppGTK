# MagicAppGTK (beta)

Un compagno per MTG Arena su Windows. Registra partite e mazzi leggendo il log del gioco e mostra collezione, statistiche e valutazioni delle carte per il Limited.
Non serve nessun account e i tuoi dati restano sul tuo PC.

> **È una beta.** Qualcosa può non funzionare: trovare questi problemi è proprio lo scopo del test.

## Avvio

1. Scarica `MagicAppGTK-…-portable.exe` dall'[ultima release](https://github.com/viser23/MagicAppGTK/releases/latest).
2. Mettilo in una cartella tutta sua, per esempio `C:\Giochi\MagicAppGTK`. Evita `Program Files`, dove l'app non può scrivere.
3. Fai doppio clic. Non c'è nulla da installare.

L'avvio richiede qualche secondo, perché ogni volta l'exe scompatta il programma.

**Avviso "PC protetto da Windows":** compare perché l'exe non è firmato digitalmente. Clicca **Ulteriori informazioni** e poi **Esegui comunque**.

**Antivirus:** alcuni potrebbero segnalare l'exe, perché è auto-estraente e contiene uno strumento che legge la memoria di Arena (vedi [Cosa fa sul tuo PC](#cosa-fa-sul-tuo-pc)).

Serve Windows 10 o 11 a 64 bit.

## Configurare Arena (una volta sola)

1. In MTG Arena apri **Settings → Account** e attiva **Detailed Logs (Plugin Support)**.
2. Riavvia Arena.

Se in **Collection** compare l'avviso "card catalog was not found", Arena è installato in una cartella non standard: clicca **Choose folder** e selezionala.

## Cosa provare

| Funzione | Come | Cosa controllare |
|---|---|---|
| Partite e mazzi | Apri Arena, poi tieni l'app aperta mentre giochi | Risultato, formato e mazzo corretti; le carte viste dall'avversario |
| Collezione | Con Arena aperto e il login fatto, **Collection → Sync from Arena** | Carte possedute e wildcard corrispondono al gioco |
| Immagini carte | **Collection → Download images** | Il download finisce e le immagini si vedono |
| Valutazioni Limited | **Settings → Limited Ratings → Download from 17Lands** | I dati si scaricano e compaiono sulle carte |
| Salvataggio dati | Chiudi e riapri l'app | Partite e impostazioni sono ancora lì |

Arena azzera il suo log a ogni avvio, quindi l'app registra solo le partite giocate mentre è aperta.

## Dove finiscono i dati

Tutto sta in `MagicAppGTK-data\`, creata accanto all'exe: database, immagini, impostazioni e log.

- **Per rimuovere tutto:** chiudi l'app e cancella l'exe e quella cartella. Non restano installazioni né voci di registro.
- **Per spostare l'app:** sposta l'exe e la cartella insieme.
- **Per aggiornare:** metti il nuovo exe nella stessa cartella. I dati restano.

Le immagini occupano spazio: tutti i set insieme arrivano a circa 2 GB.
Mentre è aperta, l'app tiene il programma scompattato in una cartella temporanea di Windows, che viene rimossa alla chiusura.

## Segnalare un problema

Apri una [issue](https://github.com/viser23/MagicAppGTK/issues) (serve un account GitHub gratuito) e scrivi:

- cosa stavi facendo;
- cosa ti aspettavi e cosa è successo;
- se puoi, allega `MagicAppGTK-data\logs\app.log`. Se il problema era nella sessione precedente, allega anche `app.previous.log`.

I log contengono i percorsi dei file, quindi anche il tuo nome utente di Windows. Controllali prima di pubblicarli: una issue è visibile a tutti.

## Cosa fa sul tuo PC

- **Legge** il log di Arena (`Player.log`) e il file delle carte nella cartella di Arena, senza modificarli.
- **Scarica** dati e immagini delle carte da Scryfall e le statistiche da 17Lands. Non invia i tuoi dati a nessuno e non c'è telemetria.
- **Legge la memoria di Arena solo per la collezione**, quando clicchi **Sync from Arena** o se attivi tu la sincronizzazione automatica. Lo fa `collection-reader`, un piccolo programma separato: legge soltanto, non modifica il gioco, non usa la rete e non chiede i privilegi di amministratore.

Questo strumento non è approvato da Wizards of the Coast. Se preferisci non usare la lettura della memoria, non cliccare **Sync from Arena**: puoi importare la collezione da un file con **Import CSV**.

## Sorgenti e licenze

- **MagicAppGTK:** licenza [MIT](LICENSE). Nasce come fork di [MTG Arena Tracker](https://github.com/Shalkith/MTG-Arena-Tracker) di Shalkith. Questo repository non contiene il suo codice sorgente.
- **collection-reader:** licenza [GPL-3.0](native/collection-reader/LICENSE), sorgente completo in [`native/collection-reader`](native/collection-reader). Include [HackF5.UnitySpy](https://github.com/frcaton/mtga-tracker-daemon).
- **Dati:** [Scryfall](https://scryfall.com/) e [17Lands](https://www.17lands.com/).

## Progetto non ufficiale

MagicAppGTK è un progetto di fan, non affiliato a Wizards of the Coast né approvato da essa.
Magic: The Gathering e MTG Arena sono marchi di Wizards of the Coast LLC.
