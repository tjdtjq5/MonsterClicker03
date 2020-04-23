using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Home : MonoBehaviour
{
    public GameObject blackPannel;
    public GameObject homePannel;
    public NextScene nextScene;

    public void OnClickHomeBtn()
    {
        blackPannel.SetActive(true);
        homePannel.SetActive(true);
    }

    public void OnClickExit()
    {
        blackPannel.SetActive(false);
        homePannel.SetActive(false);
    }

    public void OnClickNextScene()
    {
        SceneManager.LoadScene("Main");
        //nextScene.OnNextScene("Main");
    }

}
