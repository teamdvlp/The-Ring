using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {
    public GameObject explosionEffect;
    public CircleCollider2D col;
    public float existTime;
    
    void OnEnabled ()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        ContactPoint2D[] point = col.contacts;
        Instantiate(explosionEffect, point[0].point, Quaternion.identity);
    }
	
}
