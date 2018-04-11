using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    // From the inspector, drag & Drop the GameObject holding the Text component used to display the score
    [SerializeField]

    private static int score = 0;
    public Text scoreText;

    //To add or subtract score, use
    // private ScoreManager scoreManager;
    //then
    //scoreManager.Score++;
    //scoreManager.Score--;

    void Start()
    {
        scoreText.text = "Score: " + score;
    }


    private void Update()
    {
        PlayerPrefs.SetInt("player_score", score);
        scoreText.text = "Score: " + score;
    }

    public void updateScoreView()
    {
        PlayerPrefs.SetInt("player_score", score);
    }

    public void AddScore(int NewscoreValue)
    {
        score = score + 1;
        updateScoreView();
        PlayerPrefs.SetInt("player_score", score);
    }


}

