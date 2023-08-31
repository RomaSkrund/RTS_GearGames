using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public Vector3 TargetPosition;
    [SerializeField] private float speed;
    [SerializeField] private string tagForDestroy;
    public int causedDamage;
    private GameObject _attacedEnemy;

    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

        if (transform.position == TargetPosition)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tagForDestroy))
        {
            return;
        }
        _attacedEnemy = other.gameObject;
        var enemyHealth = _attacedEnemy.GetComponent<UnitHealth>();
        enemyHealth.GetDamage(causedDamage);
    }
}
