using UnityEngine;
using UnityEngine.UI;

public class MenuScoreText : MonoBehaviour
{
    public Text _ScoreText;
    void Start()
    {
        _ScoreText.text = Snake.Score.ToString();
    }
}
