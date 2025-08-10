using UnityEngine;

[CreateAssetMenu(menuName = "Qrum/Item", fileName = "Item_")]
public class InventoryItem : ScriptableObject
{
    public string id;
    public string displayName;
    [TextArea] public string description;
    public Sprite icon;
    public int costQRUMS;
}
