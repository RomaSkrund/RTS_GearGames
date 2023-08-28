using System;
using System.Collections;
using UnityEngine;

public class AutoCarCreate : MonoBehaviour
{
    [NonSerialized]
    public bool IsEnemy = false; 
    public GameObject car;
    public float time = 5f;
    public int countOfNewCars = 3;

    private void Start()
    {
        StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        for (int i = 1; i <= countOfNewCars; i++)
        {
            yield return new WaitForSeconds(time);

            Vector3 pos = new Vector3(
                transform.GetChild(0).position.x + UnityEngine.Random.Range(3f, 7f),
                transform.GetChild(0).position.y,
                transform.GetChild(0).position.z + UnityEngine.Random.Range(3f, 7f)); 

            GameObject spawn = Instantiate(car, pos, Quaternion.identity);

            if (IsEnemy)
            {
                spawn.tag = "Enemy";
            }
        }
    }
}
