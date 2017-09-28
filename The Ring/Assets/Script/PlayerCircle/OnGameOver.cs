using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour {
    public GameObject deathEffect;
    public GameObject GameManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDestroy()
    {
        ProcessGameOver();    
    }

    void ProcessGameOver()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        GameManager.GetComponent<GameOver>().OverGame();
    }
}
