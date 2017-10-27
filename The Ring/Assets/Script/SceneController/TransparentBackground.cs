using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentBackground : MonoBehaviour {

    public float timeDelayAppearTransparentBackground;

	// Use this for initialization
	void Start () {

	}

	void Awake () {
		Application.targetFrameRate = 85;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void FadeIn ()
    {
		Invoke("Fade", timeDelayAppearTransparentBackground);
    }

    void Fade ()
    {
        GetComponent<Animator>().SetBool("isGameOver", true);
    }


}
