using System;

public static class NotificationBus
{
    public static event Action<string> OnToast;
    public static void Raise(string msg) => OnToast?.Invoke(msg);
}
