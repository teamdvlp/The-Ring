using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Starting : MonoBehaviour {
	public Image image;
	public Sprite startingSprite;
	public static bool hadSetSpriteDefault = false;
	public static List<Character> list_OwnedCharacter;

	void Start () {
		if (!hadSetSpriteDefault) {
			if (startingSprite != null) { 
				User.SetUserSprite (startingSprite);
			}
			hadSetSpriteDefault = true;
		} 

		if (User.sprite != null) {
			image.sprite = User.sprite;
		}
	}

	private void SetUpProperties () { 
		
	}


	public void PreviousCharacter () { 
			
	}

	public void NextCharacter () { 
	
	}
}
