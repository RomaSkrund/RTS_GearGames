using System.Collections;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject factory;

    private void Start()
    {
        StartCoroutine(SpawnFactory());
    }

    IEnumerator SpawnFactory()
    {
        for(int i = 0; i < points.Length; i++)
        {
            yield return new WaitForSeconds(10f);
            GameObject spawn =  Instantiate(factory);
            Destroy(spawn.GetComponent<PlaceObjets>());
            spawn.transform.position = points[i].position;
            spawn.transform.rotation = Quaternion.Euler
                (new Vector3(0, UnityEngine.Random.Range(0, 360), 0));
            spawn.GetComponent<AutoCarCreate>().enabled = true;
        }
    }

}
