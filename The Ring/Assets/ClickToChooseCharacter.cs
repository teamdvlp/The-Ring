using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickToChooseCharacter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public ShopCharacter shopCharacter;


	void Start () {
		
	}

    public void OnPointerDown (PointerEventData ped)
    {

    }

    public void OnPointerUp (PointerEventData ped)
    {
        User.getInstance().setCurrentChacracter(shopCharacter.GetCharacterInfo());
        
        // Tắt cái chooseWindow của cái khung trước đó
        ChooseCharacterManager.TurnOff_PeviousChoosenCharacter_Window();

        // Bất cái chooseWindow của cái khung vừa được chọn
        shopCharacter.chooseWindow.SetActive(true);
        shopCharacter.GetCharacterInfo().isChoosen = true;

        ChooseCharacterManager.previousChoosenCharacter = this.shopCharacter;
    }
    	
}
