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
    public GameState state;
    InputMap inputs;

    //it activate when the game is running
    [SerializeField] GameObject inGameHUD;

    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject inputScreen;
    [SerializeField] GameObject winScreen;

    //the counter used to activate the win screen
    public int EnemyCounter;

    public static GameManager instance;
    /*it's recalled in:
     * AbilitySwitcher to prevent the use of normal Player Inputs (the switching of the abilities) while in pause;
     * AbilityUser to prevent the use of normal Player Inputs (the Ability Casting) while in pause;
     * EnemyBehavior to decreass the Enemy Counter.
     */
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
        inputs.Pause.Restart.started -= Restart;
        inputs.Player.Disable();
        inputs.Pause.Disable();
    }
    private void Update()
    {
        if (EnemyCounter == 0)
        {
            Time.timeScale = 0;

            pauseScreen.SetActive(false);
            inGameHUD.SetActive(false);
            winScreen.SetActive(true);
            inputs.Pause.Enable();
            inputs.Pause.Restart.started += Restart;
        }
    }
    private void Pause()
    {
        state = GameState.Paused;
        Time.timeScale = 0;

        inGameHUD.SetActive(false);
        pauseScreen.SetActive(true);

        inputs.Pause.Enable();
        inputs.Player.Disable();

        inputs.Player.Pause.started += ChangeState;
    }
    private void Running()
    {
        state = GameState.Running;
        Time.timeScale = 1;

        inGameHUD.SetActive(true);
        inputScreen.SetActive(false);
        pauseScreen.SetActive(false);

        inputs.Player.Enable();
        inputs.Pause.Disable();

        inputs.Player.Pause.started += ChangeState;
    }
    //here I change the state if I press Esc or P
    private void ChangeState(InputAction.CallbackContext context)
    {
        if (state == GameState.Paused)
            Running();
        if (state == GameState.Running)
            Pause();
    }
    //a function used to Activate/Deactivate the Input Screen
    public void Inputs()
    {
        if (inputScreen.activeInHierarchy)
        {
            inputScreen.SetActive(false);
            pauseScreen.SetActive(true);
        }
        else
        {
            inputScreen.SetActive(true);
            pauseScreen.SetActive(false);
        }
    }

    //the reset & quit function
    public void Restart(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
