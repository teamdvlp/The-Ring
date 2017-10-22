using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text currentScoreText;
    float minute, second;
<<<<<<< HEAD
    int score;
    private bool isGameStarted;
=======
    string score, minuteText, secondText;
	public OnGameOver OnGameOver;


>>>>>>> bc8daadad1140894b9b89d2bd69c829021019ff4
	// Use this for initialization
    
	void Start () {
        isGameStarted = false;
        minute = 0;
        second = 0;    
<<<<<<< HEAD
        GetComponent<Intro>().onGameStarted += OnGameStarted;
=======

>>>>>>> bc8daadad1140894b9b89d2bd69c829021019ff4
    }
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
        if (isGameStarted) {
            score = (int) (this.transform.position.y + 2.65);
        }
        currentScoreText.text = score + "" ;
=======
        second += Time.deltaTime;
        if (second >= 60)
        {
            second = 0;
            minute++;
        }

        secondText = second < 10 ? "0" + second.ToString("#") : second.ToString("#");
        minuteText = minute < 10 ? "0" + minute.ToString() : minute.ToString();
        score = minuteText + " : " + secondText;
        second += 1;
        // if (second >= 60)
        // {
        //     second = 0;
        //     minute++;
        // }

        // secondText = second < 10 ? "0" + second.ToString("#") : second.ToString("#");
        // minuteText = minute < 10 ? "0" + minute.ToString() : minute.ToString();
        score = second + "";
        currentScoreText.text = score;
>>>>>>> bc8daadad1140894b9b89d2bd69c829021019ff4
    }


    void OnDisable()
    {
        scoreText.text = score + "";
    }

    private void OnGameStarted () {
        isGameStarted = true;
    }
}
