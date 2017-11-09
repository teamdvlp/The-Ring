using System.Collections;
using UnityEngine;
public class Collider : MonoBehaviour {
	public GameObject collideEffect;
	private Nature mNature;
	private ChangeNature changeNature;
	CompareNature compareNat = new CompareNature();
	private int natureIndex1,natureIndex2, compareResult;
	private GameObject ring;
	public Swipe swipe;
	public Rigidbody2D mRigidBody;
	private bool stunned;
	private bool isStopRotate;
	private bool isStartGame; 
	public EndlessManager endManager;
	void Start () {
		isStartGame = false;
		stunned = false;
		isStopRotate = false;
		mRigidBody = this.GetComponent<Rigidbody2D>();
		changeNature = this.GetComponent<ChangeNature>();
		this.GetComponent<Intro>().onGameStarted += OnStartGame;
		mNature = this.GetComponent<Nature>();
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == 9) {
			if (compareResult == 2) {
				if (!stunned) {
					stunned = true;
					Stun();
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == 9) {
			if (isStopRotate) {
				isStopRotate = false;
				col.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
				col.gameObject.transform.localEulerAngles = new Vector3(0,0,180);
			}
		} else if (col.gameObject.layer == 21) {
			endManager.CreateNewMap();
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		stunned = false;
	}

    void CollideEffect (Collision2D col)
    {
        ContactPoint2D point = col.contacts[0];
        Vector2 position = point.point;
        Instantiate(collideEffect,position,gameObject.transform.rotation);
    }

    void OnCollisionStay2D (Collision2D col)
    {
        CollideEffect(col);
    }
	private void processCollideWithAgainstRing(GameObject Ring)
	{

		var collision = Ring.GetComponentInChildren<ParticleSystem>().collision;
		collision.enabled = true;
	}

	private void processCollideWithNormalRing(GameObject Ring)
	{
		var collision = Ring.GetComponentInChildren<ParticleSystem>().collision;
		collision.enabled = false;
	}

	private void Stun () {
		swipe.enabled = false;
		mRigidBody.velocity = Vector2.zero;
		StartCoroutine(CancelStun(1.0f));
	}

	private IEnumerator CancelStun (float second) {
		yield return new WaitForSeconds(second);
		swipe.enabled = true;
	}

	void OnTriggerStay2D(Collider2D col)
		{
			if (col.gameObject.layer == 14) {
			processCollider(col.gameObject);
		}
		}

		private void processCollider (GameObject col) {
			if (!isStartGame) {
				return;
			}
            ring = col.gameObject.transform.parent.gameObject;
		    if (ring.GetComponent<Nature> () == null) {
				return;
			}
			natureIndex1 = mNature.nature;
		    natureIndex2 = ring.GetComponent<Nature> ().nature;
		    compareResult = compareNat.compareNature (natureIndex1, natureIndex2);	
		    switch (compareResult) {
		    case 0:
			    {
						ring.GetComponent<PolygonCollider2D>().isTrigger = true;
						isStopRotate = true;
						return;
			    }
    	    case 1:
            	    {
            		    ring.GetComponent<PolygonCollider2D>().isTrigger = true;	
						isStopRotate = true;
					    return;
            	    }
		    default:
					    ring.GetComponent<PolygonCollider2D>().isTrigger = false;
					    return;
		}
	}

	private void OnStartGame () {
		isStartGame = true;
	}
}
