using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //생성될 때 플레이어 위치를 감지해서 해당 방향으로 총알의 속도로 발사된다
    // 이 총알은 다른 사물과 충돌했을때 이벤트가 발생하고 이 게임 오브젝트를 제거한다.
    public Transform playerTransform;
    public float bulletSpeed;
    public float spawnTime = 3f;

    Vector3 caulateDirection;
    // (1) 플레이어 위치 감지하는 기능

    // (2) 총알의 이동속도 x 방향으로 총알의 움직임을 구현하기
    
    // (3) 충돌 이벤트를 구현

    // (4) 총알의 생명을 다해서 죽음에 해당하는 부분을 구현할겁니다.총알 삭제

    // Start is called before the first frame update
    //한번만 실행된다

    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //실제로 총알이 움직이는 기능
        BulletMove();
    }


    private void BulletMove()
    {
        // (2) 총알의 이동속도 x 방향으로 총알의 움직임을 구현하기

        transform.position += bulletSpeed * caulateDirection * Time.deltaTime;
    }

    Vector3 playerposition;
    // 시작하다
    public void Initialize()
    {
        // 플레이어의 위치를 받아오는지 테스트 해본다.

        // 플레이어의 위치를 찾아서 해당위치로 총알을 발사하는 기능

        // 전에 구현한 총알은 플레이어를 계속해서 따라가는 문제점
        // 처음 플레이어의 위피를 받은 다음에 그 방향으로 총알을 발사하는 기능을 만들겁니다

        Destroy(gameObject, 3f);

        playerTransform = GameObject.Find("Player").transform;
        caulateDirection = (playerTransform.position - transform.position).normalized;
    }
    // 총알이 파괴되어야할 위치에 이 함수를 실행시켜주면됩니다
    private void OnDestroy()
    {
        
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
        // 총이 플레이어에 충돌해을때 플레이어의 죽음 애니메이션을 실행시키는 기능을 만든다.

        //게임 오브젝트 Tag 디능.
        
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log($"충돌한 오브젝트의 이름 :{collision.gameObject.name}");
            // 플레이어의 체력을 떨어뜨리는 기능.
            // 총알을 맞았을때 바로 게임오버 기능.
            collision.gameObject.GetComponent<PlayerController>().PlayerDeath();
            OnDestroy();
            }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
}
