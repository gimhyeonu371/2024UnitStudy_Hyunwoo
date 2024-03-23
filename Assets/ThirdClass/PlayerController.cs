using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //�츮�� ������ �ִϸ��̼�
    Animator animator;
    public enum PlayerState { Idle, Run, Death, Attack01 }
    PlayerState playerstate;

    public BoxCollider HitCheckBox;

    // Start is called before the first frame update


    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.Instance.IsplayerDeath == true) return;
        SetPlayerState();

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AttackCoroutine());
        }

        SetPlayerAnimation();
    }

    IEnumerator AttackCoroutine()
    {
        HitCheckBox.enabled = true;
        animator.SetTrigger("doAttack");
        yield return new WaitForSeconds(0.5f);

        HitCheckBox.enabled = false;

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
        if (Gamemanager.Instance.IsplayerDeath == true) return;
        Gamemanager.Instance.GameOver();
        //if (animator == null) return;
        //animator.SetTrigger("death");

        animator?.SetTrigger("Death");
        Gamemanager.Instance.IsplayerDeath = true;
    }

    //���ӿ��� �ִϸ��̼��� �����Ű�� ���� Update�� ������ �Լ��̴� 
    //�÷��̾��� ���¿����� �ٸ� �ִϸ��̼��� �����ؾ��ϴµ�
    // �� ������ �Ǵ����ִ� �Լ��Դϴ�
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
        else if(playerstate == PlayerState.Attack01)
        {
            animator.SetTrigger("doAttack");
        }
    }
    // ���� ���� ���¸� �Ǻ����ִ� �Լ�
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
