using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatCoin : MonoBehaviour {

	public Text coinText;
	int coin;
	public OnGameOver onGameOver;


	// Use this for initialization
	void Start () {
		onGameOver.OnOverGame += OnGameOver;
	}
	

	public void OnGameOver () { 
		SqliteUserManager.AddCoin (coin);
        Debug.Log(SqliteUserManager.getCoin().ToString());
    }

	public void OnTriggerEnter2D (Collider2D col) { 
		if (col.gameObject.tag.Equals("Coin")) { 
			PlusCoin (1);
		} else if (col.gameObject.tag.Equals("Ruby")) {
			PlusCoin (10);
		}
	}

	private void PlusCoin (int coins) { 
		this.coin += coins;
		coinText.text = coin.ToString();
	}
}
