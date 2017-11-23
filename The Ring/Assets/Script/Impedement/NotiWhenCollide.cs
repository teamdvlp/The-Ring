using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpeNotiWhenCollide : MonoBehaviour {

	public delegate void WoodCollide(GameObject col);
	public event WoodCollide OnWoodCollide;
	public delegate void InOutChainSawCollide(GameObject col);
	public event InOutChainSawCollide OnInOutChainSawCollide;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

		void OnCollisionEnter2D(Collision2D other)
	{	
		if (this.gameObject.name.Equals("ChainsawAbcs_0")) {
			if (OnInOutChainSawCollide != null) {
				OnInOutChainSawCollide(other.gameObject);
			}
		}	
		if (this.gameObject.name.Equals("Wood1")) {
		if (OnWoodCollide != null) {
			OnWoodCollide(other.gameObject);
		}
		}
			
	}
}
