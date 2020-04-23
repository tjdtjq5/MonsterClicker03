using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loding : MonoBehaviour
{
    public string nextScene;
    public Slider progressbar;
    public Text loadtext;

    [Header("로딩 캐릭터")]
    public GameObject player;
    public GameObject poketmonster;

    public void Start()
    {
        player.GetComponent<Animator>().SetBool("isMove", true);
        LoadScene();
    }



    public void LoadScene()
    {
        progressbar.gameObject.SetActive(true);
        loadtext.gameObject.SetActive(true);
        StartCoroutine(LoadSceneCoroutine());
    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextScene);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;

            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }



            if (progressbar.value >= 1f)
            {
                loadtext.text = "Touch Down";
            }

            if (Input.GetMouseButtonDown(0) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }

    }
}
