using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    void Awake()
    {
        if (current == null) //If the current variable is not instantiated, we do instantiate it here.
            current = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        UIManager.current.GameStart();
        ScoreManager.current.StartScore();
    }

    public void GameOver()
    {
        UIManager.current.GameOver();
        ScoreManager.current.StopScore();
    }
}
