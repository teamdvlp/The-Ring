using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float speed;
	Rigidbody2D rigid;
	private Vector2 startPos;

	void Start () {
		startPos = this.transform.position;
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
        rotate();
		setPosition();
	}

    private void rotate()
    {
		rigid.angularVelocity = speed;
	}

	private void setPosition () {
		this.transform.position = startPos;
	}
}	
