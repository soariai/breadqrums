using System.Collections.Generic;
using UnityEngine;

public class JobSystem : MonoBehaviour
{
    public List<JobDefinition> availableJobs = new();

    public void AcceptJob(JobDefinition job)
    {
        NotificationBus.Raise($"Accepted: {job.title}");
        GameManager.I.AddQrums(job.baseRewardQRUMS);
        CompleteJob(job);
    }

    public void CompleteJob(JobDefinition job)
    {
        NotificationBus.Raise($"Completed: {job.title}");
    }
}
