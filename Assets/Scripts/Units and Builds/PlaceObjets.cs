using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjets : MonoBehaviour
{

    public LayerMask layer; 

    private void Start()
    {
        PositionObject();
    }

    private void PositionObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layer))
        
        {
            transform.position = hit.point; 
        }
    }

    private void Update()
    {
        PositionObject();

        if (Input.GetMouseButtonDown(0))
        {
            //if (gameObject.GetComponent<AutoCarCreate>())
            //gameObject.GetComponent<AutoCarCreate>().enabled = true;
            
            Destroy(gameObject.GetComponent<PlaceObjets>());
        }
    }
}
