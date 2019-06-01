using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager current;
    int score;
    int highscore;
    bool highscorePlayed;
    public AudioClip highScoreFx;
    public AudioClip diamondFx;


    void Awake()
    {
        if (current == null) //If the current variable is not instantiated, we do instantiate it here.
            current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highscorePlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisplayCurrentScore()
    {
        UIManager.current.scoreLabelText.text = "Score: " + score;
    }

    void DisplayNewHighScore()
    {
        if (PlayerPrefs.HasKey("highscore")) //If high score already exists
        {
            if (score > PlayerPrefs.GetInt("highscore") && !highscorePlayed) //Displays "new high score reached" when current score is higher than high score, 
            {
                UIManager.current.newHighScoreText.SetActive(true);
                AudioManager.current.PlaySound(highScoreFx);
                highscorePlayed = true;
            }
        }
    }
    void IncreaseScore()
    {
        score++;
        DisplayCurrentScore();
        DisplayNewHighScore();

    }

    public void DiamondScore()
    {
        int rand = Random.Range(0, 6);
        score += rand;
        AudioManager.current.PlaySound(diamondFx);
        DisplayCurrentScore();
        DisplayNewHighScore();
    }

    public void StartScore()
    {
        InvokeRepeating("IncreaseScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncreaseScore");

        //Registers the last obtained score
        PlayerPrefs.SetInt("score", score);

        //Registers high score
        if (PlayerPrefs.HasKey("highscore")) //If high score already exists
        {
            if(score>PlayerPrefs.GetInt ("highscore")) //If current score is higher than high score
            PlayerPrefs.SetInt("highscore", score);
        }
        else
        {
            PlayerPrefs.SetInt("highscore",score);
        }
        
    }
}
