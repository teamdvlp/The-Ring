using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapToStart : MonoBehaviour, IPointerDownHandler
{
    public StartGame startGameManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartGame();
        GetComponent<TapToStart>().enabled = false;
    }


    void StartGame()
    {
        startGameManager.Starts();
    }


}
