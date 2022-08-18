using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused;

    private SnakeMove _quit;
    private InputAction Quit;

    [SerializeField] GameObject _pauseMenu;
    [SerializeField] Image playPause;
    [SerializeField] Sprite spr_play, spr_pause;
    
    void Start()
    {
        isPaused = false;
        _pauseMenu.SetActive(false);
    }

    private void OnEnable()
    {
        _quit = new SnakeMove();
        Quit = _quit.control.Pause;
        Quit.performed += Quitaction;

        Quit.Enable();
    }

    private void OnDisable()
    {
        Quit.Disable();
    }

    public void Quitaction(InputAction.CallbackContext context)
    {
        PauseResume();
    }

    public void PauseResume()
    {
        if(isPaused)
        {
            if (playPause != null)
            {
                playPause.sprite = spr_pause;
            }
            isPaused = false;
            _pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            if (playPause != null)
            {
                playPause.sprite = spr_play;
            }
            isPaused = true;
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
