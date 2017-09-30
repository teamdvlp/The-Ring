using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {
    public GameObject ParSmallMonsterL;
	public GameObject ParSmallMonsterR;
	public GameObject Monster;
    public GameObject Stove;
    public GameObject ParticleBrokenStove;
    private bool waked = false;

    // Use this for initialization
	void Start () {
        waked = false;
        PrepareFallInStove();
	}
	
	// Update is called once per frame
	void Update () {
		 
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        PrepareAfterCollide();
    }

    private void PrepareFallInStove () {
        this.gameObject.layer = 16;
		this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        this.gameObject.GetComponent<Movement>().enabled = false;
		}

    private void PrepareAfterCollide () {
		
        if (!waked) {
			waked = true;
            this.Stove.GetComponent<Animator>().SetBool("Shake", true);
			StartCoroutine(wakeUpMonster(10));
            Stove.GetComponent<ParticleSystem>().Play();
			StartCoroutine(PauseParticle(4f));
            StartCoroutine(DestroyStoveAndPutPropertiesBack(5));
        }
    }

    private IEnumerator PauseParticle (float delay) {
        yield return new WaitForSeconds(delay);
        Stove.GetComponent<ParticleSystem>().Pause();
	}

    private IEnumerator DestroyStoveAndPutPropertiesBack(float delay) {
        yield return new WaitForSeconds(delay);
		this.gameObject.layer = 15;
		this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		this.gameObject.GetComponent<Movement>().enabled = true;
		Destroy(this.Stove);
	} 

    private IEnumerator wakeUpMonster (float delay) {
        yield return new WaitForSeconds(delay);
        Monster.SetActive(true);
        ParSmallMonsterL.SetActive(true);
        ParSmallMonsterR.SetActive(true);
    }
    
}
