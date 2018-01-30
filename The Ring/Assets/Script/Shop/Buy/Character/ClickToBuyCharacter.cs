using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Thêm file này vào đâu thì khi click vào đó sẽ nhảy sự kiện mua đồ
public class ClickToBuyCharacter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    void Start ()
    {

    }

    // Truyền cái ShopCharacter của CharacterWindow (Node cha) vào
    public ShopCharacter shopCharacter;



    // Hàm này để đây để nó bắt đc sự kiện nhấn xuống sau đó mới bắt được sự kiện
    // Buông tay ra, nếu bỏ ra thì hàm Up sẽ không chạy vì không có hàm Down
    public void OnPointerDown(PointerEventData ped) {/*...*/}



    // Khi rút tay ra thì bắt đầu set cái con Choosen Character cho cái bảng
    // Đồng thời cho cái bảng hiện lên
    public void OnPointerUp(PointerEventData ped)
    {
        if (Mathf.Abs(ped.delta.y) < 0.5f && Mathf.Abs(ped.delta.x) < 0.5f)
        {
            BuyCharacter.SetChoosenCharacter(shopCharacter);
            Shopping.BuyBoard.SetActive(true);
        }
    }

}
