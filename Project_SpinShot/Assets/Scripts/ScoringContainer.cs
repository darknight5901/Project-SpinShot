using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static GameSystemManager;


public class ScoringContainer : MonoBehaviour
{
    

    public GameObject scoreHolder;
    public List<GameObject> playerGoals;
    public List<GameObject> playerScores;
    public List<PlayerInformation> players;
    public List<TMP_Text> scoreText;
    public int playerCount;
    public GameObject playerScorePREFAB;
    [SerializeField] GameObject ScoreHolder;
    
    
    
    private void Awake()
    {
      //  teamScores = new List<GameObject>();
        players = new List<PlayerInformation>();
        scoreText = new List<TMP_Text>();
    }
    public void InitPlayerWidgets(int playerIndex, GameObject[] playerObjects)
    {
        for (int i = 0; i <= playerIndex; i++)
        {
            if (playerObjects[i].TryGetComponent<PlayerMovement>(out PlayerMovement playerScript))

            {
                players.Add(playerScript.playerInformation);

                playerScores.Add(Instantiate(playerScorePREFAB));
                scoreText.Add(playerScores[i].GetComponent<TMP_Text>());
                playerScores[i].transform.parent = ScoreHolder.transform;
            }
            
        }

        return;
    }
    
    private void InitGoals(int playerIndex, GameObject[] goalObjects)
    {
        for (int i = 0; i <= playerIndex; i++)
        {
            if (goalObjects[i].TryGetComponent<ScoringPlaneLogic>(out  ScoringPlaneLogic scoringPlaneLogic))
            {
                playerGoals.Add(goalObjects[i]);
            }
        }
    }
   

    private void Start()
    {
        GameObject[]goalObjects = GameObject.FindGameObjectsWithTag("Goal");
        GameObject[]playerObjects = GameObject.FindGameObjectsWithTag("Player");
        
       // CreateTeamScoreWidgets();
       playerCount = playerObjects.Length;
       InitPlayerWidgets(playerCount, playerObjects );
        InitGoals(playerCount, goalObjects );
             
    }
    private void SetColors(GameSystemManager.TeamColor color)
    {
        switch (color )
        {
            case GameSystemManager.TeamColor.White:
                scoreText[playerCount].color = Color.white; 
                break;
            case GameSystemManager.TeamColor.Blue:
                scoreText[playerCount].color = Color.blue;
                break;
            case GameSystemManager.TeamColor.Red:
                scoreText[playerCount].color = Color.red;
                break;
            case GameSystemManager.TeamColor.Green:
                scoreText[playerCount].color = Color.green;
                break;
                
            default:
                scoreText[playerCount].color = Color.grey;
                break;
        }
    }
    private void AssignColor()
    {
        for (int i = 0; i <= playerCount; i++)
        {

          //  teamScoreWidget = Instantiate(playerScorePREFAB);
           // PlayerIndex.Add(teamScoreWidget);
           // teamScoreWidget.transform.SetParent(scoreHolder.transform, false);
          //  scoreText[i] = teamScoreWidget.GetComponent<TMP_Text>();
            playerCount = i;
            switch (playerCount)
            {
                case 0:
                    SetColors(GameSystemManager.TeamColor.Blue);
                    scoreText[playerCount].color = new Color(0, 0, 255);
                    print("Blue team color assigned");
                    break;
                case 1:
                    SetColors(GameSystemManager.TeamColor.Red);
                    scoreText[playerCount].color = new Color( 255, 0, 0);
                    print("Red team color assigned");
                    break;
                case 2:
                    SetColors(GameSystemManager.TeamColor.Green);
                    scoreText[playerCount].color = new Color(0, 255, 0);
                    print("Green team color assigned");
                    break;
                default:
                    SetColors(GameSystemManager.TeamColor.White);
                    scoreText[playerCount].color = new Color(0,0,0);
                    print("White team color assigned");
                    break;
            }
            
            //   scoreText[i]. = this.gameObject;
        }
    }
    public void AddScore(int TeamIndex)
    {
        
    }
}
