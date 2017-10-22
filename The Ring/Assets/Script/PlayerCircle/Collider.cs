using System;
using UnityEngine;
public class Collider : MonoBehaviour {
	public GameObject collideEffect;
	private Nature mNature;
	public bool checkNature;
	private bool isBornNature;
	private bool isPlayerInside;
	private ChangeNature changeNature;
	CompareNature compareNat = new CompareNature();
	private int natureIndex1,natureIndex2, compareResult;
	private GameObject ring;
	private NatureSkill mNatureSkill;
	void Start () {
		isPlayerInside = false;
		checkNature = false;
		mNatureSkill = this.GetComponent<NatureSkill>();
		changeNature = this.GetComponent<ChangeNature>();
		isBornNature = false;
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
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == 9) {
		ring = col.gameObject;
		natureIndex1 = mNature.nature;
		natureIndex2 = ring.GetComponent<Nature> ().nature;
		compareResult = compareNat.compareNature (natureIndex1, natureIndex2);
		switch (compareResult) {
		case 0:
				{
					isBornNature = true;
					return;		
				}
		default: {
				isBornNature = false;
				return;
			}
		}	
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		isBornNature = false;
	}

	private void changeNatureWhenGoThroughTheCircle (GameObject Circle) {
		int nature = Circle.GetComponent<Nature>().nature;
		changeNature.SetNature(compareNat.getNatureBorn(nature));
	}

	void OnTriggerStay2D(Collider2D col)
		{
			if (col.gameObject.layer == 14) {
			processCollider(col.gameObject);
		double distance = Math.Sqrt((this.transform.position.x - col.transform.position.x) * (this.transform.position.x - col.transform.position.x)
                                    +
                                   (this.transform.position.y - col.transform.position.y) * (this.transform.position.y - col.transform.position.y));
        if (Math.Abs(distance) < Math.Abs(4.5 - Math.Abs(this.GetComponent<CircleCollider2D>().radius))) {
			if (isBornNature && !isPlayerInside) {
			isBornNature = false;
			changeNatureWhenGoThroughTheCircle(col.transform.parent.gameObject);
			col.transform.parent.gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
			} 
			else if (!isBornNature && !isPlayerInside) {
			// mNatureSkill.BuffSkill(mNature.nature);
			}
			isPlayerInside = true;
		} else if (Math.Abs(distance) > Math.Abs(6 - Math.Abs(this.GetComponent<CircleCollider2D>().radius))) {
			if (isBornNature && isPlayerInside) {
			isBornNature = false;
			changeNatureWhenGoThroughTheCircle(col.transform.parent.gameObject);
			col.transform.parent.gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
			}
			else if (!isBornNature && !isPlayerInside) {
			}
			isPlayerInside = false;
		}
		}
		}

		private void processCollider (GameObject col) {
        ring = col.gameObject.transform.parent.gameObject;
		natureIndex1 = mNature.nature;
		natureIndex2 = ring.GetComponent<Nature> ().nature;
		compareResult = compareNat.compareNature (natureIndex1, natureIndex2);
		switch (compareResult) {
		case 0:
			{
            	ring.GetComponent<PolygonCollider2D>().isTrigger = true;
                // this.processCollideWithNormalRing(ring);
				return;
			}
    	case 1:
            	{
            		ring.GetComponent<PolygonCollider2D>().isTrigger = true;
                    // this.processCollideWithNormalRing(ring);
					return;
            	}
		default:
					ring.GetComponent<PolygonCollider2D>().isTrigger = false;
					// this.processCollideWithNormalRing(ring);
					return;
		}
	}
}
