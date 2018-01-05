using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopCharacter : MonoBehaviour {
	public Image imageCharacter;
	public Text textPriceCharacter;
	Character characterInfo;
    // prefabs of Character
    private GameObject CHARACTER_MODEL;
    private Sprite spriteOfCharacter;

	void Start () {

        if (characterInfo != null)
        {
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


}
