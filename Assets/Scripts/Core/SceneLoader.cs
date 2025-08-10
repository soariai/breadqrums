using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void ToMainMenu() => SceneManager.LoadScene("MainMenu");
    public static void ToDistrict(string sceneName) => SceneManager.LoadScene(sceneName);
}
