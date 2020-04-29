using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemBagManager : MonoBehaviour
{
    [Header("BlackPannel")]
    public GameObject blackPannel;
    public GameObject itemPannel;
    [Header("ItemPannel")]
    public GameObject[] itemPannels;
    [Header("ArrowBtn")]
    public GameObject rightBtn;
    public GameObject leftBtn;
    [Header("Fade_Ani")]
    public GameObject fade_ani_obj;

    int current_page;

    public void OnClickBag()
    {
        blackPannel.SetActive(true);
        itemPannel.SetActive(true);
        current_page = 0;
        SetActivePannel();
    }
    public void ExitBag()
    {
        itemPannel.SetActive(false);
        blackPannel.SetActive(false);
    }
    void SetActivePannel()
    {
        for (int i = 0; i < itemPannels.Length; i++)
        {
            if(i == current_page)
                itemPannels[i].SetActive(true);
            else
                itemPannels[i].SetActive(false);
        }
    }

    
    bool flag;
    public void OnClickRight()
    {
        if (current_page == itemPannels.Length - 1)
            return;
        if (flag)
            return;
   
        flag = true;
        fade_ani_obj.SetActive(true);
        fade_ani_obj.GetComponent<Image>().DOFade(255, 0.5f);
        current_page++;
        SetActivePannel();
        fade_ani_obj.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(()=> {
            flag = false;
            fade_ani_obj.SetActive(false);
        });
    }
 
    public void OnClickLeft()
    {
        if (current_page == 0)
            return;
        if (flag)
            return;

        flag = true;
        fade_ani_obj.SetActive(true);
        fade_ani_obj.GetComponent<Image>().DOFade(255, 0.5f);
        current_page--;
        SetActivePannel();
        fade_ani_obj.GetComponent<Image>().DOFade(0, 0.5f).OnComplete(() => {
            flag = false;
            fade_ani_obj.SetActive(false);
        });
    }

}
