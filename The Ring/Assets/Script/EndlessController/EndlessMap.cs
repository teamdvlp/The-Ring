    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMap : MonoBehaviour {
    public Map lowLevelMap, mediumLevelMap, highLevelMap;
    private List<List<GameObject>> lowMapList ;
    private List<List<GameObject>> mediumMapList;
    private List<List<GameObject>> highMapList;
    public List<GameObject> performingMap;
	private static int order;
    private bool isHighLevelMapPerfoming = false;
    public Vector2 positionSpawn;
    private GameObject selectedMap;
    public float TimeToDestroyMap;
    private int position_Had_Been_Chosen_Of_MediumMap, position_Had_Been_Chosen_Of_HighMap;
    public MonsterCollider monsterCollider;
    private List<GameObject> mapHasbeenSpawned;
    public int countOfMapWasSpawnedWhenStarting;
    void Awake()
    {
        Pass_All_Map_To_ListMap();
    }

    void Start () {
        mapHasbeenSpawned = new List<GameObject>();
        GetComponent<Collider>().OnPlayerColliderWithMapBorder += OnPlayerCollisionMapBorder;
        monsterCollider.OnMonsterColliderWithMapBorder += OnMonsterCollisionMapBorder;
        int mapPosition = Random.Range(0, lowMapList.Count - 1);
        performingMap = lowMapList[mapPosition];
		order = 0;
        createMapWhenStarting();
	}

    private void createMapWhenStarting () {
        for (int i = 0; i < countOfMapWasSpawnedWhenStarting; i++) {
            CreateNewMap();
        } 
    }

	public void CreateNewMap () {
		selectedMap = this.performingMap[order];
        UpdatePosition();
		selectedMap = Instantiate(selectedMap);
		selectedMap.transform.position = positionSpawn;
        UpdateMapLocation();
        mapHasbeenSpawned.Add(selectedMap);
	}

    private int checkTheCountOfMapAbovePlayer() {
        return mapHasbeenSpawned.FindAll (map => map.transform.position.y > this.transform.position.y).Count;
    }

    private IEnumerator DestroyMapAfterSec (GameObject map) {
        yield return new WaitForSeconds (TimeToDestroyMap);
        Destroy(map);
        mapHasbeenSpawned.Remove(map);
        
    }
    private void OnPlayerCollisionMapBorder (GameObject map) {
        if (checkTheCountOfMapAbovePlayer() <= 2) {
            CreateNewMap();
        }
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
<<<<<<< HEAD:The Ring/Assets/Script/EndlessController/EndlessMap.cs
        
=======
>>>>>>> 1b02d5c6f6f0056e01abaff76709ab23cd566bf1:The Ring/Assets/Script/EndlessController/EndlessManager.cs
    }

    private void OnMonsterCollisionMapBorder (GameObject map) {
        StartCoroutine(DestroyMapAfterSec(map));
    }


    private void ChangeToHighLevelMap ()
    {
        int position = Random.Range(0, highMapList.Count - 1);
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

<<<<<<< HEAD:The Ring/Assets/Script/EndlessController/EndlessMap.cs
    }

    private void createNewBackground () {

=======
>>>>>>> 1b02d5c6f6f0056e01abaff76709ab23cd566bf1:The Ring/Assets/Script/EndlessController/EndlessManager.cs
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
        positionSpawn = selectedMap.transform.GetChild(0).transform.position;
	}
}
