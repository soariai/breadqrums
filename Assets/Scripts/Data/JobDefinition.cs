using UnityEngine;

public enum JobType { Delivery, MiniGame, Social }

[CreateAssetMenu(menuName = "Qrum/Job", fileName = "Job_")]
public class JobDefinition : ScriptableObject
{
    public string id;
    public string title;
    [TextArea] public string description;
    public JobType type = JobType.Delivery;
    [Range(1,5)] public int difficulty = 1;
    public int baseRewardQRUMS = 50;
    public float estimatedMinutes = 5f;
    public string districtId = "sourdough_street";
    public bool requiresVehicle;
    public string requiredVehicleId;
    public string miniGameId;
}
