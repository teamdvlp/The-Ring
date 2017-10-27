using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
	public Sprite sprite;
	public int cost;
	public int speed;
	public int id;

	public Character (Sprite sprite, int cost, int speed, int id) {
		this.sprite = sprite;
		this.cost = cost;
		this.speed = speed;
		this.id = id;
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

	public int getId () {
		return this.id;
	}

}


