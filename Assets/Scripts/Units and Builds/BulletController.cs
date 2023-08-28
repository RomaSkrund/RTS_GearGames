using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private string tagForDestroy;

    public static int causedDamage;

    private void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards
            (transform.position, position, step);

        if (transform.position == position)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) //передавать id аттакуемой машины 
    {
        if (other.CompareTag(tagForDestroy))
        {
            causedDamage = damage;
            UnitHealth.IsDamageGet = true;
        }
    }
}
