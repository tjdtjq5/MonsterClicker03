using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemBagManager : MonoBehaviour
{
    [Header("Camera")]
    public GameObject cam_main;
    public GameObject cam_ui;

    [Header("Item_bag")]
    public GameObject Item_obj;

    [Header("theCam_rotation")]
    public Transform theCam_rotation;
    public float sensibility;

    [Header("Eqip_btn")]
    public GameObject[] eqip_btn;

    [Header("Player_Info")]
    public Transform player_info;

    [Header("Pannel")]
    Vector2 pannel_position;
    Vector2 null_position;
    public Transform eqip_pannel;
    public Transform skill_pannel;
    public Transform etc_pannel;

    [Header("Etc...")]
    public GameObject click_image;
    public GameObject eqip_name;
    public GameObject skill_name;
    public GameObject food_name;
    int pannel_num;

    [Header("Blackpannel")]
    public GameObject blackpannel;
    public GameObject eqip_info;
    /// <summary>
    /// 
    /// </summary>
    /// 
    User_Eqip_Info select_eqip_item;

    private void Start()
    {
        pannel_position = eqip_pannel.localPosition;
        null_position = skill_pannel.localPosition;
    }

    public void OnClick_itembag()
    {
        cam_main.SetActive(false);
        cam_ui.SetActive(false);
        Item_obj.SetActive(true);

        pannel_num = 0;
        OnClickEqip();

        Set_Player_Info();
    }

    bool first_touch_flag;
    Vector2 first_touch_pos;

    bool touch_on_flag;
    public void Screen_Touch_On()
    {
        if (!touch_on_flag)
        {
            touch_on_flag = true;
            first_touch_flag = true;
            first_touch_pos = Input.mousePosition;
        }
    }

    public void Screen_Touch_Exit()
    {
        StartCoroutine(Screen_Touch_Exit_Coroutine());
    }

    IEnumerator Screen_Touch_Exit_Coroutine()
    {
        first_touch_flag = false;
        theCam_rotation.DOLocalRotate(Vector3.zero, 0.5f);
        yield return new WaitForSeconds(0.5f);
        touch_on_flag = false;
    }

    public void OnClickExit()
    {
        cam_main.SetActive(true);
        cam_ui.SetActive(true);
        Item_obj.SetActive(false);
    }


    //아이템 아이콘 클릭 

    public void Update()
    {
        if (first_touch_flag)
        {
            float temp_x = Input.mousePosition.x - first_touch_pos.x;
            float temp_y = Input.mousePosition.y - first_touch_pos.y;

            if (temp_y > 0)
                temp_y = 0;

            theCam_rotation.localRotation = Quaternion.Euler(theCam_rotation.localRotation.x + temp_y * sensibility, theCam_rotation.localRotation.y + temp_x * sensibility, theCam_rotation.localRotation.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 10f);
            if (hit)
            {
                string name = hit.transform.gameObject.name;
                if (name.Contains("아이템_칸"))
                {
                    string temp_num = name.Split('(')[1];
                    int num = int.Parse(temp_num.Split(')')[0]);

                    if(num < GameManager.instance.userInfo.player_eqip_list.Count)
                    {
                        Set_ItemClick(eqip_pannel, num);

                        select_eqip_item = GameManager.instance.userInfo.player_eqip_list[num];
                        Eqip_Info();
                    }
                }
            }
        }
    }

    void Set_ItemClick(Transform pannel , int num)
    {
        if (click_flag)
            return;

        click_image.SetActive(false);
        click_image.SetActive(true);
        ClickCoroutine = Click_Image_Coroutine(pannel, num);
        StartCoroutine(ClickCoroutine);
    }
    IEnumerator ClickCoroutine;

    bool click_flag;
    IEnumerator Click_Image_Coroutine(Transform pannel ,int num)
    {
        click_flag = true;
        click_image.transform.position = pannel.GetChild(num).transform.position;
        click_image.GetComponent<Animator>().SetBool("click", true);
        yield return new WaitForSeconds(0.25f);
        click_image.GetComponent<Animator>().SetBool("click", false);
        click_flag = false;
    }

    void Set_Player_Info()
    {
        player_info.Find("atk").GetChild(0).GetComponent<Text>().text = GameManager.instance.GetAtk(GameManager.instance.userInfo.GetLevel(), GameManager.instance.userInfo.GetEnhance(EnhanceKind.atkEnhance)).ToString();
        player_info.Find("shield").GetChild(0).GetComponent<Text>().text = "" + GameManager.instance.GetSheild(); 
        player_info.Find("hp").GetChild(0).GetComponent<Text>().text = "" + GameManager.instance.GetHp(GameManager.instance.userInfo.GetLevel(), GameManager.instance.userInfo.GetEnhance(EnhanceKind.hpEnhance));
        player_info.Find("critical").GetChild(0).GetComponent<Text>().text = "" + GameManager.instance.GetCritical();
        player_info.Find("atkspeed").GetChild(0).GetComponent<Text>().text = "" + GameManager.instance.GetAtkSpeed();
        player_info.Find("speed").GetChild(0).GetComponent<Text>().text = "" + GameManager.instance.GetSpeed();
    }

    [Header("잠금 이미지")]
    public Sprite look_image;
    void OnClickEqip()
    {
        for (int i = 0; i < GameManager.instance.userInfo.bag_num; i++)
        {
            eqip_pannel.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }
        for (int i = GameManager.instance.userInfo.bag_num; i < eqip_pannel.childCount; i++)
        {
            eqip_pannel.GetChild(i).GetChild(0).gameObject.SetActive(true);
            eqip_pannel.GetChild(i).GetChild(0).GetComponent<Image>().sprite = look_image;
        }

        eqip_btn[0].transform.GetChild(0).gameObject.SetActive(false);
        eqip_btn[1].transform.GetChild(0).gameObject.SetActive(false);

        for (int i = 0; i < GameManager.instance.userInfo.player_eqip_list.Count; i++)
        {
            eqip_pannel.GetChild(i).GetChild(0).gameObject.SetActive(true);
            eqip_pannel.GetChild(i).GetChild(0).GetComponent<Image>().sprite =
                GameManager.instance.itemManager.WhatEqip(GameManager.instance.userInfo.player_eqip_list[i].eqip).eqip_image;
            if (GameManager.instance.userInfo.player_eqip_list[i].isEqip == true)
            {
                if (GameManager.instance.itemManager.WhatEqip(GameManager.instance.userInfo.player_eqip_list[i].eqip).eqip_kind == true)
                {
                    eqip_btn[0].transform.GetChild(0).gameObject.SetActive(true);
                    eqip_btn[0].transform.GetChild(0).GetComponent<Image>().sprite = GameManager.instance.itemManager.WhatEqip(GameManager.instance.userInfo.player_eqip_list[i].eqip).eqip_image;
                }
                else
                {
                    eqip_btn[1].transform.GetChild(0).gameObject.SetActive(true);
                    eqip_btn[1].transform.GetChild(0).GetComponent<Image>().sprite = GameManager.instance.itemManager.WhatEqip(GameManager.instance.userInfo.player_eqip_list[i].eqip).eqip_image;
                }
                eqip_pannel.GetChild(i).Find("장착중_텍스트").gameObject.SetActive(true);

            }
            else
                eqip_pannel.GetChild(i).Find("장착중_텍스트").gameObject.SetActive(false);
        }

        click_image.transform.position = new Vector2(3000, 3000);
        eqip_pannel.localPosition = pannel_position;
        skill_pannel.localPosition = null_position;
        etc_pannel.localPosition = null_position;

        eqip_name.SetActive(true);
        skill_name.SetActive(false);
        food_name.SetActive(false);
    }

    void OnClickSkill()
    {
        click_image.transform.position = new Vector2(3000, 3000);
        eqip_pannel.localPosition = null_position;
        skill_pannel.localPosition = pannel_position;
        etc_pannel.localPosition = null_position;

        eqip_name.SetActive(false);
        skill_name.SetActive(true);
        food_name.SetActive(false);
    }

    void OnClickEtc()
    {
        click_image.transform.position = new Vector2(3000, 3000);
        eqip_pannel.localPosition = null_position;
        skill_pannel.localPosition = null_position;
        etc_pannel.localPosition = pannel_position;

        eqip_name.SetActive(false);
        skill_name.SetActive(false);
        food_name.SetActive(true);
    }

    public void OnClick_RightArrow()
    {
        pannel_num++;

        if (pannel_num == 3)
            pannel_num = 0;

        switch (pannel_num)
        {
            case 0:
                OnClickEqip();
                break;
            case 1:
                OnClickSkill();
                break;
            case 2:
                OnClickEtc();
                break;
        }
    }
    public void OnClick_LeftArrow()
    {
        pannel_num--;

        if (pannel_num == -1)
            pannel_num = 2;

        switch (pannel_num)
        {
            case 0:
                OnClickEqip();
                break;
            case 1:
                OnClickSkill();
                break;
            case 2:
                OnClickEtc();
                break;
        }
    }

    ///
    /// blackpannel - eqip_info
    ///
    public void OnClick_Eqip_Info_Exit() // 정보창 나가기 
    {
        eqip_info.SetActive(false);
        blackpannel.SetActive(false);
    }

    public void Eqip_Info() // 정보창 띄우기 
    {
        blackpannel.SetActive(true);
        eqip_info.SetActive(true);

        eqip_info.transform.Find("item_name").GetComponent<Text>().text = GameManager.instance.itemManager.WhatEqip(select_eqip_item.eqip).eqip_Name;
        eqip_info.transform.Find("item_image").GetChild(0).GetComponent<Image>().sprite = GameManager.instance.itemManager.WhatEqip(select_eqip_item.eqip).eqip_image;
    }

    public void Eqipment()
    {
        GameManager.instance.userInfo.Eqipment(select_eqip_item);
        OnClickEqip();
    }
}
