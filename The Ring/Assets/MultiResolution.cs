using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MultiResolution : MonoBehaviour {
    public SpriteRenderer BiggestSprite;
   	private float screenW;
	private float screenH;
	public float aspect;
	void Start () {
		screenH = Screen.height;
		screenW = Screen.width;
		aspect = screenH/screenW;
        processMultipleResolution ();
	}
	private void processMultipleResolution()
	{
        Camera.main.aspect = 1/aspect;
        Camera.main.orthographicSize = (BiggestSprite.bounds.size.x*aspect)/2f;
	}
}
