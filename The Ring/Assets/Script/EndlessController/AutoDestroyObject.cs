using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyObject : MonoBehaviour {
	public float timeToDestroy;

	void Start()
	{
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 18) {
			StartCoroutine(DestroyAfterSec());
		}
	}

	private IEnumerator DestroyAfterSec () {
		yield return new WaitForSeconds(timeToDestroy);
		Destroy(this.gameObject);
	}
}
