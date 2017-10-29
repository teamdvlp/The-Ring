using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separate : MonoBehaviour {
	Rigidbody2D rigid;
	private bool isAttacked = false;
	private bool isRotated = false;

	void Start () { 
		rigid = transform.parent.GetComponent<Rigidbody2D> ();
	}

	void Update () { 
		if (isAttacked) {
			gameObject.transform.parent.GetComponent<Rotate> ().enabled = false;
			if (!isRotated) {
				rigid.angularVelocity = -150;
				isRotated = true;
			} else if (Mathf.Abs(gameObject.transform.parent.transform.rotation.z) < 0.01){
				rigid.angularVelocity = 0;
				Animator[] animators = transform.parent.GetComponentsInChildren<Animator> ();
				foreach (Animator animator in animators) { 
					animator.SetBool ("getSkill", true);
				}
				isAttacked = false;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) { 
		if (col.gameObject.tag.Equals ("Skill")) {
			Debug.Log ("Attack");
			isAttacked = true;
		}
	}
}
