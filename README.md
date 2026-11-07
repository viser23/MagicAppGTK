# MagicAppGTK (beta)

Un compagno per MTG Arena su Windows. Registra partite e mazzi leggendo il log del gioco e mostra collezione, statistiche e valutazioni delle carte per il Limited.
Non serve nessun account e i tuoi dati restano sul tuo PC.

> **È una beta.** Qualcosa può non funzionare: trovare questi problemi è proprio lo scopo del test.

## Installazione

1. Scarica `MagicAppGTK-Setup-….exe` dall'[ultima release](https://github.com/viser23/MagicAppGTK/releases/latest).
2. Fai doppio clic. L'installazione dura pochi secondi, non chiede i permessi di amministratore e alla fine apre l'app. La trovi poi nel menu Start come **MagicAppGTK**.

**Avviso "PC protetto da Windows":** compare perché l'installer non è firmato digitalmente. Clicca **Ulteriori informazioni** e poi **Esegui comunque**. Serve solo la prima volta: gli aggiornamenti non lo mostrano.

**Antivirus:** alcuni potrebbero segnalare l'app, perché contiene uno strumento che legge la memoria di Arena (vedi [Cosa fa sul tuo PC](#cosa-fa-sul-tuo-pc)).

Serve Windows 10 o 11 a 64 bit.

### Se usavi la versione portable

Al primo avvio l'app chiede **Import data from the portable version?**. Clicca **Choose folder…** e scegli la cartella dove tenevi l'exe portable (quella con dentro `MagicAppGTK-data`). Partite, mazzi, collezione, tag, impostazioni e immagini delle carte passano all'app installata; i file della portable non vengono toccati.

Chiudi la versione portable prima di installare. Quando hai controllato che nell'app installata c'è tutto, puoi cancellare l'exe portable e la cartella `MagicAppGTK-data`.

Se non hai mai usato la portable, clicca **Start fresh**.

## Aggiornamenti

L'app si aggiorna da sola. Controlla se c'è una nuova versione all'avvio e poi ogni 4 ore, la scarica in background e, quando è pronta, mostra un riquadro in basso a destra:

- **Restart now:** l'app si chiude, si aggiorna e si riapre in pochi secondi.
- **Later:** l'aggiornamento si installa quando chiudi l'app.

