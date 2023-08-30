using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject enemyFactory;

    [SerializeField] private float minimalDeviation;
    [SerializeField] private float maximalDeviation;
    

    private void Start()
    {
        var i = Random.Range(1, 5);
        
        Vector3 pos = new Vector3(
            spawnPoints[i].position.x + Random.Range(minimalDeviation, maximalDeviation),
            spawnPoints[i].position.y,
            spawnPoints[i].position.z + Random.Range(minimalDeviation, maximalDeviation));
        
        GameObject spawn = Instantiate(enemyFactory);
        spawn.transform.position = spawnPoints[i].position;
    }
}
