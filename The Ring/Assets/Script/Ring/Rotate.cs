using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public float speed;
	Rigidbody2D rigid;
<<<<<<< HEAD
=======
	float time;
	private Vector2 startPos;
>>>>>>> cc77f9b9842ac80dac0101d42231975205eb9377

	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		rigid.angularVelocity = speed;
	}
<<<<<<< HEAD
=======
	
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
>>>>>>> cc77f9b9842ac80dac0101d42231975205eb9377
}	
