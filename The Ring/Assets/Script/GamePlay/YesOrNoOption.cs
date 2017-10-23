using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class YesOrNoOption : MonoBehaviour, IPointerDownHandler {
	public bool canRespawn;
	public GameOver gameOver;
	public OnGameOver onGameOver;

	public void OnPointerDown (PointerEventData eventData)
	{
		if (canRespawn) {
			Debug.Log ("YES");
            onGameOver.Respawn();
        } else {
			Debug.Log ("NO");
			gameOver.OverGames();
		}
	}



}
