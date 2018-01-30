using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour {
    UserDataManager userDataManager;
    ShopDataManager shopDataManager;
    static bool isQuit;
    static int timeQuit;
	
    void Start ()
    {
        userDataManager = new UserDataManager();
        shopDataManager = new ShopDataManager();
    }

    private void OnApplicationQuit()
    {
        if (!isQuit)
        {
            userDataManager.saveUser();
            shopDataManager.save();
        }
    }
}
