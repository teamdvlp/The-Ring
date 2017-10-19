using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NatureSkill : MonoBehaviour {

	public Image usingSkillButton;
	public Sprite fireSprite, waterSprite, grassSprite, groundSprite, metalSprite;
	public GameObject fireSkill, waterSkill, grassSkill, groundSkill, metalSkill;
	public GameObject fireLight, waterLight, grassLight, groundLight, metalLight;
	GameObject currentLight;
	GameObject currentSkill;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void BuffSkill (int nature) {
		switch (nature) { 
		case 1:
			{
				Buff (metalLight, metalSkill, metalSprite);
				break;	
			}
		case 2:
			{
				Buff (grassLight, grassSkill, grassSprite);
				break;	
			}
		case 3:
			{
				Buff (waterLight, waterSkill, waterSprite);
				break;
			}
		case 4:
			{
				Buff (fireLight, fireSkill, fireSprite);
				break;
			}
		case 5:
			{
				Buff (groundLight, groundSkill, groundSprite);
				break;
			}
		}
	}

	private void Buff (GameObject skillLight, GameObject skill, Sprite sprite) { 
		currentLight =  Instantiate (skillLight,transform.position,transform.rotation,transform);
		currentSkill = skill;
		usingSkillButton.enabled = true;
		usingSkillButton.sprite = sprite;
		
	}

	public void UseSkill () {
		if (currentLight != null) { 
			Destroy (currentLight);
			currentLight = null;
		}
		if (currentSkill != null) {
			Instantiate (currentSkill, transform.position, transform.rotation);
			usingSkillButton.enabled = false;
			currentSkill = null;
		}
}
}
