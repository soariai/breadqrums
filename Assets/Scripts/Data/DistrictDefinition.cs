using UnityEngine;

[CreateAssetMenu(menuName = "Qrum/District", fileName = "District_")]
public class DistrictDefinition : ScriptableObject
{
    public string id;
    public string displayName;
    public Sprite mapThumbnail;
    [TextArea] public string blurb;
}
