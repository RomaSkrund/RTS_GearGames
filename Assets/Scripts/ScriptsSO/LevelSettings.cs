using UnityEngine;

[CreateAssetMenu(fileName = "levelSettings", menuName = "LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private int levelEndTime;
    
    [SerializeField] private int firstStepValue;
    [SerializeField] private int spawnFactoryFSV;
    [SerializeField] private int spawnUnitFSV;
    [SerializeField] private int attackBaseFSV;
    [SerializeField] private int ignoreFSV;
    
    [SerializeField] private int secondStepValue;
    [SerializeField] private int spawnFactorySSV;
    [SerializeField] private int spawnUnitSSV;
    [SerializeField] private int attackBaseSSV;
    [SerializeField] private int ignoreSSV;
    
    [SerializeField] private int thirdStepValue;
    [SerializeField] private int spawnFactoryTSV;
    [SerializeField] private int spawnUnitTSV;
    [SerializeField] private int attackBaseTSV;
    [SerializeField] private int ignoreTSV;

    public int LevelEndTime => levelEndTime;
    
    public int FirstStepValue => firstStepValue;
    public int SpawnFactoryFSV => spawnFactoryFSV;
    public int SpawnUnitFSV => spawnUnitFSV;
    public int AttackBaseFSV => attackBaseFSV;
    public int IgnoreFSV => ignoreFSV;
    
    public int SecondStepValue => secondStepValue;
    public int SpawnFactorySSV => spawnFactorySSV;
    public int SpawnUnitSSV => spawnUnitSSV;
    public int AttackBaseSSV => attackBaseSSV;
    public int IgnoreSSV => ignoreSSV;
    
    public int ThirdStepValue => thirdStepValue;
    public int SpawnFactoryTSV => spawnFactoryTSV;
    public int SpawnUnitTSV => spawnUnitTSV;
    public int AttackBaseTSV => attackBaseTSV;
    public int IgnoreTSV => ignoreTSV;
}
