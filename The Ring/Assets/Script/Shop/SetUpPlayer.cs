using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpPlayer : MonoBehaviour {

	public SpriteRenderer spriteRenderer;

    void Start() {
        if (User.sprite != null)
        {

            Debug.Log("HELLOW");
            spriteRenderer.sprite = User.sprite;

        } else
        {
            Debug.Log("SHOW ME SOMETHING YOU BABE");
        }
    }
}
