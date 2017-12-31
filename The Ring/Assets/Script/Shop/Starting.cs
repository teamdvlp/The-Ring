using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starting : MonoBehaviour {
	public SpriteRenderer imageChoosenCharacter;
	public Sprite startingSprite;
	public static bool hadSetSpriteDefault = false;
	public static List<Character> list_OwnedCharacter;
	public static int choosenPosition;
	public List<Sprite> CharacterSprites;
	void Start () {
		choosenPosition = 0;
		Warehouse.newInstance(CharacterSprites);
		CreateListOfAllCharacter ();
		SetStartingState ();
		ShowInfoOfChoosenCharacter(choosenPosition);
	}

	void CreateListOfAllCharacter () {
		// SqliteUserManager.ClearAllCharacter();
		// list_OwnedCharacter = Warehouse.getInstance().getAllCharacter()
		// .FindAll(x => SqliteUserManager.getCharacter()
		// .Exists(id => id == x.getId()));
	}

	private void SetStartingState () { 
		if (!hadSetSpriteDefault) {
			if (startingSprite != null) { 
				// User.SetUserSprite (startingSprite);
			}
			hadSetSpriteDefault = true;
		} 

		// if (User.sprite != null) {
		// 	imageChoosenCharacter.sprite = User.sprite;
		// }
	}

	private void ShowInfoOfChoosenCharacter (int position) {
		if (list_OwnedCharacter.Count >= 1) {
		// imageChoosenCharacter.sprite = list_OwnedCharacter [position].GetSprite ();
		// User.sprite = list_OwnedCharacter [position].GetSprite ();
		}
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