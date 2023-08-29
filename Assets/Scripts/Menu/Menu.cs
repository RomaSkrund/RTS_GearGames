using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void FirstLevelStart() //можно получать из unity 
    {
        SceneManager.LoadScene(1);
    }

    public void SecondLevelStart()
    {
        SceneManager.LoadScene(2);
    }
    
    public void ThirdLevelStart()
    {
        SceneManager.LoadScene(3);
    }

    public void DoExit()
    {
        Application.Quit();
    }
}
