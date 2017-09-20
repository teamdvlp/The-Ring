using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Joystick joystick;
	public float speed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new	Vector2 (joystick.InputDirection.x * speed, joystick.InputDirection.z * speed);	
	}
}
