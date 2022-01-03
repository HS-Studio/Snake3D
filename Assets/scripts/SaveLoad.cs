using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{    
    public static void Save(Snake saveData, string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        
        SaveData data = new SaveData(saveData);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static void Save(settings saveData, string path)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(saveData);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData Load(string path)
    {
        if(File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = bf.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }

        else
        {
            Debug.LogError("Save file not found in "+ path);
            return null;
        }
    }
}