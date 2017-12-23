using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpeNotiWhenCollide : MonoBehaviour {

	public delegate void WoodCollide(GameObject col);
	public event WoodCollide OnWoodCollide;
	public delegate void InOutChainSawCollide(GameObject col);
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name.Equals("InOutChainSaw")) {

		}
		if (OnWoodCollide != null) {
			OnWoodCollide(other.gameObject);
		}
	}
}
