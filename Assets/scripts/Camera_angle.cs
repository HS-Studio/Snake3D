using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_angle : settings
{
    private void Start()
    {
        loadSettings();
        ChangeCameraAngle(cam_angle);
    }

    public void ChangeCameraAngle(float val)
    {
        loadSettings();
        cam_angle = val;
        transform.localRotation = Quaternion.Euler(cam_angle*-1, 0, 0);
        saveSettings();
    }
}