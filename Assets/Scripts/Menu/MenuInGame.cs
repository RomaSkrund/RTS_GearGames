using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    
    public void BackToGame()
    {
        GameTimeGo();
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        GameTimeGo();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameTimeGo();
    }

    public void OpenGameMenu()
    {
        GameTimeStop();
    }

    private static void GameTimeStop()
    {
        Time.timeScale = 0;
    }

    private static void GameTimeGo()
    {
        Time.timeScale = 1;
    }
}
