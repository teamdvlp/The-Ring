using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public Vector3 pos;
	public float speed;
	Rigidbody2D rigid;
<<<<<<< HEAD
	float time;
=======
	private Vector2 startPos;
>>>>>>> 1d7c4cc22104395a961a2c9ce44d75552f61ba37

	void Start () {
		startPos = this.transform.position;
		rigid = GetComponent<Rigidbody2D> ();
		pos = transform.position;
		rigid.angularVelocity = speed;
	}
	
	void Update () {
<<<<<<< HEAD
		
=======
        rotate();
		setPosition();
>>>>>>> 1d7c4cc22104395a961a2c9ce44d75552f61ba37
	}

    private void rotate()
    {

	}

	private void setPosition () {
		this.transform.position = startPos;
	}
}	
