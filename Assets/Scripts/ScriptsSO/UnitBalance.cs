using UnityEngine;

[CreateAssetMenu(fileName = "unitBalance", menuName = "UnitBalance")]
public class UnitBalance : ScriptableObject
{
    [SerializeField] private int unitDamage;
    [SerializeField] private int unitArmor;
    [SerializeField] private float unitSpeed;
    [SerializeField] private float unitRadiusAttack;
    
    public int UnitDamage => unitDamage;
    public int UnitArmor => unitArmor;
    public float UnitSpeed => unitSpeed;
    public float UnitRadiusAttack => unitRadiusAttack;
}
