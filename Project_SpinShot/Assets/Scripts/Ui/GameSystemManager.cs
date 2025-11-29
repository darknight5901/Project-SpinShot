using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameSystemManager : MonoBehaviour
{   
    public static GameSystemManager _ { get; private set; }
    [Header("Ui references")]
    public string _Lobby;
    public Canvas _canvas;
    public GameObject mainUi;
    public GameObject shopUi;
    public GameObject OptionsUI;
    public GameObject activeUIElement;
    [Header("GameMode Settings")]
    public int maxPlayers = 2;
    public int activePlayers;
    public int roundNumber = 0;
    [SerializeField] int maxRound = 10;
    public enum TeamColor { none, Blue, Red, Green, White };
    public enum GameModes {None, Lobby, Online, Solo };
    public enum GameState {None, Start, End, Paused, Idle, Active }

    public GameModes selectedGameMode;
    
    [Header("player settings")]
    public PlayerMovement playerController;
    [System.Serializable]
    public struct PlayerInformation
    {
        public GameObject PlayerCharacter;
        public string PlayerName;
        public int PlayerNumber;
        public int Score;
        public ScoringPlaneLogic PlayerGoal;
        public Color TeamColor;
        public bool IsAi;
        public PlayerInformation(GameObject PlayerCharacter, string PlayerName, int PlayerNumber, int Score, Color TeamColor, bool IsAi, ScoringPlaneLogic PlayerGoal)
        {
            this.PlayerCharacter = PlayerCharacter;
            this.PlayerName = PlayerName;
            this.PlayerNumber = PlayerNumber;
            this.Score = Score;
            this.TeamColor = TeamColor;
            this.IsAi = IsAi;
            this.PlayerGoal = PlayerGoal;
        }

    }

    private void Awake()
    {
        if (_ != null && _ != this)
        {
            Destroy(_);
        }
        else
        {
            _ = this;
            DontDestroyOnLoad(GameSystemManager._);
        }
        
        
        



    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
            
           
           
      

    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SelectGameMode(GameModes gameMode) 
    {
        
        selectedGameMode = gameMode;
        print(gameMode + " is the new gamemode");
    }
    public void OpenOptions(GameObject opener)
    {
       // activeUIElement = Object.Instantiate(OptionsUI, _canvas.transform, false);

        
            
            activeUIElement =  Object.Instantiate(OptionsUI, _canvas.transform, false);
            print("Options menu was instantiated");
            SetActiveUiElement(activeUIElement, true);
            activeUIElement.SendMessage("TabClicked", OptionsManager.OptionsTabs.Graphics , SendMessageOptions.DontRequireReceiver);
       

        
       
        OptionsManager._._OpenedFrom = opener;
           // print((activeUIElement == PrefabUtility.GetCorrespondingObjectFromSource(OptionsUI)) + activeUIElement.name + "\\" + opener.name);
           
    }
    public void OpenInGameUI()
    {
       

        SetActiveUiElement(mainUi, true);
    }
    public void SetActiveUiElement(GameObject uiElement, bool ON)
    {
        activeUIElement = uiElement;
        if (ON)
        {   activeUIElement.SetActive(true);
            
        }
        else 
        {
            activeUIElement = null;
        }
    }

}
