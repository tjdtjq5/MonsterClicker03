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

    [Header("Grade")]
    public Sprite[] grade_image;

    [Header("Etc...")]
    public GameObject click_image;
    public GameObject eqip_name;
    public GameObject skill_name;
    public GameObject food_name;
    int pannel_num;

    [Header("Blackpannel_장비")]
    public GameObject blackpannel;
    public GameObject eqip_info;
    public GameObject Enhace_info;
    public GameObject sell;

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

    }

    //아이템 아이콘 클릭 
    public void ItemCellBtn(int num)
    {
        if (num < GameManager.instance.userInfo.player_eqip_list.Count)
        {
            Set_ItemClick(eqip_pannel, num);
            select_eqip_item = GameManager.instance.userInfo.player_eqip_list[num];
            Eqip_Info();
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
        player_info.Find("critical").GetChild(0).GetComponent<Text>().text = "" + GameManager.instance.GetCritical() + "%";
        player_info.Find("atkspeed").GetChild(0).GetComponent<Text>().text = "" + System.Math.Truncate(GameManager.instance.GetAtkSpeed() * 100) / 100 + "S";
        player_info.Find("speed").GetChild(0).GetComponent<Text>().text = "" + System.Math.Truncate(GameManager.instance.GetSpeed() * 100) / 100 + "S";
    }

    [Header("잠금 이미지")]
    public Sprite lock_image;
    void OnClickEqip()
    {
        for (int i = 0; i < GameManager.instance.userInfo.bag_num; i++)
        {
            eqip_pannel.GetChild(i).GetComponent<Image>().sprite = grade_image[0];
            eqip_pannel.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }
        for (int i = GameManager.instance.userInfo.bag_num; i < eqip_pannel.childCount; i++)
        {
            eqip_pannel.GetChild(i).GetComponent<Image>().sprite = grade_image[0];
            eqip_pannel.GetChild(i).GetChild(0).gameObject.SetActive(true);
            eqip_pannel.GetChild(i).GetChild(0).GetComponent<Image>().sprite = lock_image;
        }

        eqip_btn[0].transform.GetChild(0).gameObject.SetActive(false);
        eqip_btn[1].transform.GetChild(0).gameObject.SetActive(false);

        for (int i = 0; i < GameManager.instance.userInfo.player_eqip_list.Count; i++)
        {
            
            switch (GameManager.instance.itemManager.WhatEqip(GameManager.instance.userInfo.player_eqip_list[i].eqip).grade)
            {
                case "Normal":
                    eqip_pannel.GetChild(i).GetComponent<Image>().sprite = grade_image[0];
                    break;
                case "Rare":
                    eqip_pannel.GetChild(i).GetComponent<Image>().sprite = grade_image[1];
                    break;
                case "Unique":
                    eqip_pannel.GetChild(i).GetComponent<Image>().sprite = grade_image[2];
                    break;
                case "Epic":
                    eqip_pannel.GetChild(i).GetComponent<Image>().sprite = grade_image[3];
                    break;
                case "Legend":
                    eqip_pannel.GetChild(i).GetComponent<Image>().sprite = grade_image[4];
                    break;
            }
            // 이미지
            eqip_pannel.GetChild(i).GetChild(0).gameObject.SetActive(true); 
            eqip_pannel.GetChild(i).GetChild(0).GetComponent<Image>().sprite =
                GameManager.instance.itemManager.WhatEqip(GameManager.instance.userInfo.player_eqip_list[i].eqip).eqip_image;
            // 강화 정도
            eqip_pannel.GetChild(i).GetChild(1).GetChild(0).GetComponent<Text>().text = "+" + GameManager.instance.userInfo.player_eqip_list[i].enhance;

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
        if (enhance_coroutine_flag)
            return;

        eqip_info.SetActive(false);
        SellExit();
        OnClick_Enhace_Exit();
        eqip_info_flag = false;
        blackpannel.SetActive(false);
    }

    bool eqip_info_flag;
    public void Eqip_Info() // 정보창 띄우기 
    {
        eqip_info_flag = true;
        blackpannel.SetActive(true);
        eqip_info.SetActive(true);

        eqip_info.transform.Find("item_name").GetChild(0).GetComponent<Text>().text = select_eqip_item.prefix + " " + GameManager.instance.itemManager.WhatEqip(select_eqip_item.eqip).eqip_Name;
        switch (GameManager.instance.itemManager.WhatEqip(select_eqip_item.eqip).grade)
        {
            case "Normal":
                eqip_info.transform.Find("item_image").GetComponent<Image>().sprite = grade_image[0];
                break;
            case "Rare":
                eqip_info.transform.Find("item_image").GetComponent<Image>().sprite = grade_image[1];
                break;
            case "Unique":
                eqip_info.transform.Find("item_image").GetComponent<Image>().sprite = grade_image[2];
                break;
            case "Epic":
                eqip_info.transform.Find("item_image").GetComponent<Image>().sprite = grade_image[3];
                break;
            case "Legend":
                eqip_info.transform.Find("item_image").GetComponent<Image>().sprite = grade_image[4];
                break;
        }
        eqip_info.transform.Find("item_image").GetChild(0).GetComponent<Image>().sprite = GameManager.instance.itemManager.WhatEqip(select_eqip_item.eqip).eqip_image;
        eqip_info.transform.Find("item_image").GetChild(1).GetChild(0).GetComponent<Text>().text = "+" + select_eqip_item.enhance;
        eqip_info.transform.Find("item_info").GetChild(1).GetComponent<Text>().text =
             select_eqip_item.Atk() + "\n" + select_eqip_item.Critical() + "%\n" + select_eqip_item.Shield() + "\n" + select_eqip_item.Hp() + "\n" + select_eqip_item.AtkSpeed() + "S\n" + select_eqip_item.Speed() + "S";
    }

    public void Eqipment()
    {
        GameManager.instance.userInfo.Eqipment(select_eqip_item);
        OnClickEqip();
        Set_Player_Info(); 
    }

    int enhance_money;
    public void OnClickEnhance()
    {
        Enhace_info.SetActive(true);
        switch (GameManager.instance.itemManager.WhatEqip(select_eqip_item.eqip).grade)
        {
            case "Normal":
                Enhace_info.transform.Find("아이템이미지").Find("아이템").GetComponent<Image>().sprite = grade_image[0];
                break;
            case "Rare":
                Enhace_info.transform.Find("아이템이미지").Find("아이템").GetComponent<Image>().sprite = grade_image[1];
                break;
            case "Unique":
                Enhace_info.transform.Find("아이템이미지").Find("아이템").GetComponent<Image>().sprite = grade_image[2];
                break;
            case "Epic":
                Enhace_info.transform.Find("아이템이미지").Find("아이템").GetComponent<Image>().sprite = grade_image[3];
                break;
            case "Legend":
                Enhace_info.transform.Find("아이템이미지").Find("아이템").GetComponent<Image>().sprite = grade_image[4];
                break;
        }
        Enhace_info.transform.Find("아이템이미지").Find("아이템").Find("아이템이미지").GetComponent<Image>().sprite = GameManager.instance.itemManager.WhatEqip(select_eqip_item.eqip).eqip_image;

        if(select_eqip_item.enhance >= 15)
        {
            Enhace_info.transform.Find("아이템이미지").Find("아이템").Find("강화정도").GetChild(0).GetComponent<Text>().text = "+" + (select_eqip_item.enhance);
            Enhace_info.transform.Find("아이템정보").GetChild(0).GetChild(0).GetComponent<Text>().text =
                select_eqip_item.Atk() + "\n" + select_eqip_item.Critical() + "%\n" + select_eqip_item.Shield() + "\n" + select_eqip_item.Hp() + "\n" + select_eqip_item.AtkSpeed() + "S\n" + select_eqip_item.Speed() + "S";
        }
        else
        {
            Enhace_info.transform.Find("아이템이미지").Find("아이템").Find("강화정도").GetChild(0).GetComponent<Text>().text = "+" + (select_eqip_item.enhance + 1);
            Enhace_info.transform.Find("아이템정보").GetChild(0).GetChild(0).GetComponent<Text>().text =
                select_eqip_item.Atk(select_eqip_item.enhance + 1) + "\n" + select_eqip_item.Critical(select_eqip_item.enhance + 1) + "%\n" + select_eqip_item.Shield(select_eqip_item.enhance + 1) + "\n" + select_eqip_item.Hp(select_eqip_item.enhance + 1) + "\n" + select_eqip_item.AtkSpeed(select_eqip_item.enhance + 1) + "S\n" + select_eqip_item.Speed(select_eqip_item.enhance + 1) + "S";
        }

        int current_enhance = select_eqip_item.enhance;

        if((current_enhance < 15))
        {
            List<string> enhance_data = GameManager.instance.databaseManager.Enhance_DB.GetRowData(current_enhance + 1);
            string prefix = select_eqip_item.prefix;

            switch (prefix)
            {
                case "":
                    enhance_money = int.Parse(enhance_data[6]);
                    break;
                case "쓸만한":
                    enhance_money = int.Parse(enhance_data[8]);
                    break;
                case "준수한":
                    enhance_money = int.Parse(enhance_data[10]);
                    break;
                case "희귀한":
                    enhance_money = int.Parse(enhance_data[12]);
                    break;
                case "특별한":
                    enhance_money = int.Parse(enhance_data[14]);
                    break;
                case "뛰어난":
                    enhance_money = int.Parse(enhance_data[16]);
                    break;
                case "화려한":
                    enhance_money = int.Parse(enhance_data[18]);
                    break;
                case "달빛":
                    enhance_money = int.Parse(enhance_data[20]);
                    break;
                case "태양빛":
                    enhance_money = int.Parse(enhance_data[22]);
                    break;
                case "온누리의":
                    enhance_money = int.Parse(enhance_data[24]);
                    break;
                case "우주의":
                    enhance_money = int.Parse(enhance_data[26]);
                    break;
                case "신의":
                    enhance_money = int.Parse(enhance_data[28]);
                    break;
            }
            string tempcurrent = string.Format("{0:#,###}", enhance_money);
            Enhace_info.transform.Find("강화비용텍스트").GetComponent<Text>().text = "비용 : " + tempcurrent.ToString() + "(원)";
        }
        else
        {
            Enhace_info.transform.Find("강화비용텍스트").GetComponent<Text>().text = "더이상 강화 불가";
        }

    }

    public void OnClick_Enhace_Exit()
    {
        if (enhance_coroutine_flag)
            return;

        OnClickEqip(); 
        if (Enhance_Coroutine != null)
        {
            StopCoroutine(Enhance_Coroutine);
        }
        Enhace_info.SetActive(false);
    }

    public void Enhance()
    {
        if (enhance_coroutine_flag)
            return;

        int current_enhance = select_eqip_item.enhance;

        if (current_enhance >= 15 || GameManager.instance.userInfo.GetMoney() < enhance_money) // 돈이 부족하거나 강화단계가 15 이상이면 리턴
            return;

        List<string> enhance_data = GameManager.instance.databaseManager.Enhance_DB.GetRowData(current_enhance + 1);
        int enhance_percent = int.Parse(enhance_data[2]); // 강화 성공 확률
        int random_percent = Random.RandomRange(0, 100);
        if (random_percent < enhance_percent) // 성공
        {
            Enhance_Coroutine = Enhance_Succes_Coroutine();
        }
        else // 실패
        {
            Enhance_Coroutine = Enhance_Fail_Coroutine();
        }

        StartCoroutine(Enhance_Coroutine);
    }
    IEnumerator Enhance_Coroutine;
    bool enhance_coroutine_flag;
    IEnumerator Enhance_Succes_Coroutine()
    {
        enhance_coroutine_flag = true;
        Enhace_info.GetComponent<Animator>().SetBool("enhance_succes", true);
        yield return new WaitForSeconds(1.5f);
        Money.instance.PlusMoney(-enhance_money);
        select_eqip_item.enhance++;
        yield return new WaitForSeconds(1.6f);
        Enhace_info.GetComponent<Animator>().SetBool("enhance_succes", false);
        OnClickEnhance();
        Eqip_Info();
        OnClickEqip();
        Set_Player_Info();
        enhance_coroutine_flag = false;
    }
    IEnumerator Enhance_Fail_Coroutine()
    {
        enhance_coroutine_flag = true; 
        Enhace_info.GetComponent<Animator>().SetBool("enhance_fail", true);
        yield return new WaitForSeconds(1.5f);
        Money.instance.PlusMoney(-enhance_money);
        yield return new WaitForSeconds(1.6f);
        Enhace_info.GetComponent<Animator>().SetBool("enhance_fail", false);
        OnClickEnhance();
        Eqip_Info();
        OnClickEqip();
        enhance_coroutine_flag = false;
    }

    int sell_money;
    public void OnClickSell()
    {
        blackpannel.SetActive(true);
        sell.SetActive(true);

        float grade = 1;
        float temp_money = 0;

        //등급 적용 
        switch (GameManager.instance.itemManager.WhatEqip(select_eqip_item.eqip).grade)
        {
            case "Normal":
                grade = 1;
                break;
            case "Rare":
                grade = 1.5f;
                break;
            case "Unique":
                grade = 2f;
                break;
            case "Epic":
                grade = 2.5f;
                break;
            case "Legend":
                grade = 3f;
                break;
        }

        // 수식어 및 강화횟수 가격
        List<string> data = GameManager.instance.databaseManager.Eqip_Sell_DB.GetRowData(select_eqip_item.enhance + 1);
        switch (select_eqip_item.prefix)
        {
            case "":
                temp_money = float.Parse(data[2]);
                break;
            case "쓸만한":
                temp_money = float.Parse(data[4]);
                break;
            case "준수한":
                temp_money = float.Parse(data[6]);
                break;
            case "희귀한":
                temp_money = float.Parse(data[8]);
                break;
            case "특별한":
                temp_money = float.Parse(data[10]);
                break;
            case "뛰어난":
                temp_money = float.Parse(data[12]);
                break;
            case "화려한":
                temp_money = float.Parse(data[14]);
                break;
            case "달빛":
                temp_money = float.Parse(data[16]);
                break;
            case "태양빛":
                temp_money = float.Parse(data[18]);
                break;
            case "온누리의":
                temp_money = float.Parse(data[20]);
                break;
            case "우주의":
                temp_money = float.Parse(data[22]);
                break;
            case "신의":
                temp_money = float.Parse(data[24]);
                break;
        }

        sell_money = (int)(grade * temp_money);

        // 비용 적용 
        string tempcurrent = string.Format("{0:#,###}", sell_money);
        sell.transform.GetChild(0).Find("가격_텍스트").GetComponent<Text>().text = tempcurrent + "원";
    }

    public void SellExit()
    {
        sell.SetActive(false);
    }

    public void SellYes() //판매
    {
        GameManager.instance.userInfo.RemoveEqip(select_eqip_item);
        
        // 돈 올리기 
        Money.instance.PlusMoney(sell_money);

        Set_Player_Info();
        OnClick_Eqip_Info_Exit();
    }
}
