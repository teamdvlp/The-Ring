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
	List <int> list_Cost;
	int choosenPosition = 0;
	public double total_coins;


	void Start () { 
		total_coins = SqliteUserManager.getCoin();
	}

	
	// Nhân vật phía sau
	public void NextCharacter () {

		if (choosenPosition < Starting.ListAllCharacter.Count - 1) {
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
			choosenPosition = Starting.ListAllCharacter.Count - 1;
			ShowInfo (this.choosenPosition);
		}
	}


	// Thể hiện thông tin lên màn hình
	private void ShowInfo (int choosenPosition) {
		Character character = Starting.ListAllCharacter [choosenPosition];

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
		Starting.ListAllCharacter [choosenPosition].SetIsBought (true);
	}


	private void ProcessControllerState (bool state, float alpha) {
		OwnedImage.enabled = !state;
		btn_Buy.enabled = state;
		costText.enabled = state;
		choosenCharacterImage.color = new Color(225f,225f,225f,alpha);
	}


	public void Buy () {
		if (total_coins > Starting.ListAllCharacter[choosenPosition].GetCost()) {
			
			User.SetUserSprite(Starting.ListAllCharacter[choosenPosition].GetSprite());
			total_coins -= Starting.ListAllCharacter [choosenPosition].GetCost();
			Starting.list_OwnedCharacter.Add(Starting.ListAllCharacter[choosenPosition]);
			Starting.choosenPosition = Starting.list_OwnedCharacter.Count - 1;
			Process_Bought_Character_InShop_AfterBuy (choosenPosition);
			ShowInfo (choosenPosition);
		} else { 
			Debug.Log ("You have not enough money");
			Debug.Log (total_coins + " And " + list_Cost[choosenPosition]  );
		}
	}
}
