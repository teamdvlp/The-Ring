using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverBoard;
	public GameObject ContinueBoard;
    public float delayTimeAppearOverBoard;
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
        var smallMonsters = GameObject.FindGameObjectsWithTag("SmallMonster");
        smallMonsters[0].SetActive(false);
		smallMonsters[1].SetActive(false);
		transparentBackground.SetActive (true);
		transparentBackground.GetComponent<TransparentBackground>().FadeIn();
		Invoke("ActiveOverBoard", delayTimeAppearOverBoard);
		ContinueBoard.SetActive (false);
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
