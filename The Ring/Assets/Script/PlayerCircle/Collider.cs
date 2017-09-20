using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D col) {
		this.GetComponent<Healthy>().takeDamge();
		this.GetComponent<Healthy>().continueDamage = false;
		Debug.Log("Enter");
	}

	void OnCollisionExit2D (Collision2D col) {
		this.GetComponent<Healthy>().continueDamage = true;
		Debug.Log("Exit");
	}

}
