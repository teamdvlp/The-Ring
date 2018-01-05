using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour {
    public List<Background> backgroundList;
    private List<GameObject> backgroundHasBeenSpawned;
    public int mapOrder;
    public int count_Of_Background_Was_Spawned_When_Start_Game;
    public float timeToDestroyBackground;
    private Vector3 positionSpawn;
    public Vector3 positionStartSpawn;
    public MonsterCollider monsterCollider;
    private GameObject selected_Background;


    private void Start()
    {
        positionSpawn = positionStartSpawn;
        backgroundHasBeenSpawned = new List<GameObject>();
        GetComponent<Collider>().OnPlayerColliderWithBackground += OnPlayerCollideBackground;
        monsterCollider.OnMonsterCollideBackground += OnMonsterCollideBackground;
        createBackgroundWhenStarting();
    }


    private void createBackgroundWhenStarting () {
        for (int i = 0; i < count_Of_Background_Was_Spawned_When_Start_Game; i++) {
            CreateNewBackground();
        }
    }


    public  void CreateNewBackground()
    {
        selected_Background = Instantiate(backgroundList[mapOrder].gameObject, positionSpawn, Quaternion.identity);
        UpdateMapOrder();
        UpdateMapOrderBackground();
        backgroundHasBeenSpawned.Add(selected_Background);
        
    }


    private  void UpdateMapOrder ()
    {
        if (mapOrder >= backgroundList.Count - 1)
        {
            mapOrder = 0;
        } else
        {
            mapOrder++;
        }
    }

    private void UpdateMapOrderBackground () {
        positionSpawn = selected_Background.transform.GetChild(0).transform.position                                                                                                                                                                                                                                                                                                          ;
    }


    private  int CountBackgroundAbovePlayer () {
        return backgroundHasBeenSpawned.FindAll(x => x.transform.position.y > this.transform.position.y).Count;
    }


    private void OnMonsterCollideBackground (GameObject bg) {
        StartCoroutine(DestroyBackgroundAfterSec(bg));      
    }


    private void OnPlayerCollideBackground (GameObject bg) {
        if (CountBackgroundAbovePlayer() <= 2) {
        CreateNewBackground();
        }
    }


    private IEnumerator DestroyBackgroundAfterSec (GameObject bg) {
        yield return new WaitForSeconds (timeToDestroyBackground);
        Destroy(bg);
    }
}
