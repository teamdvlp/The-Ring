using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class showFps : MonoBehaviour {
	// Use this for initialization
	public Text txtFps;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		txtFps.text = (1.0f/Time.deltaTime) + "";
	}
}
