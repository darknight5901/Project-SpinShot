using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoringPlaneLogic : MonoBehaviour
{
    [SerializeField] ScoringContainer scoringContainer;
    [SerializeField] TMPro.TMP_Text scoreText;
    [SerializeField] int PlayerIndex;
    [SerializeField] int Score;
    
    [SerializeField] GameSystemManager.TeamColor color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {  // if (scoringContainer.scoreText != null)

         scoreText = scoringContainer.scoreText[PlayerIndex]; 
       // else { print("no score text to associate with" + gameObject); }
       
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other + " just hit the " + gameObject);
        
        if (other.CompareTag("Ball"))
        {
            bool onLeftSide = transform.position.x < 0;
            AddScore();
            other.BroadcastMessage("ResetBall", onLeftSide);
        }
    }
    public void AddScore()
    {
        
        Score++;
        
    //    GameSystemManager._.mainUi;
       
        print(Score + " is the score for " + gameObject);
    }
    private void Reset()
    {
        Score = 0;
    }
}
