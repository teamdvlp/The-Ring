using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Trackpad trackpad;
    public int speed;
    public float transsexual;
    void Start () {
		
	}
	
	void Update () {
			this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed;
			trackpad.positionOffset = trackpad.positionOffset * transsexual;
}
}
