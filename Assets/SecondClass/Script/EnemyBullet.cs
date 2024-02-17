using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //������ �� �÷��̾� ��ġ�� �����ؼ� �ش� �������� �Ѿ��� �ӵ��� �߻�ȴ�
    // �� �Ѿ��� �ٸ� �繰�� �浹������ �̺�Ʈ�� �߻��ϰ� �� ���� ������Ʈ�� �����Ѵ�.

    // (1) �÷��̾� ��ġ �����ϴ� ���
    public Transform playerTransform;

    // (2) �Ѿ��� �̵��ӵ� x �������� �Ѿ��� �������� �����ϱ�
    public float BulletSpeed;
    // (3) �浹 �̺�Ʈ�� ����

    // (4) �Ѿ��� ������ ���ؼ� ������ �ش��ϴ� �κ��� �����Ұ̴ϴ�.�Ѿ� ����

    // Start is called before the first frame update
    void Start()
    {
        // �÷��̾��� ��ġ�� �޾ƿ����� �׽�Ʈ �غ���.
        Debug.Log($"���� �÷��̾��� ��ġ : {playerTransform}");

        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }

    private void BulletMove()
    {
        // (2) �Ѿ��� �̵��ӵ� x �������� �Ѿ��� �������� �����ϱ�
        Vector3 PlayerDirection = new Vector3(playerTransform.position.x, 0 , playerTransform.position.z);
        transform.position += BulletSpeed * PlayerDirection * Time.deltaTime;
        Vector3 caulateDirection = (PlayerDirection - transform.position).normalized;

        transform.position += BulletSpeed * caulateDirection * Time.deltaTime;
    }

    public void Test()
    {
        Debug.Log("�Ѿ��� �߻�Ǿ���");
    }
    //�Ѿ��� �浹������ �浹�� ������Ʈ�� ��ȣ�ۿ��� �Ҽ��ִ� ����Դϴ�
    //�������� �浹�� �������� ��ȣ�ۿ��� �Ͼ�� �̺�Ʈ��
    // Rigidbody, Collider�� �ݵ�� �ϳ� �̻��� ������Ʈ�� �����ؾ� �۵��Ѵ�
    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log($"�浹�� ������Ʈ�� �̸� :{collision.gameObject.name}");
                // �÷��̾��� ü���� ����߸��� ���.
                // �Ѿ��� �¾����� �ٷ� ���ӿ��� ���.
            }
    }
}
