using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool GameISPaused = false;
    [SerializeField] InputSystem_Actions InputSystem;
    public GameObject PauseMenuUi;
    public GameObject optionsMenuUi;


    private void Awake()
    {

    }
    private void OnEnable()
    {
      // inputs.Enable();
        //playerInput.actions.FindActionMap("Player").Enable();
        InputSystem = new InputSystem_Actions();
        InputSystem.Player.Enable();
        InputSystem.Player.Pause.performed += Pause;
        
    }
    private void OnDisable()
    {
       // playerInput.actions.FindActionMap("Player").Disable();
        InputSystem.Disable();
        InputSystem.Player.Pause.performed -= Pause;
    }
    void Update()
    {
        
    }
    public void Pause(InputAction.CallbackContext context)
    {
        
        if (GameISPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    public void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1;
        GameISPaused = false;
       // GameSystemManager._.SetActiveUiElement(GameSystemManager._.mainUi, true);
       GameSystemManager._.OpenInGameUI();
    }
    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0;
        GameISPaused = true;
        GameSystemManager._.SetActiveUiElement(PauseMenuUi, true);

    }
    public void OpenOptions()
    {     
        GameSystemManager._.OpenOptions(PauseMenuUi);
        PauseMenuUi.SetActive(false );

    }
    public void QuitGame()
    {
        SceneManager.LoadScene(GameSystemManager._._Lobby);
    }
}
