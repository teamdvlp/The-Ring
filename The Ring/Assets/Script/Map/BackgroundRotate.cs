﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotate : MonoBehaviour {

    public float speed;


    void Update () {
        transform.Rotate(0, 0 , speed * Time.deltaTime);
        
    }
}
