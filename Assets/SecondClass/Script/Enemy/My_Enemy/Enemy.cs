using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("적 피격 에니메이셔 제어 변수")]
    public float hitBackTime = 0.5f; // 피격 효과 발생 후 원래 상태로 돌아가는 시간
    public int hitCount = 0;
    public int currentHp;
    public int maxHP = 3;
    private SkinnedMeshRenderer skinnedMeshRenderer; //피격시 색상 변경해주기 위한 재징 정보를 저장하는 변수
    private bool isDeath;
    private NavMeshAgent agent;

    [Header("길찾기 제어 변수")]
    public Transform target;
    [Header("몬스터의 행동 제어 변수")]
    public float findDistance; 
    public float attackRange; //  공격 범위 내에 타겟이 있으면 공격을 한다.
    private float distance; // targer과 나의 거리를 저장하는 변수

    // 몬스터가 플레이어에게 공격받았을때 데미지 입는 애니메이션 실행
    [Header("애니메이션 실행을 위해 필요한 변수")]
    
    private Animator anim;


    private readonly string takeDamageAnimationName = "IsHit";
    private readonly string DeathAnimationName = "doDeath";

    private void Awake()
    {
        LoadComponent();
    }
    private void LoadComponent()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    public void Update()
    {
        //플레이어를 탐색하는 기능 - 탐색최대 거리 내에 플레이어가 있는가?

        target = FindObjectOfType<PlayerController>().gameObject.transform;

        if (findDistance >= Vector3.Distance(transform.position, target.position))
        {
            Debug.Log(Vector3.Distance(transform.position, target.position));
            agent.SetDestination(target.position);//플레이어를 쫓는 기능
        }


        // 적의 공격 기능 - 타격공격
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);

        Gizmos.DrawWireSphere(transform.position,findDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    public void TakeDamage()
    {
        //죽음 상태하는 조건일때 takeDamage 함수를 실행시키지 않게ㅆ다
        if (isDeath) return;
        hitCount++;
        anim.SetBool(takeDamageAnimationName, true);
        StartCoroutine(TakeDamageEffect());
        if (hitCount >= maxHP)
        {
            hitCount = 0;
            OnDeath();
        }
    }
    IEnumerator TakeDamageEffect()
    {               
        ShakeCamera.Instance.OnShakeCamera(0.2f, 0.15f);
        skinnedMeshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(hitBackTime);
        skinnedMeshRenderer.material.color = Color.white;

        anim.SetBool(takeDamageAnimationName, false);
    }
    private void OnDeath()
    {
        isDeath = true;
        anim.SetTrigger(DeathAnimationName);
        
    }
    public void DeatroyGameObject()
    {
        Destroy(gameObject);        
    }
}
