using UnityEngine;
using UnityEngine.UI;

public class LoadValues : settings
{
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private Slider slider;
    void Start()
    {
        dropdown.value = control_type;
        slider.value = notch_height;
    }
}
