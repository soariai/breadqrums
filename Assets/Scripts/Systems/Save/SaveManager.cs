using System.IO;
using UnityEngine;

public static class SaveManager
{
    static string Path => System.IO.Path.Combine(Application.persistentDataPath, "save.json");

    public static PlayerProfile Load()
    {
        try
        {
            if (!File.Exists(Path)) return new PlayerProfile();
            var json = File.ReadAllText(Path);
            return JsonUtility.FromJson<PlayerProfile>(json);
        }
        catch { return new PlayerProfile(); }
    }

    public static void Save(PlayerProfile profile)
    {
        var json = JsonUtility.ToJson(profile, prettyPrint: true);
        File.WriteAllText(Path, json);
    }
}
