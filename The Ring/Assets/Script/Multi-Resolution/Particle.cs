using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {
	// Use this for initialization
	void Start () {
		transform.localScale = gameObject.transform.parent.transform.localScale;
		transform.parent = gameObject.transform.parent.transform;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
