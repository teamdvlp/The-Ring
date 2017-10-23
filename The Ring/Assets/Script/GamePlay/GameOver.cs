using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverBoard;
	public GameObject ContinueBoard;
    public float delayTimeAppearOverBoard;
    public GameObject transparentBackground;

    // Đem từ Delegate và Event OnGameOver qua GameOver vì hàm OverGame nằm bên file GameOver.cs
    public delegate void OverGame();
    public event OverGame OnOverGame;




    void Start () {
        gameOverBoard.SetActive(false);
	}
	

    public void OverGames()
    {
        if (OnOverGame != null)
        {
            OnOverGame();
        }
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
