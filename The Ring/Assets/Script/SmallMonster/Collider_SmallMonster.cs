using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_SmallMonster : MonoBehaviour {
	OnGameOver onGameOver;


    // Use this for initialization
    void Start () {
		onGameOver = this.GetComponent<OnGameOver> ();
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.layer == 12)
        {
            onGameOver.Die();
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals("Monster"))
        {
            onGameOver.Die();
        }
    }
}
