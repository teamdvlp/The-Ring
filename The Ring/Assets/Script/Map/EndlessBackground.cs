using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour {
    public List<Background> sourceBackground;
    static List<Background> backgroundList;
    public static int mapPosition;
    public static Vector3 previousPosition;

    private void Start()
    {
        backgroundList = new List<Background>();
        backgroundList.AddRange(sourceBackground);
    }


    public static void CreateNextBackground()
    {
        ProcessPosition();
        Instantiate(backgroundList[mapPosition].gameObject, previousPosition, Quaternion.identity);
        Debug.Log("CREATE");
    }


    private static void ProcessPosition ()
    {
        if (mapPosition >= backgroundList.Count - 1)
        {
            mapPosition = 0;
        } else
        {
            mapPosition++;
        }
    }
	
}
