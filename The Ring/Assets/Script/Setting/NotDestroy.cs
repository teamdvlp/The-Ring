using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroy : MonoBehaviour {
	private static bool spawn;

	void Start () {
		if (spawn) {
			Destroy (gameObject);
		} else {
			DontDestroyOnLoad (this.gameObject);	
			spawn = true;
		}
	}

}
