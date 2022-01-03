using UnityEngine;
using UnityEngine.UI;

public class LoadDropDownValue : settings
{
    [SerializeField]
    private Dropdown dropdown;
    void Start()
    {
        dropdown.value = control_type;
    }
}
