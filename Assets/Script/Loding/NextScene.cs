using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [Header("이미지")]
    public GameObject outImage;
    public GameObject inImage;
    [Header("첫 시작시 out 이펙트 활성화 여부")]
    public bool isOutStart;
    public static bool isStart;
    [Header("다음 씬 이동 이름")]
    public string sceneName;

    void Start()
    {
        if (isOutStart)
            isStart = true;
        else
            isStart = false;

        if (isStart)
        {
            OnOutPannel();
        }
    }

    public void OnNextScene()
    {
        StartCoroutine(NextSceneCoroutine());
    }

   IEnumerator NextSceneCoroutine()
    {
        inImage.SetActive(true);
        inImage.GetComponent<Animator>().SetTrigger("In");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void OnOutPannel()
    {
        StartCoroutine(OnOutPannelCoroutine());
    }
    IEnumerator OnOutPannelCoroutine()
    {
        outImage.SetActive(true);
        outImage.GetComponent<Animator>().SetTrigger("Out");
        yield return new WaitForSeconds(1.8f);
        outImage.gameObject.SetActive(false);
    }



}
