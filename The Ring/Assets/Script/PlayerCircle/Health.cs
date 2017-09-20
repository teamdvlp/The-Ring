using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;
	public bool isDead; 
	// Use this for initialization
	void Start () {
		health  = 10;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		OnDead();
	}

	public void takeDamge () {
		if (isDead) {
			return;
		}
		this.health -= 3;
	}

	public void OnDead () {
		if (health >= 0) {
			return;
		}
		if (isDead) {
			return;
		}

		isDead = true;
		Destroy(this.gameObject);
	}
}
