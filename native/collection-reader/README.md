# collection-reader

Small Windows helper used by the app to read the cards you own in MTG Arena.
MTG Arena keeps the collection on Wizards' servers and only in memory while the game is open; it is not written to `Player.log`.

## What it does

- Finds the running `MTGA.exe` process and reads, **read-only** (`ReadProcessMemory`), the owned-cards dictionary
  `WrapperController.<Instance> → <InventoryManager> → InventoryServiceWrapper → <Cards>`.
- Prints one JSON line on stdout: `{"cards":[[grpId, copies], ...], "unique": n, "copies": n, "elapsedMs": n}`
  or `{"error": "...", "kind": "not_running|access_denied|not_found"}`.
- Never writes to the game process, never opens network connections, never updates itself, does not need administrator rights.

Exit codes: `0` ok, `2` Arena not running, `3` access denied, `4` data not found (not logged in, or the game was updated), `1` other error.

## Build

Requires the .NET 8 SDK.

```
dotnet publish collection-reader.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:DebugType=none -o publish
```

This publishes the self-contained single-file executable shipped inside the portable exe to `publish/collection-reader.exe`.

## License

This helper includes a copy of **HackF5.UnitySpy** (`vendor/HackF5.UnitySpy`), taken from
[frcaton/mtga-tracker-daemon](https://github.com/frcaton/mtga-tracker-daemon) at commit `d5bc784`, which adds support for recent Unity versions.
That repository is licensed under the **GNU General Public License v3.0**, so this helper (its source in this folder and the built executable)
is distributed under the GPL-3.0 as well — see [LICENSE](LICENSE). The original UnitySpy by HackF5 is MIT-licensed.

The rest of the application is a separate program that runs this helper as an independent process.
