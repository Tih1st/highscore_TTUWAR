using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // From the inspector, drag & Drop the GameObject holding the Text component used to display the score
    [SerializeField]
    private Text scoreText;

    private int score;

    //To add or subtract score, use
    // private ScoreManager scoreManager;
    //then
    //scoreManager.Score++;
    //scoreManager.Score--;


    private void Update()
    {
        PlayerPrefs.SetInt("Player Score", score);
        score = score + 1;
    }

    public void updateScoreView()
    {
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("player_score", score);
    }

    public void AddScore(int NewscoreValue)
    {
        score = score + 1;
        updateScoreView();
        PlayerPrefs.SetInt("player_score", score);
    }


}

