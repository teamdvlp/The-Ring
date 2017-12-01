using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessBackground : MonoBehaviour {
    public List<Background> backgroundList;
    public int mapOrder;
    public float TimeToDestroyBackground;
    private Vector3 positionSpawn;
    private  List<GameObject> BackgroundHasBeenSpawned;
    public Vector3 positionStartSpawn;
    public MonsterCollider monsterCollider;
    private GameObject selectedBg;
    public int countOfBackgroundWasSpawnedWhenStarting;
    private void Start()
    {
        positionSpawn = positionStartSpawn;
        BackgroundHasBeenSpawned = new List<GameObject>();
        GetComponent<Collider>().OnPlayerColliderWithBackground += OnPlayerCollideBackground;
        monsterCollider.OnMonsterCollideBackground += OnMonsterCollideBackground;
        createBackgroundWhenStarting();
    }

    private void createBackgroundWhenStarting () {
        for (int i = 0; i < countOfBackgroundWasSpawnedWhenStarting; i++) {
            CreateNewBackground();
        }
    }

    public  void CreateNewBackground()
    {
        selectedBg = Instantiate(backgroundList[mapOrder].gameObject, positionSpawn, Quaternion.identity);
        ProcessPosition();
        updatePositionBackground();
        BackgroundHasBeenSpawned.Add(selectedBg);
        
    }


    private  void ProcessPosition ()
    {
        if (mapOrder >= backgroundList.Count - 1)
        {
            mapOrder = 0;
        } else
        {
            mapOrder++;
        }
    }

    private void updatePositionBackground () {
        positionSpawn = selectedBg.transform.GetChild(0).transform.position                                                                                                                                                                                                                                                                                                          ;
    }

    private  int CountBackgroundAbovePlayer () {
        return BackgroundHasBeenSpawned.FindAll(x => x.transform.position.y > this.transform.position.y).Count;
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
        yield return new WaitForSeconds (TimeToDestroyBackground);
        Destroy(bg);
    }
}
