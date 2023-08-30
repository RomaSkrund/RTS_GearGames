using System.Collections;
using UnityEngine;

public class GetResources : MonoBehaviour
{
    [SerializeField] private GameBalance gameBalance;

    private void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            StartCoroutine(AddResources());
        }
        else
        {
            StartCoroutine(AddEnemyResources());
        }
        
    }
    
    private IEnumerator AddResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(gameBalance.FactoryMiningSpeed);
            
            if (ResourcesPanelUpdate.Resources + gameBalance.FactoryMiningCount <= gameBalance.MaxResouces)
            {
                ResourcesPanelUpdate.Resources += gameBalance.FactoryMiningCount;
            }
        }
    }
    
    private IEnumerator AddEnemyResources()
    {
        while (true)
        {
            yield return new WaitForSeconds(gameBalance.FactoryMiningSpeed);
            
            if (EnemyLogic.EnemyResources + gameBalance.FactoryMiningCount <= gameBalance.MaxResouces)
            {
                EnemyLogic.EnemyResources += gameBalance.FactoryMiningCount;
                EnemyLogic.EnemyLevelValue += gameBalance.FactoryMiningCount;
            }
        }
    }
}
