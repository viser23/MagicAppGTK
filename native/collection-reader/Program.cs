// collection-reader: reads the owned-cards dictionary from the running MTG Arena process.
// Read-only (ReadProcessMemory only), no network, no writes to the game.
// stdout: exactly one JSON line. Library logging goes to stderr.
//
// Exit codes: 0 ok | 2 Arena not running | 3 access denied | 4 structures not found | 1 other error
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using HackF5.UnitySpy;
using HackF5.UnitySpy.Detail;
using HackF5.UnitySpy.Offsets;
using HackF5.UnitySpy.ProcessFacade;

var stdout = new StreamWriter(Console.OpenStandardOutput(), new UTF8Encoding(false)) { AutoFlush = true };
Console.SetOut(Console.Error);

int Fail(int code, string kind, string message)
{
    stdout.WriteLine($"{{\"error\":{Json(message)},\"kind\":\"{kind}\"}}");
    return code;
}

static string Json(string s)
{
    var sb = new StringBuilder("\"");
    foreach (var ch in s ?? "")
    {
        switch (ch)
        {
            case '"': sb.Append("\\\""); break;
            case '\\': sb.Append("\\\\"); break;
            case '\n': sb.Append("\\n"); break;
            case '\r': sb.Append("\\r"); break;
            case '\t': sb.Append("\\t"); break;
            default:
                if (ch < 0x20) sb.Append($"\\u{(int)ch:x4}"); else sb.Append(ch);
                break;
        }
    }
    return sb.Append('"').ToString();
}

var mtga = Process.GetProcessesByName("MTGA").FirstOrDefault();
if (mtga == null) return Fail(2, "not_running", "MTG Arena is not running");

IAssemblyImage image;
try
{
    var facade = new ProcessFacadeWindows(mtga);
    var offsets = MonoLibraryOffsets.GetOffsets(facade.GetMainModuleFileName());
    image = AssemblyImageFactory.Create(new UnityProcessFacade(facade, offsets), "Core");
}
catch (Win32Exception ex) when (ex.NativeErrorCode == 5)
{
    return Fail(3, "access_denied", "Access to the MTG Arena process was denied (is Arena running as administrator?)");
}
catch (Exception ex)
{
    return Fail(4, "not_found", "Could not read the game data: " + ex.Message);
}

object[] entries;
try
{
    // WrapperController.<Instance>.<InventoryManager>.InventoryServiceWrapper.<Cards> : Dictionary<uint grpId, int count>
    var wrapper = (ManagedClassInstance)image["WrapperController"]["<Instance>k__BackingField"];
    var inventory = (ManagedClassInstance)wrapper["<InventoryManager>k__BackingField"]["InventoryServiceWrapper"];
    entries = inventory["<Cards>k__BackingField"]["_entries"];
    if (entries == null) throw new InvalidOperationException("card dictionary is empty");
}
catch (Exception ex)
{
    return Fail(4, "not_found", "Collection not found in memory. Open Arena's Home screen (not during a match or while logging in) and try again. If it keeps failing, Arena may have been updated. Detail: " + ex.GetType().Name);
}

var sw = Stopwatch.StartNew();
var cards = new StringBuilder();
int unique = 0, copies = 0;
foreach (var e in entries)
{
    if (e is not ManagedStructInstance s) continue;
    int owned = s.GetValue<int>("value");
    if (owned <= 0) continue;
    uint grpId = s.GetValue<uint>("key");
    if (unique > 0) cards.Append(',');
    cards.Append('[').Append(grpId).Append(',').Append(owned).Append(']');
    unique++;
    copies += owned;
}

if (unique == 0) return Fail(4, "not_found", "The collection in memory is empty (not logged in yet?)");

stdout.WriteLine($"{{\"cards\":[{cards}],\"unique\":{unique},\"copies\":{copies},\"elapsedMs\":{sw.ElapsedMilliseconds}}}");
return 0;
