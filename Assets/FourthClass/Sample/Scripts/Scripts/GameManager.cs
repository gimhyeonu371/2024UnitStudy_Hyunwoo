    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    #region �̱��� ����
    // single : Ŭ������ �Ѱ��� �����ϵ��� �����ϰ� �̸� �����ؼ�
    // �ٸ�Ŭ�������� �� Ŭ������ �ҷ��ͼ� ����Ҽ��ְ��Ѵ�

    // ����� ������ ���� : �̱��� ������ �ʹ� ���� ������� ����
    // �ϳ��� Ŭ������ �ʹ� ���� �����͸� ��ԵǴ� ������ ������
    //static �̱����� �����ϴµ� ������ ����ɋ����� �޸𸮰�
    //��� ���� �ִ� �������� �ֽ��ϴ�


    //������ ���� Ŭ�������� ���� ���踦 �� �� �ִ� ����(��� ����)�� ���س���
    //�� ����� ���� ���鵵�� �ϰ� �Ѱ�
    //�⺻���� �����ϴ� ���
    private static Gamemanager instance;

    public static Gamemanager Instance
    {
        get
        {
            if( null == instance)
            {
                instance = new Gamemanager();
            }

            return instance;
        }
    }
    // void Awake() �Լ��� ��� Ŭ������ void Start() ���� ���� ����˴ϴ�
    private void Awake()
    {
        if(null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // static�� ������ ������ Ŭ���� �̸����� �ٷ� ������ �� �ִ� ������ �ֽ��ϴ�.
    //�� ��� ������ static �� ������ ���� �������?
    // GameManager�ȿ� �ִ� ���  static�� ����� ������ �������� �˰��־���մϴ�
    // static���� ������ ������ ���α׷��� ����ɋ����� ���� �ֽ��ϴ�.


    public bool IsplayerDeath;


    //static Ŭ���� ȣ��. �ν��Ͻ� ȣ��


    #endregion

    public GameObject[] gameOverObjects;

    private void SetGameSetting()
    {
        IsplayerDeath = false;

        gameOverObjects[0] = GameObject.Find("BackGround");
        gameOverObjects[0] = GameObject.Find("GameOver");

        // �ð� ���� ������ 0���� �ʱ�ȭ�ϴ� ����
    }
    public void GameOver()
    {
        foreach(GameObject obj in gameOverObjects)
        {
            obj.SetActive(true);
        }
    }
    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    public void GmaeRestart()
    {
        //�̸��� ��Ȯ���� ������ ������ �߻��մϴ�.
        //���� �ٿ��ֱ�� �� �̸��� �����ɴϴ�.
        SetGameSetting();
        SceneManager.LoadScene("SampleScene");
    }
 }