using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MultiResolution : MonoBehaviour {
    public SpriteRenderer BiggestSprite;
    public Canvas mCanvas;
	void Start () {
	        Camera.main.orthographicSize = (BiggestSprite.bounds.size.x/Camera.main.aspect)/2f;
	}
}
