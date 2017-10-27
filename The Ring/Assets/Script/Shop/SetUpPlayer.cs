using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpPlayer : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

	void Start () {
		if (User.sprite != null) 
		spriteRenderer.sprite = User.sprite;
	}
}
