using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    static string nextScene;
    public Image proGressBar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
       // {
           // proGressBar.fillAmount +=0.1f;
       // }
    }

    // ȣ��� ���� �̸��� �Ű������� �޾ƿͼ� nextScene�� �����Ѵ�
    public static void LoadScene(string SceneName)
    {
        nextScene = SceneName ;
        // �� �ε� ���� �����Ѵ�.
        SceneManager.LoadScene("NewLoadingScene");
    }

    IEnumerator LoadSceneProcess()
    {
        //  yield return ���� �ڵ带 �����ϰ� ���� 0.3�� ��ٷ���
        yield return new WaitForSeconds(0.3f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;// ���� ������ ���� �ڵ����� �ش������ �̵���ų���� true ��� false

        float timer = 0f;
        while (!operation.isDone)
        {
            yield return null;

            if(operation.progress < 0.9f)
            {
                proGressBar.fillAmount = operation.progress;
            }

            else
            {
                timer += Time.unscaledTime;
                proGressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if (proGressBar.fillAmount >= 1f)
                {
                    yield return new WaitForSeconds(1.7f);
                    operation.allowSceneActivation = true;
                }
                yield return null;
            }
        }
    }
}
