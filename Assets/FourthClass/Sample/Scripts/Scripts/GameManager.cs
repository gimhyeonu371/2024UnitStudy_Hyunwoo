    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    #region 싱글톤 패턴
    // single : 클래스를 한개만 존재하도록 구성하고 이를 참조해서
    // 다른클래스에서 이 클래스를 불러와서 사용할수있게한다

    // 상글톤 패턴의 목적 : 싱글톤 패턴을 너무 많이 사용하지 말라
    // 하나의 클래스에 너무 많은 데이터를 담게되는 단점이 있으며
    //static 싱글톤을 구현하는데 게임이 종료될떄까지 메모리가
    //계속 남아 있는 문제점이 있습니다


    //디자인 패턴 클래스간의 좋은 성계를 할 수 있는 관계(상속 관계)를 정해놓고
    //그 방식을 따라서 만들도록 하게 한것
    //기본문법 선언하는 방법
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
    // void Awake() 함수는 모든 클래스의 void Start() 보다 먼저 실행됩니다
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

    // static로 선언한 변수는 클래스 이름으로 바로 접근할 수 있는 장점이 있습니다.
    //왜 모든 변수를 static 로 선언을 하지 않을까요?
    // GameManager안에 있는 모든  static로 선언된 변수가 무엇인지 알고있어야합니다
    // static으로 선언한 변수는 프로그램이 종료될떄까지 남아 있습니다.


    public bool IsplayerDeath;


    //static 클래스 호출. 인스턴스 호출


    #endregion

    public GameObject[] gameOverObjects;

    private void SetGameSetting()
    {
        IsplayerDeath = false;

        gameOverObjects[0] = GameObject.Find("BackGround");
        gameOverObjects[0] = GameObject.Find("GameOver");

        // 시간 같은 변수도 0으로 초기화하는 예시
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
        //이름이 정확하지 않으면 에러가 발생합니다.
        //복사 붙여넣기로 씬 이름을 가져옵니다.
        SetGameSetting();
        SceneManager.LoadScene("SampleScene");
    }
 }