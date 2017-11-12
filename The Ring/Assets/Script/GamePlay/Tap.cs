using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
    public TapTapTap tapManager;
    public float force = 2000;
    bool isTouching = false;
    public float touchingTime;
    // public GameObject loadingProgress,progress;
    private bool isFullPowerBefore = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        isTouching = true;
        isFullPowerBefore = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isFullPowerBefore)
        AddForce();
    }

    void Update () {
		if (isTouching)
        {
            tapManager.isTouching = true;
            force += Time.deltaTime * 1000;
            touchingTime -= Time.deltaTime;
            if (touchingTime < 0.6f)
            {
                // loadingProgress.SetActive(true);
                // progress.transform.localScale = new Vector3((0.75f - touchingTime)/0.75f,1f,1f);
            }
            if (touchingTime <= 0)
            {
                force = 2800;
                AddForce();
                isFullPowerBefore = true;
            }
        }
	}

    void AddForce ()
    {
        tapManager.AddForces(force);
        force = 2000;
        isTouching = false;
        tapManager.isTouching = false;
        touchingTime = 0.75f;
        // loadingProgress.SetActive(false);
    }
}
