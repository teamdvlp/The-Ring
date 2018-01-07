using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class Shopping : MonoBehaviour {
    // Cái này là dùng để kéo thả vào
    public GameObject buyBoard;
    // cái này dùng để lưu cái trên lại, xài cho các sự kiện mua đồ, click vào mua thì hiện cái bảng lên 
    public static GameObject BuyBoard;

	public List<Character> list_Character;
	public List<Equipment> list_Equipment;

    // Check xem đây là Scene nào, Scene của Character hay là Equipment Scene (Nhằm để tiết kiệm file Script)
	public bool isCharacterShopping_AndNot_EquipmentShopping;

    // Tấm Panel chứa GridView, khi add View Child vào Panel thì GridView tự động sắp xếp
	public Transform panel_Parent;

    // Đã lấy dữ liệu chưa, nếu đã lấy rồi thì không lấy nữa
	private static bool hasGottenData;
	ShopDataManager shopDataManager;

	// Danh sách các sản phẩm của shop (nhân vật, trang bị) để add và đẩy dữ liệu lên shopping
	GameObject [] list_OfShop;

	// Truyền Prefab của mỗi ô nhân vật hoặc ô trang bị trong cửa hàng
	public GameObject window_ShoppingPrefab;




	void Start () {
        
        BuyBoard = buyBoard;
        GetDataFromDatabase();
		PushDataToShop (isCharacterShopping_AndNot_EquipmentShopping);
	}


	private void GetDataFromDatabase () {

        shopDataManager = new ShopDataManager();
        if (!hasGottenData)
        {
            shopDataManager = new ShopDataManager ();
		    shopDataManager.getShop ();
            hasGottenData = true;
        }

    }


    private void PushDataToShop (bool is_ShopCharacter_And_Not_ShopEquipment) {
        list_Equipment = new List<Equipment>();
        list_Character = new List<Character>();

            // Đang ở Scene: Shop Character
        if (is_ShopCharacter_And_Not_ShopEquipment ) {

            if (Shop.getInstance().Characters != null)
            {
                list_Character = Shop.getInstance().Characters;
                // Bắt Instantiate, rồi đẩy vào GridView thông qua việc setParent
                Set_Instance_For_Each_Character_Window(list_Character.Count);
            }
            else
            {
                Debug.Log("Null Characters of Shop.getInstance(), at Shopping.cs");
            }

            // Else tức là không phải ở Shop Character mà là đang ở Scene: Shop Equipment
        } else {

            if (Shop.getInstance().Equipments != null)
            {
                list_Equipment = Shop.getInstance().Equipments;
                // Bắt Instantiate, rồi đẩy vào GridView thông qua việc setParent
                Set_Instance_For_Each_Equip_Window(list_Equipment.Count);
            }
            else
            {
                Debug.Log("Null Equipments of Shop.getInstance(), at Shopping.cs");
            }
        }
	}

    private void Set_Instance_For_Each_Character_Window (int count_Of_Window)
    {
        for (int i = 0; i <= count_Of_Window - 1; i++)
        {
                                                                  // Parent GridView
            GameObject character = Instantiate(window_ShoppingPrefab, panel_Parent);
            character.GetComponent<ShopCharacter>().SetCharacterInfo(list_Character[i]);
        }
    }

    private void Set_Instance_For_Each_Equip_Window(int count_Of_Window)
    {
        for (int i = 0; i <= count_Of_Window - 1; i++)
        {
                                                                  // Parent GridView
            GameObject equipment = Instantiate(window_ShoppingPrefab, panel_Parent);
            equipment.GetComponent<ShopEquipment>().SetEquipmentInfo(list_Equipment[i]);
        }
    }

    private bool checkIsBought (int id) {
		return SqliteUserManager.getCharacter().Exists(x => x == id);
	}

    //private void OnApplicationQuit()
    //{
    //    shopDataManager.save();
    //}
}   
