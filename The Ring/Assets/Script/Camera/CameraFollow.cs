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
        follow();
    }

	private void follow () {
		if (this.target != null) {
				this.gameObject.transform.position = Vector3.Lerp (new Vector3(this.transform.position.x, this.transform.position.y, -15f),new Vector3(this.transform.position.x,target.transform.position.y + offset.y, -15), this.smoothing * Time.deltaTime);
			}
		}

}
