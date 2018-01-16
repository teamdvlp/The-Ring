using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour{

    public AudioSource openingDoorSound, unlockDoorSound;
    public GameObject settingButton, shoppingButton, propertiesButton;
    public GameObject nameGame;
    public Animator leftPreventer, rightPreventer;
    public MonsterMovement monsterMovement;
    public float speed;
   
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

}
