using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiResolution : MonoBehaviour {
    public SpriteRenderer f;
   	private float screenW;
	private float screenH;
	private float aspect;
	void Start () {
		screenH = Screen.height;
		screenW = Screen.width;
		aspect = screenH/screenW;
		// 16:9
		if (aspect<1.85 && aspect>1.6) {
			Debug.Log("16/9");
			process169();
		}
		// 18.5/9
		else if (aspect>1.9 && aspect < 2.25) {
			Debug.Log("18.5/9");
			process189();
		}
	}
	void Update()
	{
	}
	private void process169 () {
		Camera.main.aspect = 9f/16f;
        Camera.main.orthographicSize = ((f.bounds.size.x/9f)*16f)/2f;
	}

	private void process189 () {
		Camera.main.aspect = 9f/18f;
		Camera.main.orthographicSize = ((f.bounds.size.x/9f)*18f)/2f;
	}

	private float convertPxtoDp (float Px) {
		return Px / (Screen.dpi/160);
	}

	private float convertDptoPx (float Dp) {
		return Dp * (Screen.dpi/160);
	}
}
