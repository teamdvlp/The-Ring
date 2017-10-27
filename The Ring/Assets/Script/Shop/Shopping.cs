using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public double total_coins;


	void Start () { 
		total_coins = SqliteUserManager.getCoin();
		Debug.Log ("ABC");
		CreateShopping ();
	
	}

	void CreateShopping () {
		list_Character = new List<Character> ();

		Character character1 = new Character (list_CharacterSprite[0],100,1);
		Character character2 = new Character (list_CharacterSprite[1],800,2);
		Character character3 = new Character (list_CharacterSprite[2],3000,3);
		Character character4 = new Character (list_CharacterSprite[3],7000,4);
		Character character5 = new Character (list_CharacterSprite[4],15000,5);

		list_Character.Add (character1);
		list_Character.Add (character2);
		list_Character.Add (character3);
		list_Character.Add (character4);
		list_Character.Add (character5);
		Debug.Log (list_Character.Count);

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


	// Thể hiện thông tin lên màn hình
	private void ShowInfo (int choosenPosition) {
		Character character = list_Character [choosenPosition];

		if (character.isBought) {
			Debug.Log ("ĐÃ MUA");
			choosenCharacterImage.sprite = character.GetSprite ();
			ProcessControllerState (false, 100);
		} else { 
			Debug.Log ("CHANGE SPRITE");
			choosenCharacterImage.sprite = character.GetSprite ();
			Debug.Log (character.GetSprite ());
			costText.text = character.GetCost () + " Rings";
			ProcessControllerState (true, 255);
		}
	}


	// Xử lý nhân vật thể hiện trong shop sau khi được mua
	private void Process_Bought_Character_InShop_AfterBuy (int choosenPosition) {
		list_Character [choosenPosition].SetIsBought (true);
	}


	private void ProcessControllerState (bool state, float alpha) {
		OwnedImage.enabled = !state;
		btn_Buy.enabled = state;
		costText.enabled = state;
		choosenCharacterImage.color = new Color(225f,225f,225f,alpha);
	}


	public void Buy () {
		if (total_coins > list_Character[choosenPosition].GetCost()) {
			User.SetUserSprite(list_Character[choosenPosition].GetSprite());
			total_coins -= list_Character [choosenPosition].GetCost();
			Process_Bought_Character_InShop_AfterBuy (choosenPosition);
			ShowInfo (choosenPosition);
		} else { 
			Debug.Log ("You have not enough money");
			Debug.Log (total_coins + " And " + list_Cost[choosenPosition]  );
		}
	}
}
