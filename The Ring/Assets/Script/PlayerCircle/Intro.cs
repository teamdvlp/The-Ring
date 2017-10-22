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
	public PhysicsMaterial2D bounceMaterial;
    private bool isCollided = false;
	public Swipe swipe;

	public delegate void GameStarted ();

	public event GameStarted onGameStarted; 
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
		// swipe.enabled = false;	
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
	    this.Stove.GetComponent<PolygonCollider2D>().enabled = false;
        Destroy(Stove.GetComponent<ParticleSystem>());
        this.Stove.GetComponent<Animator>().SetBool("Shake", false);
		this.ProcessFlyingPiece ();
		this.SmokeBurst.GetComponent<ParticleSystem>().Play();
		this.gameObject.layer = 15;
		this.gameObject.GetComponent<CircleCollider2D> ().sharedMaterial = bounceMaterial;
		Rigidbody2D player = this.gameObject.GetComponent<Rigidbody2D>();
		player.gravityScale = 0;
		player.velocity = Vector2.zero;
		player.drag = 5;
		if (onGameStarted != null) {
			onGameStarted();
		}
		// swipe.enabled = true;
		StartCoroutine(CleanUp(5));
    }

	private void ProcessFlyingPiece() {
		Rigidbody2D right = this.pieceRight.GetComponent<Rigidbody2D>();
		right.AddForce (new Vector2 (300, 200));
		right.AddTorque (-150f);
		Rigidbody2D left = this.pieceLeft.GetComponent<Rigidbody2D>();
		left.AddForce (new Vector2 (200, -100));
		left.AddTorque(-150f);
		Rigidbody2D top = this.pieceTop.GetComponent<Rigidbody2D>();
		top.AddForce (new Vector2 (-200, 300));
		top.AddTorque (100);
		Rigidbody2D bottom = this.pieceBottom.GetComponent<Rigidbody2D>();
		bottom.AddForce(new Vector2(-100, -200));
		bottom.AddTorque(100);
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