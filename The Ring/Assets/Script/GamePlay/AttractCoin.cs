using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractCoin : MonoBehaviour {

    public GameObject player;

	void Update () {
        if (gameObject != null)
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.1f);		
	}

    void OnTriggerEnter2D (Collider2D  col)
    {
        if (col.gameObject.name.Equals("Magnet"))
        {
            this.player = col.gameObject;
        }
    }
}