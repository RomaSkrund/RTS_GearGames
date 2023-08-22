using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [NonSerialized] public Vector3 position;
    [SerializeField] private float speed = 30f;
    [SerializeField] private int damage = 20;
    [SerializeField] private string tagForDestroy;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagForDestroy))
        {
            UnitAttack attackedUnit = other.GetComponent<UnitAttack>();
            float oldHP = attackedUnit._health;
            attackedUnit._health -= damage;
            float newHP = attackedUnit._health;
            float leftHP = newHP / oldHP; //отделить от пули (пуля только сообщает что нанесла урон) 
            
            

            Transform healthBar = other.transform.GetChild(4).transform;
            healthBar.localScale = new Vector3(
                healthBar.localScale.x * leftHP,
                healthBar.localScale.y,
                healthBar.localScale.z);

            if (attackedUnit._health <= 0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
