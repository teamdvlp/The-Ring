using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HideBuyBoard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public GameObject BuyBoard;


    public void OnPointerDown (PointerEventData ped)
    {

    }

    public void OnPointerUp(PointerEventData ped)
    {
        BuyBoard.SetActive(false);
    }
}
