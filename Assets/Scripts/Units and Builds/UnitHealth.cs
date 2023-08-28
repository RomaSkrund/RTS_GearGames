using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    [SerializeField] private GeneralFieldsUnitBalance generalFieldsUnitBalance;
    private int unitHP;
    public static bool IsDamageGet;

    private void Start()
    {
       unitHP = generalFieldsUnitBalance.UnitHP;
    }

    private void Update()
    {
        if (IsDamageGet)
        {
            getDamage();
        }
        if (unitHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void getDamage()
    {
        float oldHP = unitHP;
        unitHP -= BulletController.causedDamage;
        float newHP = unitHP;
        float leftHP = newHP / oldHP;
        
        Transform healthBar = transform.GetChild(0).transform;
        healthBar.localScale = new Vector3(
            healthBar.localScale.x * leftHP,
            healthBar.localScale.y,
            healthBar.localScale.z);
        
        IsDamageGet = false;
    }
}
