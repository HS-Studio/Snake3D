using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;

    private SnakeMove _quit;
    private InputAction Quit;

    [SerializeField]
    GameObject PauseManu;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        PauseManu.SetActive(false);
    }

    private void OnEnable()
    {
        _quit = new SnakeMove();
        Quit = _quit.control.Pause;
        Quit.performed += Quitction;

        Quit.Enable();
    }

    private void OnDisable()
    {
        Quit.Disable();
    }

    public void Quitction(InputAction.CallbackContext context)
    {
        PauseResume();
    }

    public void PauseResume()
    {
        if(isPaused)
        {
            isPaused = false;
            PauseManu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            isPaused = true;
            PauseManu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
