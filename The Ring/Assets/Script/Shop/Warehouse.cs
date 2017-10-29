using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse {
	public static Warehouse mInstance;
	private List<Character> characters = new List<Character>();
	private Warehouse (List<Sprite> CharacterSprites) {
		AddCharacter(CharacterSprites);
	}
	void AddCharacter (List<Sprite> CharacterSprites)
	{
		Character character1 = new Character (CharacterSprites[0],100,1,2314);
		Character character2 = new Character (CharacterSprites[1],800,2,3214);
		Character character3 = new Character (CharacterSprites[2],3000,3,5234);
		Character character4 = new Character (CharacterSprites[3],7000,4,5524);
		Character character5 = new Character (CharacterSprites[4],15000,5,9182);
		characters.Add(character1);
		characters.Add(character2);
		characters.Add(character3);
		characters.Add(character4);
		characters.Add(character5);
	}
	public static void newInstance (List<Sprite> listSprite) {
		if (Warehouse.mInstance == null) {
			Warehouse.mInstance = new Warehouse(listSprite);
		}
	}

	public static Warehouse getInstance () {
			return Warehouse.mInstance;
	}

	public List<Character> getAllCharacter () {
		return this.characters;
	}
}
