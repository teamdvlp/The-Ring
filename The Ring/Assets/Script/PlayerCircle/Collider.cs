using System;
using UnityEngine;
public class Collider : MonoBehaviour {

	public GameObject collideEffect;
	public GameObject ringProtect;
	private CircleCollider2D mCircleCollider;

	private bool isCollideCircle;
	private bool isCollideCircleInside;
	private Nature mNature;

	private 

	void Start () {
		isCollideCircleInside = false;
		isCollideCircle = false;
		mCircleCollider = GetComponent<CircleCollider2D>();
		mNature = this.GetComponent<Nature>();
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

	void OnTriggerExit2D (Collider2D col) {
			if (col.gameObject.layer == 9) {
			col.GetComponent<PolygonCollider2D>().isTrigger = false;
			isCollideCircle = false;
			}
			else if (col.gameObject.layer == 18) {
				isCollideCircleInside = false;
			}
			if (col.gameObject.layer == 9) {
				if (!isCollideCircle && !isCollideCircleInside) {
				Debug.Log("Đổi hệ ngoài");
			}
			}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.layer == 14) {
			processCollider(col.gameObject);
		} 
		else if (col.gameObject.layer == 9) {
			isCollideCircle = true;
		}
		else if (col.gameObject.layer == 18) {
			isCollideCircleInside = true;	
		}
		if (col.gameObject.layer == 18) {
			if (isCollideCircle && isCollideCircleInside) {
			Debug.Log("Đổi hệ trong");
		}
		}

    }
	void OnCollisionEnter2D(Collision2D other)
	{
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
	
	void OnTriggerStay2D(Collider2D other)
		{
			if (other.gameObject.layer == 14) {
			processCollider(other.gameObject);
		}
		}
	private int natureIndex1,natureIndex2, compareResult;
	private GameObject ring;
	CompareNature compareNat = new CompareNature();
	private void processCollider (GameObject col) {
        ring = col.gameObject.transform.parent.gameObject;
		natureIndex1 = mNature.nature;
		natureIndex2 = ring.GetComponent<Nature> ().nature;
		compareResult = compareNat.compareNature (natureIndex1, natureIndex2);
		switch (compareResult) {
		case 0:
			{
            		ring.GetComponent<PolygonCollider2D>().isTrigger = false;
                    this.processCollideWithAgainstRing(ring);
					return;
			}
    	case 1:
            	{
            		ring.GetComponent<PolygonCollider2D>().isTrigger = true;
                    this.processCollideWithNormalRing(ring);
					return;
            	}
        case 2:
            {
            		ring.GetComponent<PolygonCollider2D>().isTrigger = false;
					this.processCollideWithNormalRing(ring);
					return;
			}
		case 3: 
			{
            		ring.GetComponent<PolygonCollider2D>().isTrigger = false;
					this.processCollideWithNormalRing(ring);
					return;
			}
		default:
				return;
		}
		
	}
}
