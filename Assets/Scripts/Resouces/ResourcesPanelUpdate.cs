using UnityEngine;
using UnityEngine.UI;

public class ResourcesPanelUpdate : MonoBehaviour
{
    [SerializeField] private GameBalance gameBalance;
    public static int Resources;
    [SerializeField] private Text resoucesPanel;
    public static bool IsMaxResouces;

    private void Start()
    {
        Resources = gameBalance.StartResouces;
    }

    private void Update()
    {
        IsMaxResouces = Resources == gameBalance.MaxResouces;
        resoucesPanel.text = Resources.ToString();
    }
}
