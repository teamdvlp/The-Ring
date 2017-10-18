using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiResolution : MonoBehaviour {

	public Vector3 position;
	public Vector3 size;
	float Width, Height;
	float ScreenRatio;
	float DPI;


	void Start () {
		DPI = Screen.dpi;
		Debug.Log (DPI);
	}
	
	void Update () {
		
	}
}
