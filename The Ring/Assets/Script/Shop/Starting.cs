﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starting : MonoBehaviour {
	public Image imageChoosenCharacter;
	public Sprite startingSprite;
	public static bool hadSetSpriteDefault = false;
	public static List<Character> list_OwnedCharacter;
	public static int choosenPosition;

	void Start () {
		CreateListOfAllCharacter ();
		SetStartingState ();
	}

	void CreateListOfAllCharacter () {
		list_OwnedCharacter = Warehouse.getInstance().getAllCharacter()
		.FindAll(x => SqliteUserManager.getCharacter()
		.Exists(id => id == x.getId()));
	}

	private void SetStartingState () { 
		if (!hadSetSpriteDefault) {
			if (startingSprite != null) { 
				User.SetUserSprite (startingSprite);
			}
			hadSetSpriteDefault = true;
		} 

		if (User.sprite != null) {
			imageChoosenCharacter.sprite = User.sprite;
		}
	}

	private void ShowInfoOfChoosenCharacter (int position) {
		imageChoosenCharacter.sprite = list_OwnedCharacter [position].GetSprite ();
		User.sprite = list_OwnedCharacter [position].GetSprite ();
	}

	public void PreviousCharacter () { 
		if (choosenPosition <= 0) {
			choosenPosition = list_OwnedCharacter.Count - 1;
			ShowInfoOfChoosenCharacter (choosenPosition);
		} else {
			choosenPosition--;
			ShowInfoOfChoosenCharacter (choosenPosition);
		}
	}

	public void NextCharacter () { 
		if (choosenPosition >= list_OwnedCharacter.Count - 1) {
			choosenPosition = 0;
			ShowInfoOfChoosenCharacter (choosenPosition);
		} else {
			choosenPosition++;
			ShowInfoOfChoosenCharacter (choosenPosition);
		}
	}
}