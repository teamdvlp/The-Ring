using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public List<Sprite> listSprite;
    public DirectionArrow directionArrow;
    public float startForce = 2000f;
    public SpriteRenderer playerRenderer;
    public float force;
    bool isTouching = false;
    public float touchingTime;
    public bool isFullPowerBefore = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        isTouching = true;
        isFullPowerBefore = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isFullPowerBefore)
        {
            AddForce(false);
        }
    }

    void Update () {
		if (isTouching)
        {
            directionArrow.isTouching = true;
            force += Time.deltaTime * 1000;
            touchingTime -= Time.deltaTime;
            // Giống Animation
            ChangeSpriteOfPlayerFollowState();

            if (touchingTime <= 0)
            {
                force = startForce + 0.75f * 1.5f * 1000;
                AddForce(true);
                isFullPowerBefore = true;
                playerRenderer.sprite = listSprite[0];
            }
        } else
        {
            playerRenderer.sprite = listSprite[0];
        }
    }

    void ChangeSpriteOfPlayerFollowState()
    {
        if (touchingTime >= 0.72f)
        {
            playerRenderer.sprite = listSprite[0];
        }
        else if (touchingTime >= 0.68f)
        {
            playerRenderer.sprite = listSprite[1];
        }
        else if (touchingTime >= 0.60f)
        {
            playerRenderer.sprite = listSprite[2];
        }
        else if (touchingTime >= 0.52f)
        {
            playerRenderer.sprite = listSprite[3];
        }
        else if (touchingTime >= 0.44f)
        {
            playerRenderer.sprite = listSprite[4];
        }
        else if (touchingTime >= 0.36f)
        {
            playerRenderer.sprite = listSprite[5];
        }
        else if (touchingTime >= 0.28f)
        {
            playerRenderer.sprite = listSprite[6];
        }
        else if (touchingTime >= 0.20f)
        {
            playerRenderer.sprite = listSprite[7];
        }
    }

    void AddForce(bool isUltraPower)
    {
        directionArrow.AddForces(force, isUltraPower);
        Debug.Log(force);
        force = startForce;
        isTouching = false;
        directionArrow.isTouching = false;
        touchingTime = 0.79f;
        //loadingProgress.SetActive(false);
    }

    void Start ()
    {
        force = startForce;
    }
}
