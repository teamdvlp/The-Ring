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

	void Start () {
		isPlayerInside = false;
		checkNature = false;
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
		if (col.gameObject.layer == 14) {
			checkNature = true;
		} else if (col.gameObject.layer == 9) {
		ring = col.gameObject	;
		natureIndex1 = mNature.nature;
		natureIndex2 = ring.GetComponent<Nature> ().nature;
		compareResult = compareNat.compareNature (natureIndex1, natureIndex2);
		switch (compareResult) {
    	case 1:
            	{
            		ring.GetComponent<PolygonCollider2D>().isTrigger = true;
					isBornNature = true;
                    this.processCollideWithNormalRing(ring);
					return;
            	}
		default: {
				isBornNature = true;
				this.processCollideWithNormalRing(ring);
				return;
		}
		}	
		}
	}
	void OnTriggerStay2D(Collider2D col)
		{
			if (col.gameObject.layer == 14) {
			if (checkNature) {
			processCollider(col.gameObject);
			checkNature = false;
				}
		double distance = Math.Sqrt((this.transform.position.x - col.transform.position.x) * (this.transform.position.x - col.transform.position.x)
                                    +
                                   (this.transform.position.y - col.transform.position.y) * (this.transform.position.y - col.transform.position.y));
        if (Math.Abs(distance) < Math.Abs(4.5 - Math.Abs(this.GetComponent<CircleCollider2D>().radius))) {
			if (isBornNature && !isPlayerInside) {
			Debug.Log("Đổi hệ trong");
			isBornNature = false;
			}
			isPlayerInside = true;
		} else if (Math.Abs(distance) > Math.Abs(6.5 - Math.Abs(this.GetComponent<CircleCollider2D>().radius))) {
			if (isBornNature && isPlayerInside) {
			Debug.Log("Đổi hệ ngoài");
			isBornNature = false;
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
    	case 1:
            	{
            		ring.GetComponent<PolygonCollider2D>().isTrigger = true;
                    this.processCollideWithNormalRing(ring);
					return;
            	}
		default:
				ring.GetComponent<PolygonCollider2D>().isTrigger = true;
				this.processCollideWithNormalRing(ring);
				return;
		}
	}
}
