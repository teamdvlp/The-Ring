using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotion : MonoBehaviour {
	public GameObject monster;
	Animator anim;
	public float DurationCryAnim, DurationScreamAnim;
	float timePlayCryAnim;
	public float distance;
	bool isSafe;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		/* Is not safe */
		if (gameObject.transform.position.y - monster.transform.position.y <= distance) {
			ProcessPlayCryAnim ();
		/* Is safe */
		} else {
			ProcessPlaySmileAnim ();
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.layer == 9) {
			ProcessPlayScreamAnim ();			
		}
	}

	#region ProcessAnim
	//Smile
	private void ProcessPlaySmileAnim () {
		anim.SetBool ("isSafe", true);
	}

	//Cry
	private void ProcessPlayCryAnim () {
		anim.SetBool ("isSafe", false);
	}

	//Scream
	private void ProcessPlayScreamAnim () {
		anim.Play ("scream");
		anim.SetBool ("isHurt",true);
	}
	#endregion

	public void setIsNotHurt () {
		anim.SetBool ("isHurt", false);
	}


}
