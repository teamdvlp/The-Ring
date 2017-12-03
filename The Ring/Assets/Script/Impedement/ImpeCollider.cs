using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpeCollider : MonoBehaviour {
	private ImpedementHelper mInfo;
	public GameObject Target;
	void Start () {
		mInfo = this.GetComponent<ImpedementHelper>();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == 13) {
			mInfo.hp -= col.gameObject.GetComponent<EquipmentInfo>().damage;
			GetComponent<ImpedementHelper>().playAnimShaking(true);
			DeadProcess();
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		GetComponent<ImpedementHelper>().playAnimShaking(false);
	}

	private void DeadProcess () {
		if (mInfo.hp <= 0) {
			if (Target == null) {
				Destroy(this.gameObject);
			} else {
				Destroy(Target);
			}
		}
	}
	 void OnCollisionEnter2D(Collision2D other)
	 {
		 Debug.Log("con cu");
	 }
}
