using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armo : MonoBehaviour {
    public bool isEquiped;
    public GameObject explosionEffect;
    public int stiffness;

    public void CollisionEnter2D(Collision2D col)
    {
        ContactPoint2D[] point = col.contacts;
        Instantiate(explosionEffect, point[0].point, Quaternion.identity);
        stiffness -= 1;
        if (stiffness <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
    }
	
}