Durante una partita il riquadro non compare: aspetta la fine della partita. In **Settings → Updates** vedi la versione installata e puoi controllare subito con **Check for updates**. Le novità di ogni versione sono nel riquadro (**What's new**) e nella pagina delle [release](https://github.com/viser23/MagicAppGTK/releases).

## Configurare Arena (una volta sola)

1. In MTG Arena apri **Settings → Account** e attiva **Detailed Logs (Plugin Support)**.
2. Riavvia Arena.

Se in **Collection** compare l'avviso "card catalog was not found", Arena è installato in una cartella non standard: clicca **Choose folder** e selezionala.

## Cosa provare

| Funzione | Come | Cosa controllare |
|---|---|---|
| Partite e mazzi | Apri Arena, poi tieni l'app aperta mentre giochi | Risultato, formato e mazzo corretti; le carte viste dall'avversario |
| Partita in corso | Inizia una partita con l'app aperta | La pagina **Live Match** si apre da sola: il tuo mazzo con le carte rimaste nel grimorio e le carte dell'avversario; in alto, per ogni tuo turno, il mana disponibile, quello speso per colore e quello rimasto inutilizzato, e sotto le carte pescate e giocate |
| Analisi dei turni | A partita finita, **Matches → Turns** | Il grafico del mana con carte pescate e giocate, tuo e dell'avversario, per ogni game; se eri di mano o di pescata |
| Collezione | Con Arena aperto e il login fatto, **Collection → Sync from Arena** | Carte possedute e wildcard corrispondono al gioco |
| Immagini carte | **Collection → Download images** | Il download finisce e le immagini si vedono |
| Valutazioni Limited | **Settings → Limited Ratings → Download from 17Lands** (Premier + Quick Draft) | I dati si scaricano e compaiono sulle carte |
| Draft in corso | Scarica i dati 17Lands del set, poi inizia un draft (Premier o Quick) con l'app aperta | La pagina **Live Draft** si apre da sola: le carte del pacchetto in ordine di consiglio, ognuna con le sue motivazioni; a lato il tuo pool, i colori aperti e, dalla pick 9, le carte prese dagli altri |
| Storico dei draft | **Live Draft → History → Review** | Ogni pick con il pacchetto com'era e il consiglio di quel momento |
| Mazzo dell'avversario | Gioca una partita Constructed (per esempio Standard) | Nella pagina **Live Match**, dopo un paio di carte dell'avversario, il riquadro **Probable deck** indica il mazzo più probabile e **Still to expect** le carte che possono ancora arrivare |
| Costruire un mazzo | **Decks → + New deck**, oppure **Import list** con una lista copiata da Arena | Aggiunta e rimozione delle carte, salvataggio, **📋 Copy for Arena** da incollare in Arena |
| Avvio con Windows | **Settings → Preferences → Start with Windows (in the system tray)** | Al riavvio del PC l'app parte nella barra delle icone, senza aprire la finestra |
| Aggiornamento | Quando compare il riquadro, **Restart now** | L'app si riapre alla nuova versione con tutti i dati |
| Salvataggio dati | Chiudi e riapri l'app | Partite e impostazioni sono ancora lì |

Arena azzera il suo log a ogni avvio, quindi l'app registra solo le partite giocate mentre è aperta.

## Dove finiscono i dati

- **Programma:** `%LOCALAPPDATA%\Programs\mtg-arena-auto-tracker`
- **Dati** (database, immagini, impostazioni e log): `%APPDATA%\mtg-arena-auto-tracker`. Per aprire la cartella, incolla il percorso nella barra degli indirizzi di Esplora file.

**Per disinstallare:** **Impostazioni di Windows → App → App installate → MagicAppGTK → Disinstalla**. I dati restano, così una reinstallazione ritrova tutto. Per cancellare anche quelli, elimina poi la cartella dei dati.

Le immagini occupano spazio: tutti i set insieme arrivano a circa 2 GB.

## Segnalare un problema

Apri una [issue](https://github.com/viser23/MagicAppGTK/issues) (serve un account GitHub gratuito) e scrivi:

- cosa stavi facendo e quale versione usi (**Settings → Updates**);
- cosa ti aspettavi e cosa è successo;
- se puoi, allega `%APPDATA%\mtg-arena-auto-tracker\logs\app.log`. Se il problema era nella sessione precedente, allega anche `app.previous.log`.

I log contengono i percorsi dei file, quindi anche il tuo nome utente di Windows. Controllali prima di pubblicarli: una issue è visibile a tutti.

## Cosa fa sul tuo PC

- **Legge** il log di Arena (`Player.log`) e il file delle carte nella cartella di Arena, senza modificarli.
- **Scarica** dati e immagini delle carte da Scryfall, le statistiche da 17Lands e, una volta alla settimana, le liste dei mazzi Standard pubblicate da Wizards of the Coast su magic.gg (per indovinare il mazzo dell'avversario). Non invia i tuoi dati a nessuno e non c'è telemetria.
- **Controlla gli aggiornamenti** leggendo le release di questo repository su GitHub, e scarica da lì le nuove versioni.
- **Legge la memoria di Arena solo per la collezione**, quando clicchi **Sync from Arena** o se attivi tu la sincronizzazione automatica. Lo fa `collection-reader`, un piccolo programma separato: legge soltanto, non modifica il gioco, non usa la rete e non chiede i privilegi di amministratore.

Questo strumento non è approvato da Wizards of the Coast. Se preferisci non usare la lettura della memoria, non cliccare **Sync from Arena**: puoi importare la collezione da un file con **Import CSV**.

## Sorgenti e licenze

- **MagicAppGTK:** licenza [MIT](LICENSE). Nasce come fork di [MTG Arena Tracker](https://github.com/Shalkith/MTG-Arena-Tracker) di Shalkith. Questo repository non contiene il suo codice sorgente.
- **collection-reader:** licenza [GPL-3.0](native/collection-reader/LICENSE), sorgente completo in [`native/collection-reader`](native/collection-reader). Include [HackF5.UnitySpy](https://github.com/frcaton/mtga-tracker-daemon).
- **Dati:** [Scryfall](https://scryfall.com/), [17Lands](https://www.17lands.com/) e le liste dei mazzi di [magic.gg](https://magic.gg/).

## Progetto non ufficiale

MagicAppGTK è un progetto di fan, non affiliato a Wizards of the Coast né approvato da essa.
Magic: The Gathering e MTG Arena sono marchi di Wizards of the Coast LLC.
