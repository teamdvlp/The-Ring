using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatCoin : MonoBehaviour {
	public Text coinText;
	static int coin;
	public GameOver onGameOver;
    public AudioSource audiO;


	// Use this for initialization
	void Start () {
        coin = 0;
		// onGameOver.OnOverGame += OnGameOver;
    }

    public void OnGameOver () { 
		SqliteUserManager.AddCoin (coin);
    }

    private void OnApplicationPause(bool pause)
    {
        
    }

    public void OnTriggerEnter2D (Collider2D col) { 
		if (col.gameObject.tag.Equals("Coin")) {
            // PlusCoin(1);
            Destroy(col.gameObject);
            audiO.Play();
        } else if (col.gameObject.tag.Equals("Ruby")) {
            // PlusCoin (10);
            audiO.Play();
            Destroy(col.gameObject);
        }
    }


	private void PlusCoin (int coinCount) {
        coin =  coin + coinCount;
        coinText.text = "<b> " + coin.ToString() + "</b>";
	}
}
