using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MultiResolution : MonoBehaviour {
    public SpriteRenderer BiggestSprite;
   	private float screenW;
	private float screenH;
	public float aspect;
    public float Rate = -1;
    private List<float> listRate;
	void Start () {
		screenH = Screen.height;
		screenW = Screen.width;
		aspect = screenH/screenW;
		Rate = findRateScreen(aspect);
        processMultipleResolution ();
	}
	private void processMultipleResolution()
	{
        if (Rate == -1) {
            return;
        }
        // chênh lệch quá nhiều thì không làm gì hết vì nếu scale thì nó sẽ bị méo nhiều
        if (Math.Abs(Rate - aspect) > 0.15) {
            return;
        }
        Camera.main.aspect = 1/Rate;
        Camera.main.orthographicSize = (BiggestSprite.bounds.size.x*Rate)/2f;
	}

    private float findRateScreen (float aspect) {
        listRate = new List<float>() {16f/9f, 16/10f, 18.5f/9f, 18f/9f, 4f/3f, 5f/4f};
        float Rate = listRate[0];
        for (int i = 0; i < listRate.Count-1; i++) {
            if ((Mathf.Abs(aspect - Rate)) > (Mathf.Abs(aspect - listRate[i]))) {
                Rate = listRate[i];
            }
        }
        return Rate;
    }
}
