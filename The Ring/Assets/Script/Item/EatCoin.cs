using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatCoin : MonoBehaviour {

	public int totalUserCoin;
	int coin;
	public SqliteUserManager manager;
	public Score score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D (Collider2D col) { 
		if (col.gameObject.tag.Equals("Coin"));
		score.score++;
	}
}
