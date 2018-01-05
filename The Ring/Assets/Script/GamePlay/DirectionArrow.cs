using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour {
    public float rotateSpeed;

    // Mũi tên chỉ hướng
    public GameObject director;

    // Truyền Player vào
    public GameObject players;
    Rigidbody2D playerRigid2D;
    Vector3 direction;
    // Có đang chạm vào màn hình không
    public bool isTouching { get; set; }

    public GameObject normalMovingEffect, ultraMovingEffect;

    private void Start()
    {
        playerRigid2D = players.GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (!isTouching)
        transform.Rotate(new Vector3(0,0, rotateSpeed * Time.deltaTime));    
    }

    public void AddForces (float force, bool isUltraPower)
    {
        // Nếu như mũi tên đang dừng quay thì cho nó tiếp tục quay sau khi di chuyển
        if (rotateSpeed == 0)
        {
            rotateSpeed = 500;
        }

        // Nếu như đã hold hết cây năng lượng thì instantiate cái hiệu ứng ultra
        if (isUltraPower)
        {
            Instantiate(ultraMovingEffect, players.transform.position, Quaternion.identity);
        }
        // Nếu không thì Instantiate hiệu ứng bình thường
        else
        {
            Instantiate(normalMovingEffect, players.transform.position, Quaternion.identity);
        }
        // Direction sẽ có 1 cái node tên là director (Con của Direction Arrow) nằm theo cái hướng của mũi tên,
        // lúc bắn đi thì lấy tọa độ của director đó
        // trừ lại cho transform.position là ra
        direction = director.transform.position - transform.position;
        playerRigid2D.velocity = (direction * force);
    }
}
