using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


// Các cửa sổ Character đều chứa cái này, dùng để quản lý trạng thái của từng cửa số,
// mua,
// chưa mua,
// push hình ảnh lên shop này kia

public class ShopCharacter : MonoBehaviour
{
    public GameObject priceBoard;

    public Image imageCharacter;

    public Text textPriceCharacter;
    
    // prefabs of Character
    private GameObject CHARACTER_MODEL;

    private Sprite spriteOfCharacter;

    private Character characterInfo;

    public ClickToBuyCharacter clickTobuyCharacter;

    public ClickToChooseCharacter clickChooseCharacter;

    public GameObject chooseWindow;

    void Start () {

        if (characterInfo != null)
        {
            
            if (characterInfo.isBought)
            {
                priceBoard.SetActive(false);
                Destroy(imageCharacter.gameObject.GetComponent<ClickToBuyCharacter>());
                imageCharacter.gameObject.GetComponent<ClickToChooseCharacter>().enabled = true;
            }

            if (characterInfo.isChoosen)
            {
                chooseWindow.SetActive(true);
                ChooseCharacterManager.previousChoosenCharacter = this;
            }

            CHARACTER_MODEL = Resources.Load(characterInfo.path) as GameObject;
            spriteOfCharacter = CHARACTER_MODEL.GetComponent<SpriteRenderer>().sprite;
            imageCharacter.sprite = spriteOfCharacter;
            textPriceCharacter.text = "<b>" + characterInfo.price + "</b>";
        }
    }

    public void SetCharacterInfo(Character characterInfo)
    {
        this.characterInfo = characterInfo;
    }

    public Character GetCharacterInfo ()
    {
        return this.characterInfo;
    }

    public GameObject getCHARACTER_MODEL ()
    {
        return this.CHARACTER_MODEL;
    }

    public Sprite GetSprite ()
    {
        return this.spriteOfCharacter;
    }
    
}
