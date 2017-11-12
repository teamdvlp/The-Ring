using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAttractor : MonoBehaviour {
	
	void Start () {
		
	}
	
	void Update () {
        transform.position = transform.parent.position;
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals("Coin"))
        {
            col.gameObject.AddComponent(typeof (AttractCoin));
        }
    }

}
