using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    public GameObject ContinueBoard;
    public GameObject deathEffect,respawnEffect;
    public delegate bool RespawnEvent();
    public event RespawnEvent OnPlayerRespawn;
    public MonsterMovement monsterMovement;
    // Properties Of Player
    public GameOver gameOver;

    void Start () {

    }


    // Hàm này xử lý khi nhân vật đụng vào chướng ngại vật và chết, được gọi trong Collider.cs
    public void Die()
    {
        Debug.Log("DIE");
        ContinueBoard.SetActive(true);
        gameObject.SetActive(false);
        Instantiate(deathEffect, transform.position, transform.rotation);
        monsterMovement.enabled = false;
    }

    // Hàm này xử lí tái sinh nhân vật sau khi chết, sẽ được gọi khi nhấn nút Yes ở bảng Respawn trong file YesOrNoButton.cs
    public void Respawn ()
    {
        //if (OnPlayerRespawn != null)
        //{
        //    if (OnPlayerRespawn())
        //    {
        Debug.Log("RESPAWN");
        ContinueBoard.SetActive(false);
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        StartCoroutine(CreateRespawnEffect());
        StartCoroutine(ReleaseMonster());
        //    }
        //    else
        //    {
        //        Debug.Log("You have not enough coin to Respawn");
        //    };
        //} else
        //{
        //    Debug.Log("NullOnPlayerRespawn");
        //}
        
    }

    private IEnumerator CreateRespawnEffect()
    {
        yield return new WaitForSeconds(.1f);
        Instantiate(respawnEffect, transform.position, transform.rotation);
    }

    private IEnumerator ReleaseMonster ()
    {
        yield return new WaitForSeconds(1);
        monsterMovement.enabled = true;
    }
}
