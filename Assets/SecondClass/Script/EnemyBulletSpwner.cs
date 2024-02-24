using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletspawner: MonoBehaviour
{
    // 총얼울 생성하는 공장. 미리 등록한 제품을 반복해서 생성하는 클래스

    public GameObject bullet;
    public Transform bulletTransform;
    public float spawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    // 코루틴을 사용해서 총알응 생성해볼겁니다.

     IEnumerator SpawnBullet()
    {
        while (true)
        {
            //총알은 생성하는 코드
            GameObject enemyBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            EnemyBullet bulletControl = enemyBullet.GetComponent<EnemyBullet>();
            bulletControl.Test();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    // 총알은 게임이 시작하고 나서 게임이 끝날때까지..
    //또는 Enemy가 죽어서 없어질때 까지 계속해서 총을 발사합니다.

    void Update()
    {
        
    }
}
