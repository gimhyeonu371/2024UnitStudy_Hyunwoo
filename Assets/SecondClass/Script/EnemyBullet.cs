using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //������ �� �÷��̾� ��ġ�� �����ؼ� �ش� �������� �Ѿ��� �ӵ��� �߻�ȴ�
    // �� �Ѿ��� �ٸ� �繰�� �浹������ �̺�Ʈ�� �߻��ϰ� �� ���� ������Ʈ�� �����Ѵ�.
    public Transform playerTransform;
    public float bulletSpeed;
    public float spawnTime = 3f;

    Vector3 caulateDirection;
    // (1) �÷��̾� ��ġ �����ϴ� ���

    // (2) �Ѿ��� �̵��ӵ� x �������� �Ѿ��� �������� �����ϱ�
    
    // (3) �浹 �̺�Ʈ�� ����

    // (4) �Ѿ��� ������ ���ؼ� ������ �ش��ϴ� �κ��� �����Ұ̴ϴ�.�Ѿ� ����

    // Start is called before the first frame update
    //�ѹ��� ����ȴ�

    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //������ �Ѿ��� �����̴� ���
        BulletMove();
    }


    private void BulletMove()
    {
        // (2) �Ѿ��� �̵��ӵ� x �������� �Ѿ��� �������� �����ϱ�

        transform.position += bulletSpeed * caulateDirection * Time.deltaTime;
    }

    Vector3 playerposition;
    // �����ϴ�
    public void Initialize()
    {
        // �÷��̾��� ��ġ�� �޾ƿ����� �׽�Ʈ �غ���.

        // �÷��̾��� ��ġ�� ã�Ƽ� �ش���ġ�� �Ѿ��� �߻��ϴ� ���

        // ���� ������ �Ѿ��� �÷��̾ ����ؼ� ���󰡴� ������
        // ó�� �÷��̾��� ���Ǹ� ���� ������ �� �������� �Ѿ��� �߻��ϴ� ����� ����̴ϴ�

        Destroy(gameObject, 3f);

        playerTransform = GameObject.Find("Player").transform;
        caulateDirection = (playerTransform.position - transform.position).normalized;
    }
    // �Ѿ��� �ı��Ǿ���� ��ġ�� �� �Լ��� ��������ָ�˴ϴ�
    private void OnDestroy()
    {
        
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
        // ���� �÷��̾ �浹������ �÷��̾��� ���� �ִϸ��̼��� �����Ű�� ����� �����.

        //���� ������Ʈ Tag ���.
        
            if (collision.gameObject.CompareTag("Player"))
            {
                Debug.Log($"�浹�� ������Ʈ�� �̸� :{collision.gameObject.name}");
            // �÷��̾��� ü���� ����߸��� ���.
            // �Ѿ��� �¾����� �ٷ� ���ӿ��� ���.
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
