using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour {

    public GameObject backgroundTop, backgroundMiddle, backgroundBot;
    public GameObject topTop, topMiddle, topBot;
    public GameObject botOfScreen;
    public float speed;
    private float lengthOfOneBackground;
    private float minY;
    

    void Start ()
    {
        GetTopOfBackground();
        PreparePosition();
        lengthOfOneBackground = topTop.transform.position.y - backgroundTop.transform.position.y;
        minY = botOfScreen.transform.position.y - lengthOfOneBackground;
    }

    void Update()
    {
        RunBackground();
        ProcessWhenOverLength(backgroundTop, topMiddle);
        ProcessWhenOverLength(backgroundMiddle, topBot);
        ProcessWhenOverLength(backgroundBot, topTop);
    }


    // SUPPORT METHOD

    void PreparePosition()
    {
        Debug.Log("HELLO");
        backgroundMiddle.transform.position = topBot.transform.position;
        backgroundTop.transform.position = topMiddle.transform.position;
    }


    void GetTopOfBackground ()
    {
        topTop = backgroundTop.GetComponent<Background>().top;
        topMiddle = backgroundMiddle.GetComponent<Background>().top;
        topBot = backgroundBot.GetComponent<Background>().top;
    }
    

    void ProcessWhenOverLength (GameObject background, GameObject top)
    {
                                    // Khi Background đi hết màn hình
        if (background.transform.position.y <= minY)
        {
                                    // Set vị trí chồng lên cái top của cái background đang ở vị trí trên cùng
            background.transform.position = top.transform.position;
        }
    }


    void RunBackground ()
    {
        backgroundTop.transform.Translate(Vector2.down * speed);
        backgroundMiddle.transform.Translate(Vector2.down * speed);
        backgroundBot.transform.Translate(Vector2.down * speed); 
    }

    /////////////////
}


