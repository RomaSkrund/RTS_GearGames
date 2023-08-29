using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private GeneralFieldsUnitBalance generalFieldsUnitBalance;
    [SerializeField] private UnitBalance unitBalance;
    [NonSerialized] public int unitHP;
    [NonSerialized] private int unitArmor;
    [SerializeField] private Transform healthBar;

    private void Start()
    {
       unitHP = generalFieldsUnitBalance.UnitHP;
       if (unitBalance)
       {
           unitArmor = unitBalance.UnitArmor;
       }
    }

    public void GetDamage(int damage)
    {
        if (damage > unitArmor)
        {
            float oldHP = unitHP;
            damage -= unitArmor;
            unitHP -= damage;
            float newHP = unitHP;
            float leftHP = newHP / oldHP;
        
            healthBar.localScale = new Vector3(
                healthBar.localScale.x * leftHP,
                healthBar.localScale.y,
                healthBar.localScale.z); 
        }
        
        if (unitHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
