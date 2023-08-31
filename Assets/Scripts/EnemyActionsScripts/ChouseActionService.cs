using DefaultNamespace;
using UnityEngine;

public class ChouseActionService
{
    private int _previosValue;
    private int _currentValue;

    public ChouseActionService()
    {
        
    }
    
    public ActionEnum ChooseAction(int spawnFactory, int spawnUnit, int attackBase, int ignore)
    {
        var sum = spawnFactory + spawnUnit + attackBase + ignore;
        
        var randomNumber = Random.Range(1, sum + 1);

        if (randomNumber <= spawnFactory)
        {
            return ActionEnum.SpawnFactory;
        }
        
        if (randomNumber <= spawnFactory + spawnUnit)
        {
            return ActionEnum.SpawnUnit;
        }
        
        if (randomNumber <= spawnFactory + spawnUnit + attackBase)
        {
            return ActionEnum.AttackBase;
        }
        return ActionEnum.Ignore;
    }
}