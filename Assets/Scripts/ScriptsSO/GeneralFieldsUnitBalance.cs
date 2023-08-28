using UnityEngine;

[CreateAssetMenu(fileName = "generalFieldsUnitBalance", menuName = "GeneralFieldsUnitBalance")]
public class GeneralFieldsUnitBalance : ScriptableObject
{
    [SerializeField] private int unitCost;
    [SerializeField] private int unitHP;
    
    public int UnitCost => unitCost;
    public int UnitHP => unitHP;
}
