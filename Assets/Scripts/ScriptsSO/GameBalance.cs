using UnityEngine;

[CreateAssetMenu(fileName = "gameBalance", menuName = "GameBalance")]
public class GameBalance : ScriptableObject
{
    [SerializeField] private int factoryMiningCount;
    [SerializeField] private int factoryMiningSpeed;
    [SerializeField] private int maxResouces;
    [SerializeField] private int startResouces;
    
    public int FactoryMiningCount => factoryMiningCount;
    public int FactoryMiningSpeed => factoryMiningSpeed;
    public int MaxResouces => maxResouces;
    public int StartResouces => startResouces;
}