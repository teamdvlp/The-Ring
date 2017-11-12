using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Map: " + GetComponent<Renderer>().bounds.size.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
