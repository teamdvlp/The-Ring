using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

    public GameObject collideEffect;
    private bool pornNature;
	void Start () {
        pornNature = false;
    }
	
	void Update () {
    
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
                    this.pornNature = true;
				return;
			}
            case 1:
            	{
            		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
            		return;
            	}
        case 2:
            {
                Destroy(gameObject.GetComponent<ChangeNature>().playerCurrentNature);
                gameObject.GetComponent<Nature>().nature = 0;
                return;
			}
		case 3: 
			{
				this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
				return;
			}
		default:
			return;
		}
	}

    void OnCollisionExit2D (Collision2D col)
    {
    }

	void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.layer == 9)
        {
            Debug.Log("Exit");
            int currentNature = col.gameObject.GetComponent<Nature>().nature;
            if (pornNature)
            {
                if (currentNature >= 5)
                    currentNature = 0;
            }
            else
            {
                ++currentNature;
            }
			GetComponent<ChangeNature>().SetNature(currentNature);
		}
		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;

	}
}
