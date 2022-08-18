using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadValues : settings
{
    //[SerializeField] private Dropdown dropdown;
    [SerializeField] private Toggle toggle_0, toggle_1;
    [SerializeField] private Slider notch_slider, cam_slider;
    
    void OnEnable()
    {
        loadSettings();

        if (control_type == 0)
        {
            toggle_0.isOn = true;
            //toggle_1.isOn = false;
        }
        if (control_type == 1)
        {
            //toggle_0.isOn = false;
            toggle_1.isOn = true;
        }
        notch_slider.value = notch_height;
        cam_slider.value = cam_angle;
        Debug.Log("Pause");
    }
}
