using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public Trackpad trackpad;
    public float speed;

    void Start () {
		
	}
	void Update () {

        this.GetComponent<Rigidbody2D>().velocity = trackpad.positionOffset * speed ;
        trackpad.positionOffset = Vector2.zero;
	}

    void LimitMovement ()
    {
    }
}
