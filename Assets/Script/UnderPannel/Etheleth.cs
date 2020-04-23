using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Etheleth : MonoBehaviour
{
    [Header("패널 전체")]
    public Transform grind_pannel;
    [Header("Etc ... ...")]
    public Money money;

    int[] enhance_item_num;
    int[] myitem_num;
    int[] enhance_money;

    private void Start()
    {
        InitialSet();
    }

    EnhanceKind EnhanceKind_Num(int index)
    {
        switch (index)
        {
            case 0:
                return EnhanceKind.atkEnhance;
            case 1:
                return EnhanceKind.hpEnhance;
            case 2:
                return EnhanceKind.sheildEnhance;
            case 3:
                return EnhanceKind.speedEnhace;
            case 4:
                return EnhanceKind.atkSpeedEnhance;
            case 5:
                return EnhanceKind.criticalEnhance;
            case 6:
                return EnhanceKind.expPercentEnhance;
            case 7:
                return EnhanceKind.albaMoneyEnhace;
        }
        return EnhanceKind.Null;
    }
    itemKind ItemKind_Num(int index)
    {
        switch (index)
        {
            case 0:
                return itemKind.atkEnhance;
            case 1:
                return itemKind.hpEnhance;
            case 2:
                return itemKind.sheildEnhance;
            case 3:
                return itemKind.speedEnhace;
            case 4:
                return itemKind.atkSpeedEnhance;
            case 5:
                return itemKind.criticalEnhance;
            case 6:
                return itemKind.expPercentEnhance;
            case 7:
                return itemKind.albaMoneyEnhace;
        }
        return itemKind.Null;
    }

    public void InitialSet()
    {
        //초기화
        enhance_item_num = new int[grind_pannel.childCount];
        myitem_num = new int[grind_pannel.childCount];
        enhance_money = new int[grind_pannel.childCount];

        //내 아이템 개수 정보 입력
        for (int i = 0; i < grind_pannel.childCount; i++)
        {
            myitem_num[i] = GameManager.instance.userInfo.GetItem(ItemKind_Num(i));
        }

        //돈 정보 입력
        for (int i = 0; i < grind_pannel.childCount; i++)
        {
            enhance_money[i] = GameManager.instance.EnhanceMoney(EnhanceKind_Num(i));
        }


        int current_lv = GameManager.instance.userInfo.GetLevel();
        for (int i = 0; i < grind_pannel.childCount; i++)
        {
            int current_enhance = GameManager.instance.userInfo.GetEnhance(EnhanceKind_Num(i));
            grind_pannel.GetChild(i).Find("상승량").Find("Left").GetComponent<Text>().text = "Lv" + current_enhance;
            grind_pannel.GetChild(i).Find("상승량").Find("Right").GetComponent<Text>().text = "Lv" + (current_enhance + 1);
            switch (i)
            {
                case 0: // 공격력
                    grind_pannel.GetChild(i).Find("상승량").Find("Left").Find("수치").GetComponent<Text>().text = "공격력 " + GameManager.instance.GetAtk(current_lv, current_enhance);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치").GetComponent<Text>().text = "공격력 " + GameManager.instance.GetAtk(current_lv, current_enhance + 1);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치상승폭").GetComponent<Text>().text = "(+ " + (GameManager.instance.GetAtk(current_lv, current_enhance + 1) - GameManager.instance.GetAtk(current_lv, current_enhance)) + ")";
                    break;
                case 1: // 체력
                    grind_pannel.GetChild(i).Find("상승량").Find("Left").Find("수치").GetComponent<Text>().text = "체력 " + GameManager.instance.GetHp(current_lv, current_enhance);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치").GetComponent<Text>().text = "체력 " + GameManager.instance.GetHp(current_lv, current_enhance + 1);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치상승폭").GetComponent<Text>().text = "(+ " + (GameManager.instance.GetHp(current_lv, current_enhance + 1) - GameManager.instance.GetAtk(current_lv, current_enhance)) + ")";
                    break;
                case 2: // 방어력
                    grind_pannel.GetChild(i).Find("상승량").Find("Left").Find("수치").GetComponent<Text>().text = "방어력 " + GameManager.instance.GetSheild();
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치").GetComponent<Text>().text = "방어력 " + (GameManager.instance.GetSheild() + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.sheildEnhance).percent);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치상승폭").GetComponent<Text>().text = "(+ " + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.sheildEnhance).percent + ")";
                    break;
                case 3: // 속력
                    grind_pannel.GetChild(i).Find("상승량").Find("Left").Find("수치").GetComponent<Text>().text = "속력 " + GameManager.instance.GetSpeed();
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치").GetComponent<Text>().text = "속력 " + (GameManager.instance.GetSpeed() + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.speedEnhace).percent);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치상승폭").GetComponent<Text>().text = "(+ " + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.speedEnhace).percent + ")";
                    break;
                case 4: // 공격속도
                    grind_pannel.GetChild(i).Find("상승량").Find("Left").Find("수치").GetComponent<Text>().text = "공격속도 " + GameManager.instance.GetAtkSpeed();
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치").GetComponent<Text>().text = "공격속도 " + (GameManager.instance.GetAtkSpeed() + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.atkSpeedEnhance).percent);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치상승폭").GetComponent<Text>().text = "(+ " + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.atkSpeedEnhance).percent + ")";
                    break;
                case 5: // 크리티컬
                    grind_pannel.GetChild(i).Find("상승량").Find("Left").Find("수치").GetComponent<Text>().text = "크리티컬 " + GameManager.instance.GetCritical();
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치").GetComponent<Text>().text = "크리티컬 " + (GameManager.instance.GetCritical() + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.criticalEnhance).percent);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치상승폭").GetComponent<Text>().text = "(+ " + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.criticalEnhance).percent + ")";
                    break;
                case 6: // 경험치 상승량
                    grind_pannel.GetChild(i).Find("상승량").Find("Left").Find("수치").GetComponent<Text>().text = "경험치 " + GameManager.instance.GetExpPercent();
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치").GetComponent<Text>().text = "경험치 " + (GameManager.instance.GetExpPercent() + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.expPercentEnhance).percent);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치상승폭").GetComponent<Text>().text = "(+ " + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.expPercentEnhance).percent + ")";
                    break;
                case 7: // 알바 돈 상승량
                    grind_pannel.GetChild(i).Find("상승량").Find("Left").Find("수치").GetComponent<Text>().text = "알바 " + GameManager.instance.GetAlbaMoney();
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치").GetComponent<Text>().text = "알바 " + (GameManager.instance.GetAlbaMoney() + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.albaMoneyEnhace).percent);
                    grind_pannel.GetChild(i).Find("상승량").Find("Right").Find("수치상승폭").GetComponent<Text>().text = "(+ " + GameManager.instance.enhanceManager.WhatEnhace(EnhanceKind.albaMoneyEnhace).percent + ")";
                    break;
            }

            int temp_percent = current_enhance / 10;
            temp_percent = 100 - (temp_percent * 10);
            grind_pannel.GetChild(i).Find("학습성공확률").Find("확률").GetComponent<Text>().text = temp_percent + "% +";
            grind_pannel.GetChild(i).Find("학습성공확률").Find("확률업").GetComponent<Text>().text = 0 + "%";

            grind_pannel.GetChild(i).Find("Enhance_item_").Find("Num").GetComponent<Text>().text = "0";

            string temp_money_string = string.Format("{0:#,###}", (int)enhance_money[0]);
            grind_pannel.GetChild(i).Find("단련버튼").Find("Money").GetComponent<Text>().text = temp_money_string;
        }
      
    }

    public void Right_enhance_item(int index)
    {
        //가지고있는 아이템 수가 더 적다면 리턴 
        if (!(myitem_num[index] >= (enhance_item_num[index] + 1)))
            return;

        // 강화확률 + 확률업이 100보다 크다면 리턴
        int temp_percent = GameManager.instance.userInfo.GetEnhance(EnhanceKind_Num(index)) / 10;
        temp_percent = 100 - (temp_percent * 10);
        if ((temp_percent + enhance_item_num[index] + 1) > 100)
            return;

        enhance_item_num[index]++;
        grind_pannel.GetChild(index).Find("Enhance_item_").Find("Num").GetComponent<Text>().text = enhance_item_num[index].ToString();
        grind_pannel.GetChild(index).Find("학습성공확률").Find("확률업").GetComponent<Text>().text = enhance_item_num[index] + "%";
    }

    public void Left_enhance_item(int index)
    {
        // 현재 강화아이템 적용 수가 1보다 작다면 리턴
        if (enhance_item_num[index] < 1)
            return;

        enhance_item_num[index]--;
        grind_pannel.GetChild(index).Find("Enhance_item_").Find("Num").GetComponent<Text>().text = enhance_item_num[index].ToString();
        grind_pannel.GetChild(index).Find("학습성공확률").Find("확률업").GetComponent<Text>().text = enhance_item_num[index] + "%";
    }

    public void OnClick_Enhance(int index)
    {
        long myMoney = GameManager.instance.userInfo.GetMoney(); // 내 돈
     
        //필요한 돈이 더 클 경우 리턴
        if (myMoney < enhance_money[index])
            return;

        //돈 차감 
        money.PlusMoney(-enhance_money[index]);

        //사용한 아이템 차감
        GameManager.instance.userInfo.SetItem(ItemKind_Num(index), GameManager.instance.userInfo.GetItem(ItemKind_Num(index)) - enhance_item_num[index]);

        // 강화확률 수치 
        int temp_percent = GameManager.instance.userInfo.GetEnhance(EnhanceKind_Num(index)) / 10;
        temp_percent = 100 - (temp_percent * 10) + enhance_item_num[index];

        int random = Random.RandomRange(1, 101);
        if(temp_percent >= random)
        {
            Debug.Log("강화성공");

            //강화 수치 + 1
            GameManager.instance.userInfo.SetEnhance(EnhanceKind_Num(index), GameManager.instance.userInfo.GetEnhance(EnhanceKind_Num(index)) + 1);
            InitialSet();
        }
        else
        {
            Debug.Log("강화실패");
        }


    }
}
