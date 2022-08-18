using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int HiScore, _targetFrameRate, control_type;
    public float notch_height, cam_angle;

    public SaveData (Snake saveData)
    {
        HiScore = saveData.HiScore;
    }
    public SaveData (settings settings)
    {
        _targetFrameRate = settings._targetFrameRate;
        control_type = settings.control_type;
        notch_height = settings.notch_height;
        cam_angle = settings.cam_angle;
    }
}
