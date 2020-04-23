using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject blackBackground;
    public GameObject stagePannel;
    bool flag;
    public void OnClickStage01()
    {
        StartCoroutine(OnClickStage01Coroutine());
    }

    IEnumerator OnClickStage01Coroutine()
    {
        flag = true;
        blackBackground.SetActive(true);
        stagePannel.SetActive(true);
        stagePannel.GetComponent<Animator>().SetTrigger("True");
        yield return new WaitForSeconds(0.6f);
        flag = false;
    }

    public void OnClickExit()
    {
        StartCoroutine(OnClickExitCoroutine());
    }
    IEnumerator OnClickExitCoroutine()
    {
        stagePannel.GetComponent<Animator>().SetTrigger("False");
        yield return new WaitForSeconds(0.6f);
        stagePannel.SetActive(false);
        blackBackground.SetActive(false);
    }
}
