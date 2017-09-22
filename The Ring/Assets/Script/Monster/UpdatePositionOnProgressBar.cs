﻿using System.Collections;
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
        // Do scale Canvas đi 40 lần nên vị trí của nó trên scene cũng bị scale đi 40 lần, vì vậy ta phải nhân lại 40 mới ra được vị trí đúng
        // VD: Ta thấy gameObject.x = 100 nhưng do bị scale 40 lần nên chỉ còn 2.5
        streetLenght = destination.transform.position.x - startingPosition.transform.position.x;
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
        streetHaveGone = (this.gameObject.transform.position.x - startingPosition.transform.position.x) / streetLenght;
        if (streetHaveGone < 0) return;  
        this.progressBar.transform.localScale = new Vector3(streetHaveGone, 1, 1);
    }

    void OnEnd ()
    {

    }
}
