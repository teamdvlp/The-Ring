using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text currentScoreText;
    float minute, second;
    private bool isGameStarted;
    int score;
	public OnGameOver OnGameOver;
    
	void Start () {
        isGameStarted = false;
        minute = 0;
        second = 0;    
        GetComponent<Intro>().onGameStarted += OnGameStarted;
        GetComponent<OnGameOver>().OnOverGame += OnOverGame;    
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
        int currentBestScore = SqliteUserManager.getBestScore();
        if (currentBestScore <= score) {
            SqliteUserManager.setBestScore(score);
        }
    }
}
