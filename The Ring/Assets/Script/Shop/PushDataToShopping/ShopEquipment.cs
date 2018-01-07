using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEquipment : MonoBehaviour {
    private Equipment equipmentInfo;
    public Image imageOfEquipment;
    public Text text_Price; 
    private GameObject EQUIPMENT_MODEL;
    private Sprite spriteOfEquipment;


    void Start ()
    {
        if (equipmentInfo != null)
        {
            EQUIPMENT_MODEL = Resources.Load(equipmentInfo.path) as GameObject;
            spriteOfEquipment = EQUIPMENT_MODEL.GetComponent<SpriteRenderer>().sprite;
            imageOfEquipment.sprite = spriteOfEquipment;
            text_Price.text = "<b>" + equipmentInfo.price + "</b>";
        } else
        {
            Debug.Log("Null equipmentInfo at ShopEquipment.cs");
        }   
    }

    public void SetEquipmentInfo(Equipment equipmentInfo)
    {
        this.equipmentInfo = equipmentInfo;
    }

    public Equipment GetEquipmentInfo()
    {
        return this.equipmentInfo;
    }

    public Sprite GetSprite ()
    {
        return this.spriteOfEquipment;
    }
	
}
