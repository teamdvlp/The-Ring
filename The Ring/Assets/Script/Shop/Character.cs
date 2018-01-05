using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Character {
	public string path{private set; get;}
	public long price{private set; get;}
	public float speed{private set; get;}
	public int id {private set; get;}


	public Character (string path, long price, float speed) {
		this.path = path;
		this.price = price;
		this.speed = speed;
		this.id = -1;
	}
		
	public void setId (int id) {
		if (id == -1) {
			this.id = id;
		}
	}

}


