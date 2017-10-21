using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class YesOrNotOption : MonoBehaviour, IPointerDownHandler {
	public bool canRespawn;
	public GameOver gameOver;
	public OnGameOver onGameOver;

	public void OnPointerDown (PointerEventData eventData)
	{
		if (canRespawn) {
			Debug.Log ("YES");
			onGameOver.ProcessPlayerRespawn();
		} else {
			Debug.Log ("NO");
			gameOver.OverGame ();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
