using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MultiResolution : MonoBehaviour {
    public SpriteRenderer BiggestSprite;
   	private float screenW;
	private float screenH;
	public float aspect;
    public double Rate = -1;
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

        process();

        // if (Rate == Math.Round(16f/9f,4)) {
        //     Debug.Log("169");
        //     process169();
        // } 
        // else if (Rate == Math.Round(18.5f/9f,4)) {
        //     process189();
        //     Debug.Log("189");
        // } 
        // else if (Rate == Math.Round(4f/3f, 4)) {
        //     Debug.Log("43");
        //     process43 ();
        // }
        // else if (Rate == Math.Round(16f/10f, 4)) {
        //     Debug.Log("1610");
        //     process1610 ();
        // }
        // else if (Rate == Math.Round(5f/4f,4)) {
        //     Debug.Log("54");
        //     process54 ();
        // }
        // else if (Rate == Math.Round(18.5f/9f,4)) {
        //     Debug.Log("1859");
        //     process1859 ();
        // }
	}

        private void process () {
        float Rate1 = (float) Rate;
        Camera.main.aspect = Rate1/Rate1/Rate1;
        Camera.main.orthographicSize = (BiggestSprite.bounds.size.x*Rate1)/2f;
}

    private void process1859() {
        Camera.main.aspect = 9f/18.5f;
        Camera.main.orthographicSize = ((BiggestSprite.bounds.size.x/9f)*18.5f)/2f;
    }

    private void process1610 () {
        Camera.main.aspect = 10f/16f;
        Camera.main.orthographicSize = ((BiggestSprite.bounds.size.x/10f)*16f)/2f;
    }

    private void process43 () {
        Camera.main.aspect = 3f/4f;
        Camera.main.orthographicSize = ((BiggestSprite.bounds.size.x/3f)*4f)/2f;
    }

    private void process54 () {
        Camera.main.aspect = 4f/5f;
        Camera.main.orthographicSize = ((BiggestSprite.bounds.size.x/4f)*5f)/2f;
    }

	private void process169 () {
		Camera.main.aspect = 9f/16f;
        Camera.main.orthographicSize = ((BiggestSprite.bounds.size.x/9f)*16f)/2f;
	}
    
	private void process189 () {
		Camera.main.aspect = 9f/18f;
		Camera.main.orthographicSize = ((BiggestSprite.bounds.size.x/9f)*18f)/2f;
	}

	private float convertPxtoDp (float Px) {
		return Px / (Screen.dpi/160);
	}

	private float convertDptoPx (float Dp) {
		return Dp * (Screen.dpi/160);
	}

    private double findRateScreen (float aspect) {
        listRate = new List<float>() {16f/9f, 16/10f, 18.5f/9f, 18f/9f, 4f/3f, 5f/4f};
        float Rate = listRate[0];
        for (int i = 0; i < listRate.Count-1; i++) {
            if ((Mathf.Abs(aspect - Rate)) > (Mathf.Abs(aspect - listRate[i]))) {
                Rate = listRate[i];
            }
        }
        return Math.Round(Rate, 4);
    }
}
