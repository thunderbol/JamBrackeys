using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1.0f;
    }
    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1.0f;
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
