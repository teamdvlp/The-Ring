using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour {
    public GameObject ContinueBoard;
    public GameObject deathEffect,respawnEffect;
    public delegate bool RespawnEvent();
    public event RespawnEvent OnPlayerRespawn;
    // Properties Of Player
    public GameObject directionCircle;
    public GameObject MovingEffect;
    SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2D;
    public GameOver gameOver;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
    public void Die()
    {
        Debug.Log("DIE");
        ContinueBoard.SetActive(true);
        gameObject.SetActive(false);
        Instantiate(deathEffect, transform.position, transform.rotation);
    }

    public void Respawn ()
    {
        //if (OnPlayerRespawn != null)
        //{
        //    if (OnPlayerRespawn())
        //    {
        Debug.Log("RESPAWN");
                ContinueBoard.SetActive(false);
        gameObject.SetActive(true);
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                StartCoroutine(CreateRespawnEffect());
        //    }
        //    else
        //    {
        //        Debug.Log("You have not enough coin to Respawn");
        //    };
        //} else
        //{
        //    Debug.Log("NullOnPlayerRespawn");
        //}
        
    }

    private IEnumerator CreateRespawnEffect()
    {
        yield return new WaitForSeconds(.05f);
        Instantiate(respawnEffect, transform.position, transform.rotation);
    }

    //public void SetState (bool state) 
    //{
    //    if (!state)
    //    {
    //        rigidbody2D.velocity = Vector3.zero;
    //    }
    //    MovingEffect.SetActive(state);
    //    directionCircle.SetActive(state);
    //    spriteRenderer.enabled = state;
    //    colliderWood.enabled = state;
    //}
}
