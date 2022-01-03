using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int HiScore, _targetFrameRate, control_type;

    public SaveData (Snake saveData)
    {
        HiScore = saveData.HiScore;
    }
    public SaveData (settings settings)
    {
        _targetFrameRate = settings._targetFrameRate;
        control_type = settings.control_type;
    }
}
