using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
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
            CarAttack attack = other.GetComponent<CarAttack>();
            float oldHP = attack._health;
            attack._health -= damage;
            float newHP = attack._health;
            float leftHP = newHP / oldHP; //отделить от пули (пуля только сообщает что нанесла урон) 
            
            

            Transform healthBar = other.transform.GetChild(0).transform;
            healthBar.localScale = new Vector3(
                healthBar.localScale.x * leftHP,
                healthBar.localScale.y,
                healthBar.localScale.z);

            if (attack._health <= 0)
            {
                Destroy(other.gameObject);
                
            }
        }
    }
}
