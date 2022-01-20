//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class Menu : MonoBehaviour
{
    //public int HiScore;
    [SerializeField] private Text HiScoreText, ScoreText;
     private string s_HiScore;
    
    public void clicked()
    {
        SceneManager.LoadScene("Snake", LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    
    void Start()
    {
        string OldPath = Application.persistentDataPath + "/Score.txt";
        string ScorePath = Application.persistentDataPath + "/Score.sav";

        ScoreText.text = Snake.Score.ToString();

        if (File.Exists(OldPath))
        {
            s_HiScore = File.ReadAllText(OldPath);
            HiScoreText.text = s_HiScore;
            File.Delete(OldPath);
        }
        else if (File.Exists(ScorePath))
        {
            SaveData data = SaveLoad.Load(ScorePath);
            s_HiScore = data.HiScore.ToString();
            HiScoreText.text = s_HiScore;
        }
    }
}
