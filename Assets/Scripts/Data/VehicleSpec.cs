using UnityEngine;

[CreateAssetMenu(menuName = "Qrum/Vehicle", fileName = "Vehicle_")]
public class VehicleSpec : ScriptableObject
{
    public string id;
    public string displayName;
    public float speedMultiplier = 1.0f;
    public int capacity = 3;
    public bool staminaCost = true;
    public Sprite icon;
    public int priceQRUMS;
}
