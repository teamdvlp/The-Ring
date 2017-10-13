using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotion : MonoBehaviour {
	public GameObject monster;
	Animator anim;
	float timePlaySmileAnim;
	public float distance;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y - monster.transform.position.y < distance) {
			anim.Play ("cry");
		} else {
			timePlaySmileAnim -= Time.deltaTime;
			if (timePlaySmileAnim <= 0) {
				anim.Play ("smile");
				timePlaySmileAnim = 2f;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.layer == 9) {
			anim.Play ("scream");
		}
	}
}
