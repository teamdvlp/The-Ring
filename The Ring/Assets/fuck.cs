using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuck : MonoBehaviour {
	public SpriteRenderer f169;
	public SpriteRenderer f189;
	public SpriteRenderer small;
	private float screenW;
	private float screenH;
	private float aspect;
	public bool is169;
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
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
	}
	private void process169 () {
		f169.enabled = true;
		f189.enabled = false;
		Camera.main.aspect = f169.bounds.size.x/f169.bounds.size.y;
		Camera.main.orthographicSize = f169.bounds.size.y/2f;
	}

	private void process189 () {
		f169.enabled = false;
		f189.enabled = true;
		Camera.main.aspect = f189.bounds.size.x/f189.bounds.size.y;
		Camera.main.orthographicSize = f189.bounds.size.y/2f;
	}

	private float convertPxtoDp (float Px) {
		return Px / (Screen.dpi/160);
	}

	private float convertDptoPx (float Dp) {
		return Dp * (Screen.dpi/160);
	}
}
