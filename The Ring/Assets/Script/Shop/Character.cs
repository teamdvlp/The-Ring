using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Character {
    // Đã bao gồm đường dần đến Folder Character (CharacterPrebs). Không cần thêm vào
    public string path { private set; get; }

    public long price { private set; get; }
    public float speed { private set; get; }
    public int id { private set; get; }
    public bool isBought;
    public bool isChoosen;


	public Character (string path, long price, float speed) {
		this.path = path;
		this.price = price;
		this.speed = speed;
		this.id = -1;
	}

    public Character(string path, long price, float speed, bool isBought, bool isChoosen)
    {
        this.path = path;
        this.price = price;
        this.speed = speed;
        this.id = -1;
        this.isBought = isBought;
        this.isChoosen = isChoosen;
    }

    public void setId (int id) {
		if (id == -1) {
			this.id = id;
		}
	}
}


