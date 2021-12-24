//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class Menu : MonoBehaviour
{
    //public int HiScore;
    public Text HiScoreText;
    string s_HiScore;
    
    public void clicked()
    {
        SceneManager.LoadScene("Snake", LoadSceneMode.Single);
    }

    // Start is called before the first frame update
    
    void Start()
    {
        string path = Application.persistentDataPath + "/Score.txt";
        if(File.Exists(path))
        {
            s_HiScore = File.ReadAllText(path);
            HiScoreText.text = s_HiScore;
        }
    }
    
    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
