using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Thêm file này vào đâu thì khi click vào đó sẽ nhảy sự kiện mua đồ
public class ClickToBuyEquipment : MonoBehaviour, IPointerDownHandler,  IPointerUpHandler
{

    // Truyền cái ShopCharacter của CharacterWindow (Node cha) vào
    public ShopEquipment shopEquipment;


    // Khi nhấn thì bắt đầu set cái con Choosen Character cho cái bảng
    // Đồng thời cho cái bảng hiện lên
    public void OnPointerDown (PointerEventData ped)
    {

    }

    public void OnPointerUp(PointerEventData ped)
    {
        if (ped.delta.y == 0 && ped.delta.x == 0)
        {
            BuyEquipment.SetChoosenEquipment(shopEquipment);
            Shopping.BuyBoard.SetActive(true);
        } 
    }

}
