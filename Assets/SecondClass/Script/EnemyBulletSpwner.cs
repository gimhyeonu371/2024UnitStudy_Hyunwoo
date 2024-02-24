using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletspawner: MonoBehaviour
{
    // �Ѿ�� �����ϴ� ����. �̸� ����� ��ǰ�� �ݺ��ؼ� �����ϴ� Ŭ����

    public GameObject bullet;
    public Transform bulletTransform;
    public float spawnTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBullet());
    }

    // �ڷ�ƾ�� ����ؼ� �Ѿ��� �����غ��̴ϴ�.

     IEnumerator SpawnBullet()
    {
        while (true)
        {
            //�Ѿ��� �����ϴ� �ڵ�
            GameObject enemyBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);

            EnemyBullet bulletControl = enemyBullet.GetComponent<EnemyBullet>();
            bulletControl.Test();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    // �Ѿ��� ������ �����ϰ� ���� ������ ����������..
    //�Ǵ� Enemy�� �׾ �������� ���� ����ؼ� ���� �߻��մϴ�.

    void Update()
    {
        
    }
}
