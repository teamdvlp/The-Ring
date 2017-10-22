using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text currentScoreText;
    float minute, second;
    int score;
    private bool isGameStarted;
	// Use this for initialization
    
	void Start () {
        isGameStarted = false;
        minute = 0;
        second = 0;    
        GetComponent<Intro>().onGameStarted += OnGameStarted;
    }
	
	// Update is called once per frame
	void Update () {
        if (isGameStarted) {
            score = (int) (this.transform.position.y + 2.65);
        }
        currentScoreText.text = score + "" ;
    }


    void OnDisable()
    {
        scoreText.text = score + "";
    }

    private void OnGameStarted () {
        isGameStarted = true;
    }
}
