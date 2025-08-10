using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public TMP_Text qrumsText;
    public TMP_Text levelText;

    void OnEnable() { NotificationBus.OnToast += OnToast; }
    void OnDisable() { NotificationBus.OnToast -= OnToast; }

    void Update()
    {
        if (GameManager.I == null) return;
        qrumsText.text = "$" + GameManager.I.Profile.qrums.ToString();
        levelText.text = "Lv." + GameManager.I.Profile.level.ToString();
    }

    void OnToast(string msg)
    {
        Debug.Log($"[Toast] {msg}");
    }
}
