using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public Vector3 pos;
	public float speed;
	Rigidbody2D rigid;

	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		pos = transform.position;
	}
	
	void Update () {
        rotate();
	}

    private void rotate()
    {
		transform.position = pos;
		rigid.angularVelocity = speed;
	}
}	
