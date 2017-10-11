using System;
using UnityEngine;

public class Collider : MonoBehaviour, ColliderRingProtect.OnTriggerd {

	public GameObject collideEffect;
	public GameObject ringProtect;
    private bool isBornNature;
	void Start () {
        isBornNature = false;
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

        CollideEffect(col);

        if (col.gameObject.GetComponent<Nature> () == null) {
			return;
		}
		int natureIndex1 = this.gameObject.GetComponent<Nature> ().nature;
		int natureIndex2 = col.gameObject.GetComponent<Nature> ().nature;
		CompareNature compareNat = new CompareNature (natureIndex1,natureIndex2);
		int compareResult = compareNat.compareNature ();
		switch (compareResult) {
		case 0:
			{
				    this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = true;
                    this.isBornNature = true;
                    this.processCollideWithAgainstRing(col.gameObject);
					return;
			}
            case 1:
            	{
            		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
                    this.processCollideWithNormalRing(col.gameObject);
                    isBornNature = false;
					return;
            	}
        case 2:
            {
                    Destroy(gameObject.GetComponent<ChangeNature>().playerCurrentNature);
                    gameObject.GetComponent<Nature>().nature = 0;
					this.processCollideWithNormalRing(col.gameObject);
					isBornNature = false;
					return;
			}
		case 3: 
			{
				this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
					this.processCollideWithNormalRing(col.gameObject);
					isBornNature = false;
					return;
			}
		default:
				isBornNature = false;
				return;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
	}

    private void processBornNature(GameObject col)
    {
        if (isBornNature) {
        int currentNature = col.GetComponent<Nature>().nature;
        currentNature = currentNature + 1;
        if (currentNature > 5)
        {
            currentNature = 1;
        }
        GetComponent<ChangeNature>().SetNature(currentNature);
        isBornNature = false;
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
			processBornNature(col.transform.parent.gameObject);
    }
	// Override
	public void OnTriggeredStay(GameObject col)
    {
        double distance = Math.Sqrt((this.transform.position.x - col.transform.position.x) * (this.transform.position.x - col.transform.position.x)
                                    +
                                   (this.transform.position.y - col.transform.position.y) * (this.transform.position.y - col.transform.position.y)
                                   );
        if (Math.Abs(distance) < Math.Abs(col.gameObject.GetComponent<CircleCollider2D>().radius) - Math.Abs(this.GetComponent<CircleCollider2D>().radius)) {
            processBornNature(col.transform.parent.gameObject);
        }
 }

    public void OnTriggeredEnter(GameObject col)
    {
    }
}
