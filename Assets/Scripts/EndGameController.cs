using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private LevelSettings levelSettings;
    [SerializeField] private Text timer;
    private float roundTime;
    [SerializeField] private Image endMenu;
    [SerializeField] private Text gameResult;
    [SerializeField] private GameObject ownBase;

    private void Start()
    {
        roundTime = levelSettings.LevelEndTime; 
        GameTimeGo();
    }

    private void Update()
    {
        if (roundTime > 0.1)
        {
            roundTime -= Time.deltaTime;
            UpdateLevelTimer(roundTime); 
        }
        else
        {
            EndingGame("Вы победили");
        }

        if (ownBase.IsDestroyed())
        {
            EndingGame("Вы проиграли");
        }
    }

    private void EndingGame(string gameResultString)
    {
        GameTimeStop();
        endMenu.GameObject().SetActive(true);
        gameResult.text = gameResultString;
    }

    private void GameTimeGo()
    {
        Time.timeScale = 1;
    }

    private void GameTimeStop()
    {
        Time.timeScale = 0;
    }
    
    private void UpdateLevelTimer(float totalSeconds)
    {
        var minutes = Mathf.FloorToInt(totalSeconds / 60f);
        var seconds = Mathf.RoundToInt(totalSeconds % 60f);

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
