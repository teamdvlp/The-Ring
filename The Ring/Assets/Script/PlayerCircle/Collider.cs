using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

	void Start () {
		
    }
	
	void Update () {
    
    }

	void OnCollisionEnter2D (Collision2D col) {
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
				return;
			}
		case 1:
			{
				this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
				return;
			}
		case 2:
			{
				this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
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
		this.gameObject.GetComponent<CircleCollider2D> ().isTrigger = false;
	}
}
