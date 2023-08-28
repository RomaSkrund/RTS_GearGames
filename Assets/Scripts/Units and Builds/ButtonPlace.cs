using UnityEngine;

public class ButtonPlace : MonoBehaviour
{
    public GameObject building;
    public void PlaceUnit()
    {
        if (UnitAttack.unitCoststatic <= ResourcesPanelUpdate.Resources)
        {
            Instantiate(building);
            ResourcesPanelUpdate.Resources -= UnitAttack.unitCoststatic;
        }
    }
}
