using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public Vector3 pos;
	public float speed;
	Rigidbody2D rigid;
	float time;

	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		pos = transform.position;
		rigid.angularVelocity = speed;
	}
	
	void Update () {
		
	}

    private void rotate()
    {

	}
}	
