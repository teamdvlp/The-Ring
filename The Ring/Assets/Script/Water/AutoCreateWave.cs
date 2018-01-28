using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreateWave : MonoBehaviour {

	public float x1;
	public float x2;
	void Start () {
		StartCoroutine(autoWave());
	}
	
	void Update () {

	}

	private IEnumerator autoWave () {
		yield return new WaitForSeconds(0.2f);
		transform.parent.GetComponent<Water>().Splash(Random.Range(x1,x2), 0.025f);
		StartCoroutine(autoWave());
	}
}
