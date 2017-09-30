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
        if (other.layer == 12)
        {
            //Destroy(other.gameObject);
            this.GetComponent<OnGameOver>().ProcessGameOver();
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag.Equals("Monster"))
        {
            this.GetComponent<OnGameOver>().ProcessGameOver();
           // Destroy(gameObject);
        }
    }
}
