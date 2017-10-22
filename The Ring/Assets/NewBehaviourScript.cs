using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	void Start () {
		GetComponent<OnGameOver>().OnOverGame+=OverGame;
	}
	
	void Update () {
		
	}

	public void OverGame () {
	}
}
