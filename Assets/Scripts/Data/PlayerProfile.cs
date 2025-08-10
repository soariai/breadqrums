using System;
using UnityEngine;

[Serializable]
public class PlayerProfile
{
    public int version = 1;
    public int level = 1;
    public int experience = 0;
    public int qrums = 0;

    public Vector2 position = Vector2.zero;
    public string districtId = "sourdough_street";

    public string equippedOutfitId = null;
    public string equippedVehicleId = null;
    public string[] ownedOutfits = Array.Empty<string>();
    public string[] ownedVehicles = Array.Empty<string>();

    public string[] completedJobs = Array.Empty<string>();
    public string[] unlockedDistricts = new []{"sourdough_street"};
}
