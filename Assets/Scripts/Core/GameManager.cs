using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }
    public PlayerProfile Profile { get; private set; }

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this; DontDestroyOnLoad(gameObject);
    }

    public void Init(PlayerProfile profile)
    {
        Profile = profile;
    }

    public void AddQrums(int amount)
    {
        Profile.qrums = Mathf.Max(0, Profile.qrums + amount);
        NotificationBus.Raise($"+$ {amount} QRUMS");
    }
}
