using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour{

    public GameObject player;
    public GameObject directionArrow;
    public GameObject settingButton, shoppingButton, exitButton;
    public GameObject nameGame;
    public Animator leftPreventer, rightPreventer;
    public MonsterMovement monsterMovement;
    public float timeToReleaseMonster;
    public float speed;
   
    public void Starts ()
    {
        settingButton.transform.Translate(Vector3.left * speed);
        shoppingButton.transform.Translate(Vector3.left * speed);
        exitButton.transform.Translate(Vector3.right * speed);
        nameGame.transform.Translate(Vector3.up * speed);
        leftPreventer.enabled = true;
        rightPreventer.enabled = true;
        monsterMovement.enabled = true;
    }

}
