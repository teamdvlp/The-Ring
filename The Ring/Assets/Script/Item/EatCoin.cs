﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatCoin : MonoBehaviour {
	public Text coinText;
	static int coin;
	public GameOver onGameOver;


	// Use this for initialization
	void Start () {
        coin = 0;
		onGameOver.OnOverGame += OnGameOver;
        Debug.Log(SqliteUserManager.getCoin().ToString());
        Debug.Log(SqliteUserManager.getBestScore().ToString());
    }


    public void OnGameOver () { 
		SqliteUserManager.AddCoin (coin);
    }


	public void OnTriggerEnter2D (Collider2D col) { 
		if (col.gameObject.tag.Equals("Coin")) {
            PlusCoin(1);
            Destroy(col.gameObject);
        } else if (col.gameObject.tag.Equals("Ruby")) {
			PlusCoin (10);
            Destroy(col.gameObject);
        }
    }


	private void PlusCoin (int coinCount) {
        coin = coin + coinCount;
        coinText.text = coin.ToString();
	}
}
