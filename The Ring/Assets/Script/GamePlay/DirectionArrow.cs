using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrow : MonoBehaviour {
    public float rotateSpeed;
    public float torque;

    // Mũi tên chỉ hướng
    public GameObject director;

    // Truyền Player vào
    public GameObject players;
    Rigidbody2D playerRigid2D;
    Vector3 direction;
    public Animator effectJump;
    Vector3 offset;
    public AudioSource soundJump;

    // Có đang chạm vào màn hình không
    public bool isTouching { get; set; }

    public GameObject normalMovingEffect, ultraMovingEffect;

    private void Start()
    {
        offset = players.transform.position - transform.position;
        playerRigid2D = players.GetComponent<Rigidbody2D>();
    }

    void Update () {
        if (!isTouching)
        transform.Rotate(new Vector3(0,0, rotateSpeed * Time.deltaTime));

        gameObject.transform.position = players.transform.position - offset;
    }

    public void AddForces (float force, bool isUltraPower)
    {

        //Invoke(Jump(force, isUltraPower), 10f);
        StartCoroutine(Jump(force, isUltraPower));
    }

    IEnumerator Jump (float force, bool isUltraPower)
    {
        direction = director.transform.position - transform.position;

        yield return new WaitForSecondsRealtime(0.13f);
        // Nếu như mũi tên đang dừng quay thì cho nó tiếp tục quay sau khi di chuyển
        

        // Nếu như đã hold hết cây năng lượng thì instantiate cái hiệu ứng ultra
        if (isUltraPower)
        {
            Instantiate(ultraMovingEffect, players.transform.position, Quaternion.identity);
        }
        // Nếu không thì Instantiate hiệu ứng bình thường
        else
        {
            Instantiate(normalMovingEffect, players.transform.position, normalMovingEffect.transform.rotation);
        }
        // Direction sẽ có 1 cái node tên là director (Con của Direction Arrow) nằm theo cái hướng của mũi tên,
        // lúc bắn đi thì lấy tọa độ của director đó
        // trừ lại cho transform.position là ra

        Debug.Log(direction);
        playerRigid2D.velocity = (direction.normalized * force);
        playerRigid2D.angularVelocity = torque;
        effectJump.Play("EffectJump");
        soundJump.Play();

        if (rotateSpeed == 0)
        {
            rotateSpeed = 500;
            Debug.Log("START ROTATE");
        }
    }
}
