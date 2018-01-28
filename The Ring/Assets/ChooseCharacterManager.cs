using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterManager : MonoBehaviour {
    public static ShopCharacter previousChoosenCharacter;

    public static void TurnOff_PeviousChoosenCharacter_Window ()
    {
        previousChoosenCharacter.chooseWindow.SetActive(false);
        previousChoosenCharacter.GetCharacterInfo().isChoosen = false;
    }
}
