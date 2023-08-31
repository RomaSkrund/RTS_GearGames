using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button secondLevelStartButton;
    [SerializeField] private Button thirdLevelStartButton;
    private void Start()
    {
        secondLevelStartButton.interactable = PlayerPrefs.GetInt("FirstLevel") == 1;
        thirdLevelStartButton.interactable = PlayerPrefs.GetInt("SecondLevel") == 1;
    }
    
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

    public void ClearSaves()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
    
    public void DoExit()
    {
        Application.Quit();
    }
}
