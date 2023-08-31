using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    [SerializeField] private LevelSettings levelSettings;
    [SerializeField] private Text timer;
    private float _roundTime;
    [SerializeField] private Image endMenu;
    [SerializeField] private Text gameResult;
    [SerializeField] private GameObject ownBase;
    private int _levelNumber;

    private void Start()
    {
        _levelNumber = SceneManager.GetActiveScene().buildIndex;
        _roundTime = levelSettings.LevelEndTime; 
        GameTimeGo();
    }

    private void Update()
    {
        if (_roundTime > 0.1)
        {
            _roundTime -= Time.deltaTime;
            UpdateLevelTimer(_roundTime); 
        }
        else
        {
            EndingGame("Вы победили");
            switch (_levelNumber)
            {
                case (1):
                    PlayerPrefs.SetInt("FirstLevel", 1);
                    break;
                case(2):
                    PlayerPrefs.SetInt("SecondLevel", 1);
                    break;
                case(3):
                    PlayerPrefs.SetInt("ThirdLevel", 1);
                    break;
            }
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
