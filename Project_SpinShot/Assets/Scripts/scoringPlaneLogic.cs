using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoringPlaneLogic : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text scoreText;
    [SerializeField] int Score;
    [SerializeField] bool blueTeam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Ball"))
        {
            AddScore();
            other.BroadcastMessage("ResetBall",blueTeam);
        }
    }
    public void AddScore()
    {
        
        Score++;
        scoreText.text = Score.ToString();
        
       
        print(Score);
    }
    private void Reset()
    {
        Score = 0;
    }
}
