using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyEquipment : MonoBehaviour{
    public Image focusEquipmentImage;
    public static ShopEquipment choosen_ShopEquipment;
    Equipment equipment;

    public void Buy()
    {
        equipment = choosen_ShopEquipment.GetEquipmentInfo();
        if (equipment.price < User.getInstance().Coin)
        {
            User.getInstance().Equipments.Add(equipment);
            User.getInstance().setCurrentEquipment(equipment);
            User.getInstance().Coin -= equipment.price;
        } else
        {
            Debug.Log("YOU HAVE NOT ENOUGH MONEYS");
            Shopping.BuyBoard.SetActive(false);
        }
    }

    public static void SetChoosenEquipment (ShopEquipment equipment)
    {   
        BuyEquipment.choosen_ShopEquipment = equipment;
    }

    void OnEnable()
    {
        focusEquipmentImage.sprite = BuyEquipment.choosen_ShopEquipment.GetSprite();
    }

}
