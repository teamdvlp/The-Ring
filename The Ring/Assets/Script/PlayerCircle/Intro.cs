using System.Collections;
using UnityEngine;

public class Intro : MonoBehaviour {
    public GameObject ParSmallMonsterL;
	public GameObject ParSmallMonsterR;
	public GameObject Monster;

    public GameObject Stove;
    public GameObject pieceLeft;
    public GameObject pieceRight;
    public GameObject pieceBottom;
    public GameObject pieceTop;
    public GameObject SmokeBurst;

    private bool isCollided = false;

	void Start () {
        isCollided = false;
        PrepareFallInStove();
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
		
        if (!isCollided) {
            isCollided = true;
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
        Destroy(Stove.GetComponent<ParticleSystem>());
        this.Stove.GetComponent<Animator>().SetBool("Shake", false);
        this.pieceRight.GetComponent<Rigidbody2D>().AddForce(new Vector2(300,200));
        this.pieceRight.GetComponent<Rotate>().speed=-150;
		this.pieceLeft.GetComponent<Rigidbody2D>().AddForce(new Vector2(200, -100));
        this.pieceLeft.GetComponent<Rotate>().speed = -150;
		this.pieceTop.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200, 300));
		this.pieceTop.GetComponent<Rotate>().speed = 100;
		this.pieceBottom.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, -200));
        this.pieceBottom.GetComponent<Rotate>().speed = 100;
		this.SmokeBurst.GetComponent<ParticleSystem>().Play();
		this.gameObject.layer = 15;
		this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
		this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		this.gameObject.GetComponent<Movement>().enabled = true;
        Destroy(this.Stove.GetComponent<PolygonCollider2D>());

        StartCoroutine(CleanUp(5));
    }

    private IEnumerator CleanUp (float delay) {
        yield return new WaitForSeconds(delay);
		Destroy(this.Stove);
        Destroy(this.SmokeBurst);
	}

    private IEnumerator wakeUpMonster (float delay) {
        yield return new WaitForSeconds(delay);
        Monster.SetActive(true);
        ParSmallMonsterL.SetActive(true);
        ParSmallMonsterR.SetActive(true);
    }
    
}
