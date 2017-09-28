using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransparentBackground : MonoBehaviour {

    public float appearTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void FadeIn ()
    {
        Invoke("Fade", appearTime);
    }

    void Fade ()
    {
        GetComponent<Animator>().SetBool("isGameOver", true);
    }


}
