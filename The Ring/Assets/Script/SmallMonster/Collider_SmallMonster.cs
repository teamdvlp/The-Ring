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

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer.Equals("CirclePlayer")) {
            Destroy(other.gameObject);
        }
    }
}
