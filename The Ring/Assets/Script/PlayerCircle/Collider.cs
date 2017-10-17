using System;
using UnityEngine;
public class Collider : MonoBehaviour {
	public GameObject collideEffect;
	public GameObject ringProtect;
	private CircleCollider2D mCircleCollider;
	private Nature mNature;
	public bool checkNature;
	private bool isBornNature;

	void Start () {
		checkNature = false;
		isBornNature = false;
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
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 14) {
			checkNature = true;
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
			if (isBornNature) {
			Debug.Log("Đổi hệ trong");
			isBornNature = false;
			}
		} else {
			if (isBornNature) {
			Debug.Log("Đổi hệ ngoài");
			isBornNature = false;
			}
		}
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
					isBornNature = true;
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
