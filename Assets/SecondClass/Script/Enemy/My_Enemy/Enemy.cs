using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("�� �ǰ� ���ϸ��̼� ���� ����")]
    public float hitBackTime = 0.5f; // �ǰ� ȿ�� �߻� �� ���� ���·� ���ư��� �ð�
    public int hitCount = 0;
    public int currentHp;
    public int maxHP = 3;
    private SkinnedMeshRenderer skinnedMeshRenderer; //�ǰݽ� ���� �������ֱ� ���� ��¡ ������ �����ϴ� ����
    private bool isDeath;
    private NavMeshAgent agent;

    [Header("��ã�� ���� ����")]
    public Transform target;
    [Header("������ �ൿ ���� ����")]
    public float findDistance; 
    public float attackRange; //  ���� ���� ���� Ÿ���� ������ ������ �Ѵ�.
    private float distance; // targer�� ���� �Ÿ��� �����ϴ� ����

    // ���Ͱ� �÷��̾�� ���ݹ޾����� ������ �Դ� �ִϸ��̼� ����
    [Header("�ִϸ��̼� ������ ���� �ʿ��� ����")]
    
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
        //�÷��̾ Ž���ϴ� ��� - Ž���ִ� �Ÿ� ���� �÷��̾ �ִ°�?

        target = FindObjectOfType<PlayerController>().gameObject.transform;

        if (findDistance >= Vector3.Distance(transform.position, target.position))
        {
            Debug.Log(Vector3.Distance(transform.position, target.position));
            agent.SetDestination(target.position);//�÷��̾ �Ѵ� ���
        }


        // ���� ���� ��� - Ÿ�ݰ���
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
        //���� �����ϴ� �����϶� takeDamage �Լ��� �����Ű�� �ʰԤ���
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
