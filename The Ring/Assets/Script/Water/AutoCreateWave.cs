using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCreateWave : MonoBehaviour {
	public float xMin;
	public float xMax;
	public float magnitude;
	public float time;
	void Start () {
		StartCoroutine(autoWave());
	}
	
	private IEnumerator autoWave () {
		yield return new WaitForSeconds(time);
		transform.parent.GetComponent<Water>().Splash(Random.Range(xMin,xMax), magnitude);
		StartCoroutine(autoWave());
	}
}
