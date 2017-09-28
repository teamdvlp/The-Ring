using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverBoard;
    public float appearTime;
    public GameObject transparentBackground;

    // Use this for initialization
    void Start () {
        gameOverBoard.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OverGame()
    {
        transparentBackground.GetComponent<TransparentBackground>().FadeIn();
        Invoke("ActiveOverBoard", appearTime);
    }

    private void ActiveOverBoard ()
    {
        gameOverBoard.SetActive(true);
    }

    public void HideGameOverBoard ()
    {
        gameOverBoard.SetActive(false);
    }

   
}
