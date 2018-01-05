using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroySoundManager : MonoBehaviour {
	private static bool isStartGame;

	void Start () {
        // Nếu như đã StartGame rồi thì không được tạo thêm nữa
        if (isStartGame) {
			Destroy (gameObject);
		} else { // Nếu đã StartGame và tạo ra cái cái SoundManager đó rồi thì sẽ không hủy khi Load Scene m
			DontDestroyOnLoad (this.gameObject);
            isStartGame = true;
		}
	}
}
