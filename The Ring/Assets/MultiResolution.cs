using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiResolution : MonoBehaviour {
    public Camera cam;
    float aspect;

    void Start()
    {
        aspect = cam.aspect;
        Debug.Log("16/9 = " + (9f/16f));
        if (aspect.Equals(9f/16f))
        {
            Debug.Log("HIHI");
            transform.localScale = new Vector3(1,1,1);
        } else if (cam.aspect == 9f / 18.5f)
        {
            transform.localScale = new Vector3(0.8558578f, 0.8558578f, 0.8558578f);
        } 
    }

}
