using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int score;

	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "" + score;
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name.Equals("Score"))
        {
            score += 10;
            Destroy(col.gameObject);
            Debug.Log("AHIHAI");
        }
    }
}
