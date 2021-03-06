﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpeCollider : MonoBehaviour {
	private ImpedementHelper mInfo;
	public GameObject Target;


	void Start () {
		mInfo = this.GetComponent<ImpedementHelper>();
	}


	void OnTriggerEnter2D(Collider2D col)
	{
        // 13 = Equipment
		if (col.gameObject.layer == 13) {
			mInfo.hp -= col.gameObject.GetComponent<EquipmentInfo>().damage;
			GetComponent<ImpedementHelper>().playAnimShaking(true);
			DeadProcess();
		}
	}


	void OnTriggerExit2D(Collider2D col)
	{
        // Rung khi đụng phải vũ khí
		GetComponent<ImpedementHelper>().playAnimShaking(false);
	}

    // Xử lí phá hủy chướng ngại vật
	private void DeadProcess () {
		if (mInfo.hp <= 0) {
			if (Target == null) {
				Destroy(this.gameObject);
			} else {
				Destroy(Target);
			}
		}
	}
	
}