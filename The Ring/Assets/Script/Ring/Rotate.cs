using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public Vector3 pos;
	public float speed;
	Rigidbody2D rigid;
	float time;
	private Vector2 startPos;

	void Start () {
		startPos = this.transform.position;
		rigid = GetComponent<Rigidbody2D> ();
		pos = transform.position;
		rigid.angularVelocity = speed;
	}
	
	void Update () {
		
        rotate();
		setPosition();
	}

    private void rotate()
    {

	}

	private void setPosition () {
		this.transform.position = startPos;
	}
}	
