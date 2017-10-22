using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text currentScoreText;
    float minute, second;
    string score, minuteText, secondText;


	// Use this for initialization
	void Start () {
        minute = 0;
        second = 0;    
    }
	
	// Update is called once per frame
	void Update () {
        second += Time.deltaTime;
        if (second >= 60)
        {
            second = 0;
            minute++;
        }

        secondText = second < 10 ? "0" + second.ToString("#") : second.ToString("#");
        minuteText = minute < 10 ? "0" + minute.ToString() : minute.ToString();
        score = minuteText + " : " + secondText;

        currentScoreText.text = score;
    }


    void OnDisable()
    {
        scoreText.text = score;
    }
}
