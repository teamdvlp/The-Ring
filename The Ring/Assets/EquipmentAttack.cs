using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentAttack : MonoBehaviour {
	public int speed;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddTorque(speed);
		// transform.parent.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(speed, speed), transform.position);
		// GetComponent<Rigidbody2D>().AddForceAtPosition(new Vector2(speed, speed), transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
