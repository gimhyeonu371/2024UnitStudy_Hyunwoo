using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    //ȸ���ϴ� ����� �����غ��̴ϴ�.

    public float rotateSpeed = 2000f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayr();  
    }

    private void RotatePlayr()
    {
        // AŰ�� Dī�� �Է��ؤ����� �ش� �������� ȸ���ϴ� ����� ����
        //�Է� ���� 
        float horizontal = Input.GetAxis("Horizontal");//-1 ~1���� ��ȯ���ִ±��
        //ȸ������ -> ����������� ����

        float yaw = horizontal * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw, Space.World);//������ǥ�� �����ǥ

    }
}
