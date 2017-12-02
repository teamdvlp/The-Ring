﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Shopping : MonoBehaviour {
	public Image OwnedImage;
	public Button btn_Buy;
	public Image choosenCharacterImage;
	public Character choosenCharacter;
	public Text costText;
	public List<Sprite> list_CharacterSprite;
	public List<Character> list_Character;
	List <int> list_Cost;
	int choosenPosition = 0;

	void Start () { 
		CreateShopping ();
	}

	void CreateShopping () {
		list_Character = new List<Character> ();
		list_Character = Warehouse.getInstance().getAllCharacter();
	}
	
	// Nhân vật phía sau
	public void NextCharacter () {

		if (choosenPosition < list_Character.Count - 1) {
			choosenPosition++;
			ShowInfo (this.choosenPosition);

		} else {
			choosenPosition = 0;
			ShowInfo (this.choosenPosition);
		}
	}

	// Nhân vật phía trước
	public void PreviousCharacter () { 
		if (choosenPosition > 0) {
			choosenPosition--;
			ShowInfo (this.choosenPosition);

		} else if (choosenPosition <= 0) {
			choosenPosition = list_Character.Count - 1;
			ShowInfo (this.choosenPosition);
		}
	}

	private bool checkIsBought (int id) {
		return SqliteUserManager.getCharacter().Exists(x => x == id);
	}

	// Thể hiện thông tin lên màn hình
	private void ShowInfo (int choosenPosition) {
		Character character = list_Character [choosenPosition];
		if (checkIsBought(character.getId())) {
			choosenCharacterImage.sprite = character.GetSprite ();
			ProcessControllerState (false, 100);
		} else { 
			choosenCharacterImage.sprite = character.GetSprite ();
			Debug.Log (character.GetSprite ());
			costText.text = character.GetCost () + " Rings";
			ProcessControllerState (true, 255);
		}
	}

	private void Process_Bought_Character_InShop_AfterBuy (int choosenPosition) {
		SqliteUserManager.addCharacter(list_Character[choosenPosition].getId());
	}

	private void ProcessControllerState (bool state, float alpha) {
		OwnedImage.enabled = !state;
		btn_Buy.enabled = state;
		costText.enabled = state;
		choosenCharacterImage.color = new Color(225f,225f,225f,alpha);
	}

	public void Buy () {
		if (SqliteUserManager.getCoin() > list_Character[choosenPosition].GetCost()) {
			User.SetUserSprite(list_Character[choosenPosition].GetSprite());
			SqliteUserManager.AddCoin (-list_Character [choosenPosition].GetCost());
			Process_Bought_Character_InShop_AfterBuy (choosenPosition);
			ShowInfo (choosenPosition);
		} else { 
			Debug.Log ("You have not enough money");
			// Debug.Log (SqliteUserManager.getCoin() + " And " + list_Cost[choosenPosition]  );
		}
	}
}
