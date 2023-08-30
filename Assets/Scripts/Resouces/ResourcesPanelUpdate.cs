using UnityEngine;
using UnityEngine.UI;

public class ResourcesPanelUpdate : MonoBehaviour
{
    [SerializeField] private GameBalance gameBalance;
    public static int Resources;
    [SerializeField] private Text resoucesPanel;

    private void Start()
    {
        Resources = gameBalance.StartResouces;
    }

    private void Update()
    {
        resoucesPanel.text = Resources.ToString();
    }
}
