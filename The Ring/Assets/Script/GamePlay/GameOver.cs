using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverBoard;
	public GameObject ContinueBoard;
    public float delayTimeAppearOverBoard;
    public GameObject transparentBackground;



    // Đem từ Delegate và Event OnGameOver từ OnGameOver qua GameOver vì hàm OverGame nằm trong file GameOver.cs
    public delegate void OverGame();
    public event OverGame OnOverGame;



    void Start () {
        gameOverBoard.SetActive(false);
	}
	
    // Xử lí khi Game Over hoàn toàn, không quyết định respawn
    public void Process_GameOver()
    {
        if (OnOverGame != null)
        {
            OnOverGame();
        }

        // Hiện cái background lên
		transparentBackground.SetActive (true);
        // Hiện ra dần 
        transparentBackground.GetComponent<TransparentBackground>().FadeIn();

        // Cho cái bảng Game Over hiện xuống
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
