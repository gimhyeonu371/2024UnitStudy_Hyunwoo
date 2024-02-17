using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    //회전하는 기능을 구현해볼겁니다.

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
        // A키와 D카룰 입력해ㅛ을때 해당 방향으로 회전하는 기능을 구현
        //입력 구현 
        float horizontal = Input.GetAxis("Horizontal");//-1 ~1값을 반환해주는기능
        //회전구현 -> 어느방향으로 구현

        float yaw = horizontal * rotateSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yaw, Space.World);//절대좌표와 상대좌표

    }
}
