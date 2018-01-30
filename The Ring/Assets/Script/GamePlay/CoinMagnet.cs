using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Khi đồng tiền trúng cái Nam châm thì nó sẽ tự động Add Component Attract Coin
/// 
/// </summary>
public class CoinMagnet : MonoBehaviour {
	
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
