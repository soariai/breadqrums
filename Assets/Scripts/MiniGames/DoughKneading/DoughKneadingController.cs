using UnityEngine;

public class DoughKneadingController : MonoBehaviour
{
    [Range(0f,1f)] public float targetWindow = 0.1f;
    public float bpm = 90f;
    public int beatsToPlay = 32;
    float _songTime;
    int _hits;

    void Update()
    {
        _songTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) TryHit();
        if (_songTime >= beatsToPlay * 60f / bpm) Finish();
    }

    void TryHit()
    {
        float secPerBeat = 60f / bpm;
        float beatPos = Mathf.Repeat(_songTime, secPerBeat) / secPerBeat;
        float dist = Mathf.Min(beatPos, 1f - beatPos);
        if (dist <= targetWindow) _hits++;
    }

    void Finish()
    {
        int reward = Mathf.RoundToInt(Mathf.Lerp(25, 150, Mathf.Clamp01(_hits / (float)beatsToPlay)));
        GameManager.I.AddQrums(reward);
        NotificationBus.Raise($"Dough Kneading: +$ {reward} QRUMS");
        SceneLoader.ToDistrict("SourdoughStreet");
    }
}
