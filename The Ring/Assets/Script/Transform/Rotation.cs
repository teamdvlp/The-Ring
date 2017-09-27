using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float speed;

	void Start () {
		
	}
	
	void Update () {
        float dt = Time.deltaTime;
        rotate(dt);
	}

    private void rotate(float dt) {
        this.gameObject.transform.Rotate(new Vector3(0,0, this.gameObject.transform.localRotation.z + speed * dt));
    }
}
