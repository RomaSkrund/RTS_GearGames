using UnityEngine;

public class ButtonPlace : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private GeneralFieldsUnitBalance generalFieldsUnitBalance;
    public void PlaceUnit()
    {
        if (generalFieldsUnitBalance.UnitCost > ResourcesPanelUpdate.Resources) return;
        Instantiate(building);
        ResourcesPanelUpdate.Resources -= generalFieldsUnitBalance.UnitCost;
    }
}
