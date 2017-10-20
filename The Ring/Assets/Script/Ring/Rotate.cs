﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    public float speed;
	Rigidbody2D rigid;

	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
        rotate();
	}

    private void rotate()
    {
		rigid.angularVelocity = speed;
	}
}	
