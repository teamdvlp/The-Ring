using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpedementHelper : MonoBehaviour {
	public int hp;
	void Start () {
		
	}
	
	void Update () {
		
	}

	public void playAnimShaking (bool isShaking) {
		if (this.transform.name.Equals("Wood1") || this.transform.name.Equals("Wood2")) {
			GameObject woodPartner = null;
			if (this.transform.name.Equals("Wood1")) {
				woodPartner = GameObject.Find("Wood2");
			} else {
				woodPartner = GameObject.Find("Wood1");
			}
			this.GetComponent<Animator>().SetBool("Shaking", isShaking);
			woodPartner.GetComponent<Animator>().SetBool("Shaking", isShaking);
		}
		else {
			this.GetComponent<Animator>().SetBool("Shaking", isShaking);
		}
	}
}
