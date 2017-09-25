using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_SmallMonster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnParticleCollision(GameObject other)
    {
        //if (other.layer == 15) {
        //    Destroy(other.gameObject);
        //}
    }
}
