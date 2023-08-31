using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private GeneralFieldsUnitBalance generalFieldsUnitBalance;
    [SerializeField] private UnitBalance unitBalance;
    [NonSerialized] public int UnitHP;
    [NonSerialized] private int _unitArmor;
    [SerializeField] private Transform healthBar;

    private void Start()
    {
       UnitHP = generalFieldsUnitBalance.UnitHP;
       if (unitBalance)
       {
           _unitArmor = unitBalance.UnitArmor;
       }
    }

    public void GetDamage(int damage)
    {
        if (damage > _unitArmor)
        {
            float oldHP = UnitHP;
            damage -= _unitArmor;
            UnitHP -= damage;
            float newHP = UnitHP;
            float leftHP = newHP / oldHP;

            var localScale = healthBar.localScale;
            localScale = new Vector3(
                localScale.x * leftHP,
                localScale.y,
                localScale.z);
            healthBar.localScale = localScale;
        }
        
        if (UnitHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
