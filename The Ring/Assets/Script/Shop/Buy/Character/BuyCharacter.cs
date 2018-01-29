using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// Xử lí mua nhân vật, nhân vật được truyền vào đây để xử lí
public class BuyCharacter : MonoBehaviour{
    public Image focusCharacterImage;
    public static ShopCharacter choosen_ShopCharacter;
    Character character;
    public ScrollRect scrollRect;

    public void Buy()
    {
        character = choosen_ShopCharacter.GetCharacterInfo();
        if (character.price < User.getInstance().Coin)
        {
            User.getInstance().Characters.Add(character);
            User.getInstance().setCurrentChacracter(character);
            User.getInstance().Coin -= character.price;
            character.isBought = true;
            character.isChoosen = true;

            Shopping.BuyBoard.SetActive(false);

            // Xóa đi bảng giá, để cho biết là đã mua
            Destroy(choosen_ShopCharacter.priceBoard);
            
            // Hủy cái chọn để mua nhân vật, bật cái chọn để chọn nhân vật
            Destroy(choosen_ShopCharacter.clickTobuyCharacter);

            choosen_ShopCharacter.clickChooseCharacter.enabled = true;
            // Bật cái cửa sổ vừa mua, tắt cái đã được chọn trước đó, cái previous được truyền vào vừa load scene (Check trong ShopCharacter.cs)
            choosen_ShopCharacter.chooseWindow.SetActive(true);

            ChooseCharacterManager.TurnOff_PeviousChoosenCharacter_Window();
        } else
        {
            Debug.Log("YOU HAVE NOT ENOUGH MONEYS");
            Shopping.BuyBoard.SetActive(false);
        }
    }

    // Character is pass by this function
    public static void SetChoosenCharacter (ShopCharacter character)
    {   
        BuyCharacter.choosen_ShopCharacter = character;
    }

    void OnEnable ()
    {
        focusCharacterImage.sprite = choosen_ShopCharacter.GetSprite();
        scrollRect.enabled = false;
    }

    private void OnDisable()
    {
        scrollRect.enabled = true;
    }
}
