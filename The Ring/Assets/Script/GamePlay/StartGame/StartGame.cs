using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour {

    public GameObject player;
    // Player Properties
        SpriteRenderer playerSpriteRenderer;
    //

    private GameObject characterPrefabs;

    public AudioSource openingDoorSound, unlockDoorSound;

    public GameObject settingButton, shoppingButton, propertiesButton;

    public GameObject nameGame;

    public Animator leftPreventer, rightPreventer;

    public MonsterMovement monsterMovement;

    private float speed;

    private static bool hasGottenData;

    UserDataManager userDataManager;

    ShopDataManager shopDataManager;


    private void Start()
    {
        GetData_USER_and_SHOP_FromDB();

        // Khi mở comment hàm ResetUserData() để TEST, vào hàm GetData_USER_and_SHOP_FromDB() bên dưới comment lại đoạn user.getUser, dòng 82
        // *****Có thể bug****
        //ResetUserData();
        SetPlayer_FEATURE();
        Debug.Log("SỐ LƯỢNG NHÂN VẬT SỠ HỮU : " + User.getInstance().Characters.Count);
    }


    public void Starts ()
    {
        openingDoorSound = GetComponent<AudioSource>();
        settingButton.SetActive(false);
        shoppingButton.SetActive(false);
        nameGame.SetActive(false);
        propertiesButton.SetActive(false);
        leftPreventer.enabled = true;
        rightPreventer.enabled = true;
        unlockDoorSound.Play();
    }


    public void ReleaseMonster ()
    {
        monsterMovement.enabled = true;
    }

    public void PlayOpeningDoorSound ()
    {
        openingDoorSound.Play();
    }

    public void GetData_USER_and_SHOP_FromDB ()
    {
        if (!hasGottenData)
        {
            // Shop
            shopDataManager = new ShopDataManager();
            shopDataManager.getShop();

            // User
            userDataManager = new UserDataManager();
            // Comment cái này lại khi test
            userDataManager.getUser();

            hasGottenData = true;
        }
    }



    // Dùng để Reset lại toàn bộ dữ liệu của User về default trong quá trình Test
    public void ResetUserData()
    {
        User.getInstance().Characters = new List<Character>();
        User.getInstance().Characters.Add(Shop.getInstance().Characters[0]);
        User.getInstance().setCurrentChacracter(Shop.getInstance().Characters[0]);
    }

    // Set các thuộc tính của nhân vật
    private void SetPlayer_FEATURE ()
    {
        characterPrefabs = Resources.Load(User.getInstance().CurrentCharacter.path) as GameObject;
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerSpriteRenderer.sprite = characterPrefabs.GetComponent<SpriteRenderer>().sprite;
    }




}
