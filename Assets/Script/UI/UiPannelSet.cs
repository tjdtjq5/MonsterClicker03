using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPannelSet : MonoBehaviour
{
    public GameObject infoPannel;
    public GameObject messagePannel;
    public GameObject blogPannel;
    public GameObject albaPannel;
    public GameObject mapPannel;
    public GameObject showpingPannel;

    [Header("토리")]
    public GameObject ui_rabbit;

    Vector3 originPos;
    Vector3 tempPos;

    private void Start()
    {
        

        originPos = infoPannel.transform.position;
        tempPos = messagePannel.transform.position;
    }


    public void OnClickInfoPannel()
    {
        if(infoPannel.transform.position == originPos)
        {
            return;
        }
        infoPannel.transform.position = originPos;
        messagePannel.transform.position = tempPos;
        blogPannel.transform.position = tempPos;
        albaPannel.transform.position = tempPos;
        mapPannel.transform.position = tempPos;
        showpingPannel.transform.position = tempPos;

        infoPannel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("True");
        ui_rabbit.SetActive(true);
    }
    public void OnClickMessagePannel()
    {
        if (messagePannel.transform.position == originPos)
        {
            return;
        }
        infoPannel.transform.position = tempPos;
        messagePannel.transform.position = originPos;
        blogPannel.transform.position = tempPos;
        albaPannel.transform.position = tempPos;
        mapPannel.transform.position = tempPos;
        showpingPannel.transform.position = tempPos;

        messagePannel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("True");
        ui_rabbit.SetActive(false);
    }
    public void OnClickBlogPannel()
    {
        if (blogPannel.transform.position == originPos)
        {
            return;
        }
        infoPannel.transform.position = tempPos;
        messagePannel.transform.position = tempPos;
        blogPannel.transform.position = originPos;
        albaPannel.transform.position = tempPos;
        mapPannel.transform.position = tempPos;
        showpingPannel.transform.position = tempPos;

        blogPannel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("True");
        ui_rabbit.SetActive(false);
    }
    public void OnClickAlbaPannel()
    {
        if (albaPannel.transform.position == originPos)
        {
            return;
        }
        infoPannel.transform.position = tempPos;
        messagePannel.transform.position = tempPos;
        blogPannel.transform.position = tempPos;
        albaPannel.transform.position = originPos;
        mapPannel.transform.position = tempPos;
        showpingPannel.transform.position = tempPos;

        albaPannel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("True");
        ui_rabbit.SetActive(false);
    }

    public void OnClickMapPannel()
    {
        if (mapPannel.transform.position == originPos)
        {
            return;
        }
        infoPannel.transform.position = tempPos;
        messagePannel.transform.position = tempPos;
        blogPannel.transform.position = tempPos;
        albaPannel.transform.position = tempPos;
        mapPannel.transform.position = originPos;
        showpingPannel.transform.position = tempPos;

        mapPannel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("True");
        ui_rabbit.SetActive(false);
    }
    public void OnClickShowpingPannel()
    {
        if (showpingPannel.transform.position == originPos)
        {
            return;
        }
        infoPannel.transform.position = tempPos;
        messagePannel.transform.position = tempPos;
        blogPannel.transform.position = tempPos;
        albaPannel.transform.position = tempPos;
        mapPannel.transform.position = tempPos;
        showpingPannel.transform.position = originPos;

        showpingPannel.transform.GetChild(0).GetComponent<Animator>().SetTrigger("True");
        ui_rabbit.SetActive(false);
    }

}
