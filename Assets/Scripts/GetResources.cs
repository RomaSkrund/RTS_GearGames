using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GetResources : MonoBehaviour
{
    [FormerlySerializedAs("addSpeed")] [SerializeField] private float addResourcesSpeed;
    [FormerlySerializedAs("addValue")] [SerializeField] public int addResourcesValue;

    private void Start()
    {
        StartCoroutine(AddResources());
    }
    
    private IEnumerator AddResources()
    {
        while (!ResourcesPanelUpdate.isMaxResouces)
        {
            ResourcesPanelUpdate.resources += addResourcesValue;
            yield return new WaitForSeconds(addResourcesSpeed);
        }
    }
}
