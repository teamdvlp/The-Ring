using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TapToStart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
    public Rigidbody2D player;
    public GameObject progressBackground;
    public GameObject progressLoading;
    private bool isTouching;
    public float progressSpeed;
    public float force;
    private float progress;
    StartGame startGameManager;


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("DOWN");
        isTouching = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("UP");
        isTouching = false;
    }

    void Update ()
    {
        if (isTouching)
        {
            RunProgress();
        } else
        {
            StopProgress();
        }
    }

    void RunProgress ()
    {
        progress += progressSpeed * Time.deltaTime;
        if (progress <= 1)
        {
            progressLoading.transform.localScale = new Vector3(progress, progressLoading.transform.localScale.y, progressLoading.transform.localScale.z);
        } else if ( progress >= 1)
        {
            StartGame();
        }
    }

    void StartGame ()
    {
        startGameManager.Starts();
        isTouching = false;
        player.AddForce(Vector2.up * force);
        Destroy(gameObject);
    }

    void StopProgress ()
    {
        progress = 0;
        progressLoading.transform.localScale = new Vector3(progress, progressLoading.transform.localScale.y, progressLoading.transform.localScale.z);
    }

    void Start ()
    {
        startGameManager = GetComponent<StartGame>();
    }
}
