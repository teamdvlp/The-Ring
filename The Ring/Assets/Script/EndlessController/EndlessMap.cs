    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMap : MonoBehaviour {
    
    //Map.cs chứa các Map truyền vào
    public Map lowLevelMap, mediumLevelMap, highLevelMap;

    // List của List, nhìn kỹ
    private List<List<GameObject>> lowMapList ;
    private List<List<GameObject>> mediumMapList;
    private List<List<GameObject>> hardMapList;

    //Map đang chạy
    public List<GameObject> runningMap;

    //Vị trí của mini Map trong runningMap;
	private static int order;

    //Vị trí Random khi spawn map để Random Map
    private static int randomPosition;

    // Có phải Map khó đang được chạy,
    private bool isHighLevelMapRunning = false;
    public Vector2 positionSpawn;
    private GameObject selectedMap;
    public float TimeToDestroyMap;

    // Vị trí của map trong list đã chọn trước đó
    private int previous_Running_Medium_Map_INDEX, previous_Running_Hard_Map_INDEX;

    public MonsterCollider monsterCollider;
    private List<GameObject> mapHasbeenSpawned;
    public int count_Of_Map_Was_Spawned_When_Starting;


    void Awake()
    // Truyền các Map từ file Map.cs vào các ListMap (LowMapList, mediumMapList, hardMapList)
    {
        Pass_All_Map_To_ListMap(); 
    }

    void Start () {
        mapHasbeenSpawned = new List<GameObject>();

        // Truyền Event va chạm vớp MapBorder và Va chạm với Monster
        GetComponent<Collider>().OnPlayerColliderWithMapBorder += OnPlayerCollisionMapBorder;
        monsterCollider.OnMonsterColliderWithMapBorder += OnMonsterCollisionMapBorder;

        // Random vị trí để lấy map ngẫu nhiên từ ListMap
        int mapPosition = Random.Range(0, lowMapList.Count - 1);
        runningMap = lowMapList[mapPosition];
		order = 0;
        createMapWhenStarting();
	}

    private void createMapWhenStarting () {
        for (int i = 0; i < count_Of_Map_Was_Spawned_When_Starting; i++) {
            CreateNewMap();
        } 
    }

	public void CreateNewMap () {
		selectedMap = this.runningMap[order];
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

        // RandomPosition được khởi tạo lại trong hàm này, nếu trùng thì tiếp tục random, không trùng thì lấy giá trị đó;
        GetExactlyRandomPosition(mediumMapList.Count);

        runningMap = mediumMapList[randomPosition];

        previous_Running_Medium_Map_INDEX = randomPosition;
    }


    private void ChangeToHighLevelMap()
    {
        GetExactlyRandomPosition(hardMapList.Count);

        runningMap = hardMapList[randomPosition];

        previous_Running_Hard_Map_INDEX = randomPosition;

    }


    private void GetExactlyRandomPosition (int limitOfRandom)
    {
        int position = Random.RandomRange(0, limitOfRandom);
        if (position == previous_Running_Medium_Map_INDEX)
        {
            GetExactlyRandomPosition(limitOfRandom);
        } else
        {
            randomPosition = position;
        }
    }

    private void OnMonsterCollisionMapBorder (GameObject map) {
        StartCoroutine(DestroyMapAfterSec(map));
    }



    private void createNewBackground () {

    }

    private void Pass_All_Map_To_ListMap()
    {
        lowMapList = new List<List<GameObject>>();
        hardMapList = new List<List<GameObject>>();
        mediumMapList = new List<List<GameObject>>();
        

        lowMapList.Add(lowLevelMap.Mini_Map_1);
        lowMapList.Add(lowLevelMap.Mini_Map_2);
        lowMapList.Add(lowLevelMap.Mini_Map_3);
        

        mediumMapList.Add(mediumLevelMap.Mini_Map_1);
        mediumMapList.Add(mediumLevelMap.Mini_Map_2);
        mediumMapList.Add(mediumLevelMap.Mini_Map_3);
;

        hardMapList.Add(mediumLevelMap.Mini_Map_1);
        hardMapList.Add(mediumLevelMap.Mini_Map_2);
        hardMapList.Add(mediumLevelMap.Mini_Map_3);

        previous_Running_Hard_Map_INDEX = hardMapList.Count;
        previous_Running_Medium_Map_INDEX = mediumMapList.Count;
    }


    // Cập nhật vị trí khi Player chạm vào mốc đổi vị trí (Map Border)
    private void UpdatePosition () {
		if (order < runningMap.Count - 1) {
			order++;
		} else {
			order = 0;
            ChangeMap();
		}
	}

    private void ChangeMap ()
    {
        if (isHighLevelMapRunning)
        {
            ChangeToMediumLevelMap();
            isHighLevelMapRunning = false;
        } else
        {
            ChangeToHighLevelMap();
            isHighLevelMapRunning = true;    
        }
    }

	private void UpdateMapLocation () {
        positionSpawn = selectedMap.transform.GetChild(0).transform.position;
	}
}
