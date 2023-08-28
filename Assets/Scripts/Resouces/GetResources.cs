using System.Collections;
using UnityEngine;

public class GetResources : MonoBehaviour
{
    [SerializeField] private GameBalance gameBalance;

    private void Start()
    {
        StartCoroutine(AddResources());
    }
    
    private IEnumerator AddResources()
    {
        while (true)
        {
            if (!ResourcesPanelUpdate.IsMaxResouces)
            {
                ResourcesPanelUpdate.Resources += gameBalance.FactoryMiningCount;
            }
            yield return new WaitForSeconds(gameBalance.FactoryMiningSpeed);
        }
    }
}
