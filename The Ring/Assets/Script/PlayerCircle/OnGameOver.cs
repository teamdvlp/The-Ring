using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour {
    public Swipe trackpad;
	public GameObject Monster;
	public GameObject deathEffect, respawnEffect;
	MonsterMovement monsterMovement;
	SpriteRenderer spriteRenderer;
	Rigidbody2D rigidBody2D;
	CircleCollider2D circleCollider2D;

	//Cái bảng Respawn
	public GameObject ContinueBoard;


    // Use this for initialization
    void Start () {
		monsterMovement = Monster.GetComponent<MonsterMovement> ();
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
		circleCollider2D = this.GetComponent<CircleCollider2D> ();
		rigidBody2D = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ProcessPlayerDie()
    {
		SetState (false);
		rigidBody2D.velocity = Vector2.zero ;
        Instantiate(deathEffect, transform.position, transform.rotation) ;
		this.ShowContinueBoard ();
	}



	public void ProcessPlayerRespawn () {
		SetState (true);
		StartCoroutine (CreateRespawnEffect());
		this.HideContinueBoard ();
		this.ProcessRespawnEvent (0);
		this.ProcessRespawnPosition ();		
	}

	IEnumerator CreateRespawnEffect () {
		yield return new WaitForSeconds (0.05f);
		Instantiate(respawnEffect, transform.position, transform.rotation) ;
	}



	private void ProcessRespawnEvent (int subtractRuby) {
		// Xử lý sự kiện khi respawn, trừ tiền
	}



	private void ProcessRespawnPosition () { 
		gameObject.transform.position = new Vector3(0, gameObject.transform.position.y, gameObject.transform.position.z);
	}



	public void SetState(bool canContinue) {
		circleCollider2D.enabled = canContinue;
		spriteRenderer.enabled = canContinue;
		trackpad.enabled = canContinue;
		monsterMovement.enabled = canContinue;	
	}



	void ShowContinueBoard () { 
		ContinueBoard.SetActive (true);
	}

	void HideContinueBoard () { 
		ContinueBoard.SetActive (false	);
	}

}
