using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //우리가 선택한 애니메이션
    Animator animator;
    public enum PlayerState { Idle, Run, Death}
    PlayerState playerstate;

    public bool IsPlayerDeath = false;
    

    // Start is called before the first frame update


    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerDeath == true) return;
        SetPlayerState(); 
        SetPlayerAnimation();
    }

    void Initialize()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void PlayerMove()
    {
        animator.SetBool("IsRun", true);
    }
    public void PlayerIdle()
    {
        animator.SetBool("IsRun", false);
    }
    public void PlayerDeath()
    {
        if (IsPlayerDeath == true) return;
        //if (animator == null) return;
        //animator.SetTrigger("death");

        animator?.SetTrigger("Death");
        IsPlayerDeath = true;
    }

    //게임에서 애니메이션을 실행시키기 위해 Update문 선언할 함수이다 
    //플레이어의 상태에따라 다른 애니메이션을 실행해야하는데
    // 그 조건을 판단해주는 함수입니다
    private void SetPlayerAnimation()
    {
        if(playerstate == PlayerState.Idle)
        {
            PlayerIdle();
        }
        else if (playerstate == PlayerState.Run)
        {
            PlayerMove();
        }
    }
    // 현재 나의 상태를 판별해주는 함수
    private void SetPlayerState()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v != 0 || h != 0)
        {
            playerstate = PlayerState.Run;
        }
        else
        {
            playerstate = PlayerState.Idle;
        }
    }
}
