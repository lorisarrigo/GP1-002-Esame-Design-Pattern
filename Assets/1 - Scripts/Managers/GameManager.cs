using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public enum GameState
{
    Running,
    Paused,
}

public class GameManager : MonoBehaviour
{
    //ora cambia stato ma non disabilità gli input
    public GameState state;
    InputMap inputs;

    //it activate when the game is running
    [SerializeField] GameObject inGameHUD;

    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject winScreen;

    public int EnemyCounter;

    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;

        inputs = new InputMap();
        state = GameState.Running;
    }
    //here I define the behaviour of the states
    private void OnEnable()
    {
        if (state == GameState.Paused)
            Pause();
        else
            Running();
    }
    private void OnDisable()
    {
        inputs.Player.Pause.started -= ChangeState;
        inputs.Pause.Pause.started -= ChangeState;
    }

    private void Pause()
    {
        state = GameState.Paused;
        Time.timeScale = 0;

        inGameHUD.SetActive(false);
        pauseScreen.SetActive(true);

        inputs.Player.Disable();
        inputs.Pause.Enable();

        inputs.Pause.Pause.started += ChangeState;
        inputs.Pause.Restart.started += Restart;
    }
    private void Running()
    {
        state = GameState.Running;
        Time.timeScale = 1;

        inGameHUD.SetActive(true);
        pauseScreen.SetActive(false);

        inputs.Pause.Disable();
        inputs.Player.Enable();

        inputs.Player.Pause.started += ChangeState;
        inputs.Pause.Restart.started -= Restart;
    }
    private void Update()
    {
        if (EnemyCounter == 0)
        {
            Time.timeScale = 0;

            inGameHUD.SetActive(false);
            winScreen.SetActive(true);
            inputs.Player.Disable();
            inputs.Pause.Enable();
            inputs.Pause.Restart.started += Restart;
        }
    }
    //here I change the state if I press Space
    private void ChangeState(InputAction.CallbackContext context)
    {
        if (state == GameState.Paused)
            Running();
        else if (state == GameState.Running)
            Pause();
    }
    public void Restart(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
