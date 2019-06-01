using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject clickText;
    public GameObject scoreText;
    public GameObject newHighScoreText;
    public Text score;
    public Text scoreLabelText;
    public Text highScore1;
    public Text highScore2;
    public static UIManager current;

    void Awake()
    {
        //If the current variable is not instantiated, we do instantiate it here.
        if (current == null) 
            current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Checks if High Score already exists and prints its score
        if (PlayerPrefs.HasKey("highscore"))
            highScore1.text = "High Score: " + PlayerPrefs.GetInt("highscore"); //Here I don't need to put "ToString after "highscore" because when an int gets concatenated with a String, it becomes a String itself (implcitly)  
        else
        {
            highScore1.text = "High Score: 0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        clickText.GetComponent<Animator>().Play("textDisappear");
        startPanel.GetComponent<Animator>().Play("StartPanelDisappear");
        scoreText.SetActive(true);

    }
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highscore").ToString();
  
        gameOverPanel.SetActive(true);
        scoreText.SetActive(false);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
