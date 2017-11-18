using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpeCollider : MonoBehaviour {
	private ImpedementInfo mInfo;
	public GameObject DestroyTarget;
	void Start () {
		mInfo = this.GetComponent<ImpedementInfo>();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.layer == 13) {
			mInfo.hp -= col.gameObject.GetComponent<EquipmentInfo>().damage;
			DeadProcess();
		}
	}

	private void DeadProcess () {
		if (mInfo.hp <= 0) {
			if (DestroyTarget == null) {
				Destroy(this.gameObject);
			} else {
				Destroy(DestroyTarget);
			}
		}
	}
	
}
