using UnityEngine;
public class settings : MonoBehaviour
{
    [SerializeField]
    int _targetFrameRate = 30;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = _targetFrameRate;
        Debug.Log("Hello World");
    }
}