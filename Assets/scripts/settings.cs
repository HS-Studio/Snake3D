using System.IO;
using UnityEngine;

public class settings : MonoBehaviour
{
    public static int _targetFrameRate, control_type;
    public static float notch_height, cam_angle;
    private static string settings_path;

    private void Start()
    {
        settings_path = Application.persistentDataPath + "/settings.sav";

        //DontDestroyOnLoad(this);

        if (_targetFrameRate == 0)
        {
            Application.targetFrameRate = 30;
        }
        else
        {
            Application.targetFrameRate = _targetFrameRate;
        }
        
        loadSettings();
    }

    public static void loadSettings()
    {
        if (File.Exists(settings_path))
        {
            SaveData data = SaveLoad.Load(settings_path);
            control_type = data.control_type;
            notch_height = data.notch_height;
            cam_angle = data.cam_angle;
        }
        Debug.Log("Settings loaded");
        Debug.Log(control_type);
        //_targetFrameRate = data._targetFrameRate;
    }

    public void saveSettings()
    {
        SaveLoad.Save(this, settings_path);
        Debug.Log("Settings saved");
        Debug.Log(control_type);
    }

    public void ChangeControl(int val)
    {
        control_type = val;
        saveSettings();
        loadSettings();
    }
}