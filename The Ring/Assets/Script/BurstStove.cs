using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstStove : MonoBehaviour {

	void Start () {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(500,500));

	}
	
	void Update () {
	}



}
