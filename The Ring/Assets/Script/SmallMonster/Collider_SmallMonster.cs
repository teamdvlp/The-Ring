using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_SmallMonster : MonoBehaviour {
	OnGameOver onGameOver;
    public FuckingLimit limit;
    //public AudioSource audio;

    // Use this for initialization
    void Start () {
		onGameOver = this.GetComponent<OnGameOver> ();
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //audio.Play();
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
            limit.End();
            Destroy(gameObject);
            //onGameOver.Die();
        }
    }
}
