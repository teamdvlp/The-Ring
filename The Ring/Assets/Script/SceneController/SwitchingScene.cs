using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SwitchingScene : MonoBehaviour, IPointerClickHandler  {

    public string SceneName;
    public GameObject background;
    public Image progress;

    public void OnPointerClick(PointerEventData eventData)
    {
        background.SetActive(true);
        StartCoroutine(Load());   
    }

    IEnumerator Load ()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);
        while (!operation.isDone)
        {
            progress.transform.localScale = new Vector3(Mathf.Clamp01(operation.progress / 0.9f), progress.transform.localScale.y, progress.transform.localScale.z);
            //progress.transform.localScale.Scale(new Vector3(0, operation.progress, 0));
            yield return null;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
