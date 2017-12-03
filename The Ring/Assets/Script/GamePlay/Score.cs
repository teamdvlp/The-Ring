using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text currentScoreText;
    public Text coinToRespawnText;
    private bool isGameStarted;
    public int score;
	public OnGameOver OnGameOver;
    public GameOver gameOver;
    private static int coinToRespawn;
    
    
	void Start () {
        coinToRespawn = 10;
        isGameStarted = false;
        //GetComponent<Intro>().onGameStarted += OnGameStarted;
        // gameOver.OnOverGame += OnOverGame;
        // OnGameOver.OnPlayerRespawn += OnRespawn;
    }
	
	void Update () {
        if (isGameStarted) {
            score = (int) (this.transform.position.y + 2.65);
        }
        currentScoreText.text = score + "";
    }


    void OnDisable()
    {
        scoreText.text = score + "";
    }

    private void OnGameStarted () {
        isGameStarted = true;
    }



    private void OnOverGame () {
        isGameStarted = false;
        coinToRespawn = 10;
        int currentBestScore = SqliteUserManager.getBestScore();
        if (currentBestScore <= score) {
            SqliteUserManager.setBestScore(score);
        }
        SqliteUserManager.AddCoin(score);
    }



    private bool OnRespawn ()
    {
        if (SqliteUserManager.getCoin() > coinToRespawn)
        {
            SqliteUserManager.AddCoin(-coinToRespawn);
            coinToRespawn += 10;
            return true;
        } else
        {
            return false;
        }
    }
}
