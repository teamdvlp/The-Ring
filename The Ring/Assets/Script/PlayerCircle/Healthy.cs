using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthy : MonoBehaviour {
	public int health {private set; get;}
	public bool isDead; 
	// Use this for initialization
	void Start () {
		health  = 3;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		OnHealthEqual0();
	}

	public void takeDamge () {
		if (isDead) {
			return;
		}
		this.health -= 1;
	}

	public void OnHealthEqual0 () {
		if (health > 0) {
			return;
		}
		if (isDead) {
			return;
		}

		isDead = true;
		Destroy(this.gameObject);
	}
}
