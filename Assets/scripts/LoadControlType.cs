using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadControlType : settings
{
    [SerializeField] public GameObject Dpad, Joy;

    private void Start()
    {
        LoadControls();
    }
    private void OnEnable()
    {
        LoadControls();
    }
    public void LoadControls()
    {
        loadSettings();

        //Debug.Log(control_type);
        
        if(Dpad || Joy != null)
        {
            if (control_type == 0)
            {
                Dpad.SetActive(true);
                Joy.SetActive(false);
            }
            if (control_type == 1)
            {
                Dpad.SetActive(false);
                Joy.SetActive(true);
            }
        }
    }
}
