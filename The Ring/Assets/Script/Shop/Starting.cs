using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starting : MonoBehaviour {
	public static List<Character> list_AllCharacter;

	public Image imageChoosenCharacter;
	public Sprite startingSprite;
	public static bool hadSetSpriteDefault = false;
	public static List<Character> list_OwnedCharacter;
	public static List<Character> ListAllCharacter;
	public static List<int> ListOfCharacterKey;
	public List<Sprite> list_CharacterSprite;
	public Character choosenCharacter;
	public static int choosenPosition;


	void Start () {
		
		CreateListOfAllCharacter ();
		SetUpProperties ();
		SetStartingState ();
	}



	void CreateListOfAllCharacter () {
		// ListOfCharacterKey = new List<int> ();
		// ListOfCharacterKey.Add (2);
		// ListOfCharacterKey.Add (4);
		// ListOfCharacterKey.Add (0);
		// ListAllCharacter = new List<Character> ();

		// Character character1 = new Character (list_CharacterSprite[0],100,1,2314);
		// Character character2 = new Character (list_CharacterSprite[1],800,2,3214);
		// Character character3 = new Character (list_CharacterSprite[2],3000,3,5234);
		// Character character4 = new Character (list_CharacterSprite[3],7000,4,5524);

		// ListAllCharacter.Add (character1);
		// ListAllCharacter.Add (character2);
		// ListAllCharacter.Add (character3);
		// ListAllCharacter.Add (character4);
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




	private void SetUpProperties () { 
		if (!hadSetSpriteDefault) {
			list_OwnedCharacter = new List<Character> ();
			foreach (int key in ListOfCharacterKey) {
				if (key < ListAllCharacter.Count - 1) {
					list_OwnedCharacter.Add (ListAllCharacter [key]);
				}
			}
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
