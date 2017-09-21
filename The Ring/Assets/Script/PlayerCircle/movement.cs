using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Trackpad trackpad;
	void Start () {
		
	}
	
	void Update () {
			this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * 80;
			trackpad.positionOffset = Vector2.zero;
}
}
