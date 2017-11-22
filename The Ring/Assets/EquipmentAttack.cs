using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentAttack : MonoBehaviour {
	public int speed;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddTorque(speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
