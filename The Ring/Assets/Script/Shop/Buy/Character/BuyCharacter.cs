using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyCharacter : MonoBehaviour{
    public Image focusCharacterImage;
    public static ShopCharacter choosen_ShopCharacter;
    Character character;

    public void Buy()
    {
        character = choosen_ShopCharacter.GetCharacterInfo();
        if (character.price < User.getInstance().Coin)
        {
            User.getInstance().Characters.Add(character);
            User.getInstance().setCurrentChacracter(character);
            User.getInstance().Coin -= character.price;
        } else
        {
            Debug.Log("YOU HAVE NOT ENOUGH MONEYS");
            Shopping.BuyBoard.SetActive(false);
        }
    }

    public static void  SetChoosenCharacter (ShopCharacter character)
    {   
        BuyCharacter.choosen_ShopCharacter = character;
    }

    void OnEnable ()
    {
        focusCharacterImage.sprite = choosen_ShopCharacter.GetSprite();
    }

}
