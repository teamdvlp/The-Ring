using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public List<Sprite> listSprite;
    public DirectionArrow directionArrow;
    public float startForce;
    public float startTouchingTime;
    public SpriteRenderer playerRenderer;
    public float ForceStrenght;
    float force;
    bool isTouching = false;
    public float touchingTime;
    public bool isFullPowerBefore = false;

    void Start()
    {
        force = startForce;
        touchingTime = startTouchingTime;    
    }

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
            force += Time.deltaTime * ForceStrenght;
            touchingTime -= Time.deltaTime;
            // Giống Animation
            ChangeSpriteOfPlayerFollowState();

            if (touchingTime <= 0)
            {
                force = startForce + startTouchingTime * 2f * ForceStrenght ;
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
        if (touchingTime >= startTouchingTime * 0.9f)
        {
            playerRenderer.sprite = listSprite[0];
        }
        else if (touchingTime >= startTouchingTime * 0.8f)
        {
            playerRenderer.sprite = listSprite[1];
        }
        else if (touchingTime >= startTouchingTime * 0.7f)
        {
            playerRenderer.sprite = listSprite[2];
        }
        else if (touchingTime >= startTouchingTime * 0.6f)
        {
            playerRenderer.sprite = listSprite[3];
        }
        else if (touchingTime >= startTouchingTime * 0.5f)
        {
            playerRenderer.sprite = listSprite[4];
        }
        else if (touchingTime >= startTouchingTime * 0.4f)
        {
            playerRenderer.sprite = listSprite[5];
        }
        else if (touchingTime >= startTouchingTime * 0.3f)
        {
            playerRenderer.sprite = listSprite[6];
        }
        else if (touchingTime >= startTouchingTime * 0.2f)
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
        touchingTime = startTouchingTime;
        //loadingProgress.SetActive(false);
    }

 
}
