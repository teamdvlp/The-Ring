using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour {
    public GameObject deathEffect;
    public GameObject GameManager;
    public Swipe swipe;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void ProcessGameOver()
    {
        //		GameObject.Find("MovingEffect").SetActive(false);
        //      GetComponent<CircleCollider2D>().enabled = false;
        //this.GetComponent<SpriteRenderer>().enabled = false;
        //      this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //      swipe.enabled = false;
        this.gameObject.SetActive(false);    
        Instantiate(deathEffect, transform.position, transform.rotation);
        GameManager.GetComponent<GameOver>().OverGame();
    }
}
