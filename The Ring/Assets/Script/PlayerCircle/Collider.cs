using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

    float takeDamageTime;
    bool cantakeDamage;
    bool isColliding;
    // Use this for initialization
	void Start () {
        isColliding = false;
        cantakeDamage = false;
        takeDamageTime = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (isColliding)
        {
            if (!cantakeDamage)
            {
                takeDamageTime -= Time.deltaTime;
                if (takeDamageTime <= 0)
                {
                    cantakeDamage = true;
                }
            }
        }
    }

	void OnCollisionEnter2D (Collision2D col) {
        isColliding = true;
        if (col.gameObject.tag == "Circle")
        {
            if (cantakeDamage)
            {
                this.gameObject.GetComponent<Health>().takeDamge();
                cantakeDamage = false;
                takeDamageTime = 0.5f;
            }
            isColliding = true;
        }
        Debug.Log("Enter");

    }

    void OnCollisionExit2D (Collision2D col)
    {
        Debug.Log("Exit");
        isColliding = false;
        takeDamageTime = 0.0f;
        cantakeDamage = false;
    }
}
