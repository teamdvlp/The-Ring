using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x,this.gameObject.transform.position.y + 2*Time.deltaTime,0);		
	}
}
