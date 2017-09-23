
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject GameOverBoard;

	// Use this for initialization
	void Start () {
        GameOverBoard.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowGameOverBoard ()
    {
        GameOverBoard.SetActive(true);
    }

    public void HideGameOverBoard ()
    {
        GameOverBoard.SetActive(false);
    }
}
