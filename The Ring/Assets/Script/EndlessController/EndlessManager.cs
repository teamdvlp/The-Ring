using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessManager : MonoBehaviour {
    public Map lowLevelMap, mediumLevelMap, highLevelMap;
    private List<List<GameObject>> lowMapList ;
    private List<List<GameObject>> mediumMapList;
    private List<List<GameObject>> highMapList;
    public List<GameObject> performingMap;
	private static int order;
	private static Vector2 position;
	public int distance = 80;
	private int NumberOfMapHasBeenBorn;
	private float timer = 3;
	private float timerCache = 0;
    private bool isHighLevelMapPerfoming = false;

    private int position_Had_Been_Chosen_Of_MediumMap, position_Had_Been_Chosen_Of_HighMap;

    // public MapManager mapManager;
    void Awake()
    {
        Pass_All_Map_To_ListMap();
    }

    void Start () {
        // mapManager.OnPlayerCollisionMap += OnPlayerCollisionMap;
        int mapPosition = Random.Range(0, lowMapList.Count - 1);
        
        performingMap = lowMapList[mapPosition];
        Debug.Log("LOW LEVEL MAP");
        timerCache = timer;
		NumberOfMapHasBeenBorn = 0;
		order = 0;
		position = Vector2.zero;
	}


	
	void Update () {
		float dt = Time.deltaTime;
		timerCache -=dt;
		if (timerCache <= 0) {
			timerCache = timer;
            // CreateNewMap();
		}
	}



	public void CreateNewMap () {
		NumberOfMapHasBeenBorn ++;
		GameObject map = this.performingMap[order];
        UpdatePosition();
		map = Instantiate(map);
		map.transform.position = position;
        UpdateMapLocation();
	}

    private void OnPlayerCollisionMap (GameObject map) {
        CreateNewMap();
    }

	private void OnMapStartDestroy () {

	}

    private void ChangeToMediumLevelMap ()
    {
        int position = Random.Range(0, mediumMapList.Count - 1);

        //Check that if The Index of next map equal the index of previous Map;
        if (position == position_Had_Been_Chosen_Of_MediumMap)
        {
            if (position == 0)
            {
                position++;
            } else if (position == mediumMapList.Count - 1)
            {
                position--;
            }
        }

        performingMap = mediumMapList[position];

        position_Had_Been_Chosen_Of_MediumMap = position;

        Debug.Log("MEDIUM MAP");    
    }




    private void ChangeToHighLevelMap ()
    {
        int position = Random.Range(0, mediumMapList.Count - 1);

        //Check that if The Index of next map equal the index of previous Map;
        if (position == position_Had_Been_Chosen_Of_HighMap)
        {
            if (position == 0)
            {
                position++;

            }
            else if (position == highMapList.Count - 1)
            {
                position--;
            }
        }

        performingMap = highMapList[position];

        position_Had_Been_Chosen_Of_HighMap = position;

        Debug.Log("HIGH MAP");
    }

    private void Pass_All_Map_To_ListMap()
    {
        lowMapList = new List<List<GameObject>>();
        highMapList = new List<List<GameObject>>();
        mediumMapList = new List<List<GameObject>>();
        

        lowMapList.Add(lowLevelMap.Mini_Map_1);
        lowMapList.Add(lowLevelMap.Mini_Map_2);
        lowMapList.Add(lowLevelMap.Mini_Map_3);
        

        mediumMapList.Add(mediumLevelMap.Mini_Map_1);
        mediumMapList.Add(mediumLevelMap.Mini_Map_2);
        mediumMapList.Add(mediumLevelMap.Mini_Map_3);
;

        highMapList.Add(mediumLevelMap.Mini_Map_1);
        highMapList.Add(mediumLevelMap.Mini_Map_2);
        highMapList.Add(mediumLevelMap.Mini_Map_3);

        position_Had_Been_Chosen_Of_HighMap = highMapList.Count;
        position_Had_Been_Chosen_Of_MediumMap = mediumMapList.Count;
    }

    private void UpdatePosition () {
		if (order < performingMap.Count - 1) {
			order++;
		} else {
			order = 0;
            ChangeMap();
		}
	}

    private void ChangeMap ()
    {
        if (isHighLevelMapPerfoming)
        {
            ChangeToMediumLevelMap();
            isHighLevelMapPerfoming = false;
        } else
        {
            ChangeToHighLevelMap();
            isHighLevelMapPerfoming = true;    
        }
    }

	private void UpdateMapLocation () {
		position = new Vector2(0,distance * NumberOfMapHasBeenBorn ) ;
	}
}
