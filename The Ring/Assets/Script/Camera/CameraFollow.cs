using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float smoothing;
	public Transform target;
	public float YLimit;
	// true: trái, false: phải
	public bool direction;

	private Vector3 offset;
	void Start () {
		this.offset = new Vector3 (this.transform.position.x - this.target.transform.position.x, this.transform.position.y - this.target.transform.position.y, -10);
        
    }
	void Update () {
        LimitMovement();
    }

    void LimitMovement()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

}
