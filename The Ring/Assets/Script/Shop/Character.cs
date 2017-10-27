using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {

	public Sprite sprite;
	public int cost;
	public int speed;
	public bool isBought;

	public Character (Sprite sprite, int cost, int speed) {
		this.sprite = sprite;
		this.cost = cost;
		this.speed = speed;
		this.isBought = false;
	}

	public Sprite GetSprite () {
		return this.sprite;
	}

	public int GetCost () {
		return this.cost;
	}

	public int GetSpeed() {
		return this.speed;
	}

	public void SetIsBought (bool isBought) { 
		this.isBought = isBought;
	}


}


