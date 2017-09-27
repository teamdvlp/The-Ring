using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePositionOnProgressBar : MonoBehaviour
{
    // Cho vào một thanh Image, Sprite có Pivot nằm ở (0,0.5) để nó scale ra;
    public Image progressBar;
    public GameObject destination;
    float streetLenght;
    public GameObject startingPosition;
    float streetHaveGone;

    // Use this for initialization
    void Start()
    {
        streetLenght = destination.transform.position.y - startingPosition.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    // Cập nhật vị trí của gameObject trên progessBar
    void UpdatePosition()
    {
        // Xử lý sự kiện khi đã đi hết đường
        if (streetHaveGone >= 1)
        {
            OnEnd();    
            return;
        }

        // StreetHaveGone : Đường đã đi được
        streetHaveGone = (this.gameObject.transform.position.y - startingPosition.transform.position.y) / streetLenght;
        if (!(streetHaveGone < 0 || streetHaveGone >= 1))
        {
            this.progressBar.transform.localScale = new Vector3(1, streetHaveGone, 1);
        }
    }

    void OnEnd ()
    {

    }
}
﻿