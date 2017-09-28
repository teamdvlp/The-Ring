using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class OptionButton : MonoBehaviour, IPointerDownHandler
{
    public string sceneName;

    public virtual void OnPointerDown(PointerEventData ped)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
