using UnityEngine;
using UnityEngine.UI;

public class JobBoardUI : MonoBehaviour
{
    public JobSystem jobSystem;
    public Transform listRoot;
    public Button jobButtonPrefab;

    void Start() { Refresh(); }

    public void Refresh()
    {
        foreach (Transform child in listRoot) Destroy(child.gameObject);
        foreach (var job in jobSystem.availableJobs)
        {
            var btn = Instantiate(jobButtonPrefab, listRoot);
            btn.GetComponentInChildren<TMPro.TMP_Text>().text = $"{job.title}  •  ${job.baseRewardQRUMS}";
            btn.onClick.AddListener(() => jobSystem.AcceptJob(job));
        }
    }
}
