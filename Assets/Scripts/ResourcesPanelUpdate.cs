using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesPanelUpdate : MonoBehaviour
{
    [SerializeField] public int startResources;
    public static int resources;
    [SerializeField] public Text ResoucesPanel;
    [SerializeField] private int maxResouces;
    public static bool isMaxResouces;

    private void Start()
    {
        resources = startResources;
    }

    private void Update()
    {
        if (resources == maxResouces)
        {
            isMaxResouces = true;
        }
        else
        {
            isMaxResouces = false;
        }
        ResoucesPanel.text = resources.ToString();
    }
}
