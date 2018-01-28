using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ChooseCharacter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ShopCharacter shopCharacter;
    public Transform position_To_Put_ChoosenWindow;


    public void OnPointerDown(PointerEventData ped)
    {

    }

    public void OnPointerUp(PointerEventData ped)
    {
        User.getInstance().setCurrentChacracter(shopCharacter.GetCharacterInfo());
        Debug.Log("YOU CHOOSE ME GUYS");
    }
}