using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //생성될 때 플레이어 위치를 감지해서 해당 방향으로 총알의 속도로 발사된다
    // 이 총알은 다른 사물과 충돌했을때 이벤트가 발생하고 이 게임 오브젝트를 제거한다.

    // (1) 플레이어 위치 감지하는 기능
    public Transform playerTransform;

    // (2) 총알의 이동속도 x 방향으로 총알의 움직임을 구현하기
    public float BulletSpeed;
    // (3) 충돌 이벤트를 구현

    // (4) 총알의 생명을 다해서 죽음에 해당하는 부분을 구현할겁니다.총알 삭제

    // Start is called before the first frame update
    void Start()
    {
        // 플레이어의 위치를 받아오는지 테스트 해본다.
        Debug.Log($"현재 플레이어의 위치 : {playerTransform}");

        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        // (2) 총알의 이동속도 x 방향으로 총알의 움직임을 구현하기
        Vector3 PlayerDirection = new Vector3(playerTransform.position.x, 0 , playerTransform.position.z);
        transform.position += BulletSpeed * PlayerDirection * Time.deltaTime;
        Vector3 caulateDirection = (PlayerDirection - transform.position).normalized;

        transform.position += BulletSpeed * caulateDirection * Time.deltaTime;
    }

    public void Test()
    {
        Debug.Log("총알이 발사되었음");
    }
    //총알이 충돌했을떄 충돌한 오브젝트랑 상호작용을 할수있는 기능입니다
    //물리적인 충돌이 있을때만 상호작용이 일어나는 이벤트임
    // Rigidbody, Collider가 반드시 하나 이상의 오브젝트에 존재해야 작동한다
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log($"충돌한 오브젝트의 이름 :{collision.gameObject.name}");
                // 플레이어의 체력을 떨어뜨리는 기능.
                // 총알을 맞았을때 바로 게임오버 기능.
            }
    }
}
