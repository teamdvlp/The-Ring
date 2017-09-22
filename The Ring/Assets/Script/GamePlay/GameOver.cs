<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
=======
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
>>>>>>> efd8f170e65cad631cea448820fd7e05d72d02a3
