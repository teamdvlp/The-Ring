using System;
using UnityEngine;

public class Collider : MonoBehaviour, ColliderRingProtect.OnTriggerd {

	public GameObject collideEffect;
	public GameObject ringProtect;
    private bool isBornNature;
    private bool stopBorn;
	void Start () {
        isBornNature = false;
        stopBorn = false;
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

    void OnCollisionEnter2D (Collision2D col) {

	}

	void OnTriggerExit2D (Collider2D col) {
		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
	}

    private void processBornNature(GameObject col)
    {
        if (isBornNature) {
        isBornNature = false;
        int currentNature = col.GetComponent<Nature>().nature;
        currentNature = currentNature + 1;
        if (currentNature > 5)
        {
            currentNature = 1;
        }
        GetComponent<ChangeNature>().SetNature(currentNature);
    }
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
    // Override
    public void OnTriggeredExit(GameObject col)
    {
            isBornNature = true;
			processBornNature(col.transform.parent.gameObject);
    }
	// Override
	public void OnTriggeredStay(GameObject col)
    {
        double distance = Math.Sqrt((this.transform.position.x - col.transform.position.x) * (this.transform.position.x - col.transform.position.x)
                                    +
                                   (this.transform.position.y - col.transform.position.y) * (this.transform.position.y - col.transform.position.y));
        if (Math.Abs(distance) < Math.Abs(2.5 - Math.Abs(this.GetComponent<CircleCollider2D>().radius))) {
            processBornNature(col.transform.parent.gameObject);
        GameObject ring = col.gameObject.transform.parent.gameObject;
		int natureIndex1 = this.gameObject.GetComponent<Nature> ().nature;
		int natureIndex2 = ring.GetComponent<Nature> ().nature;
		CompareNature compareNat = new CompareNature (natureIndex1,natureIndex2);
		int compareResult = compareNat.compareNature ();
            if (compareResult == 0) {
        this.GetComponent<CircleCollider2D>().isTrigger = true;            
            }
        } 
 }

    public void OnTriggeredEnter(GameObject col)
    {
        if (col.gameObject.GetComponentInParent<Nature> () == null) {
			return;
		}
        GameObject ring = col.gameObject.transform.parent.gameObject;
		int natureIndex1 = this.gameObject.GetComponent<Nature> ().nature;
        Debug.Log("1: " +  natureIndex1);
		int natureIndex2 = ring.GetComponent<Nature> ().nature;
        Debug.Log("2: " +  natureIndex2);
		CompareNature compareNat = new CompareNature (natureIndex1,natureIndex2);
		int compareResult = compareNat.compareNature ();
        Debug.Log(compareResult);
		switch (compareResult) {
		case 0:
			{
                Debug.Log("truecc");
				    this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = true;
                    this.isBornNature = true;
                    this.processCollideWithAgainstRing(ring);
					return;
			}
            case 1:
            	{
            		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
                    this.processCollideWithNormalRing(ring);
                    isBornNature = false;
					return;
            	}
        case 2:
            {
                    Destroy(gameObject.GetComponent<ChangeNature>().playerCurrentNature);
                    gameObject.GetComponent<Nature>().nature = 0;
					this.processCollideWithNormalRing(ring);
					isBornNature = false;
					return;
			}
		case 3: 
			{
				this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
					this.processCollideWithNormalRing(ring);
					isBornNature = false;
					return;
			}
		default:
				isBornNature = false;
				return;
		}
    }
}
