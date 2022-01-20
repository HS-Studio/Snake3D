using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public static int _targetFrameRate, control_type;
    public static float notch_height;
    private static string settings_path;

    void Awake()
    {
        settings_path = Application.persistentDataPath + "/settings.sav";

        //DontDestroyOnLoad(gameObject);

        if (_targetFrameRate == 0)
        {
            Application.targetFrameRate = 30;
        }
        else
        {
            Application.targetFrameRate = _targetFrameRate;
        }
        //Debug.Log("Hello World");
        loadSettings();
    }

    public static void loadSettings()
    {
        if (File.Exists(settings_path))
        {
            SaveData data = SaveLoad.Load(settings_path);
            control_type = data.control_type;
            notch_height = data.notch_height;
        }
        //_targetFrameRate = data._targetFrameRate;
    }

    public void saveSettings()
    {
        SaveLoad.Save(this, settings_path);
    }

    public void ChangeControl(int val)
    {
        control_type = val;
    }
}