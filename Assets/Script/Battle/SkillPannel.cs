using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SkillPannel : MonoBehaviour
{
    public List<string> playerSkill;

    [Header("스킬패널")]
    public Transform[] skillPannel;

    [Header("쿨타임 숫자")]
    public Sprite[] number;

    public int[] collTimeNum;
  

    public void Start()
    {
        //SkillSet();
    }

    public void SkillSet()
    {
        playerSkill = new List<string>();

        for (int i=0; i< skillPannel.Length; i++)
        {
            playerSkill.Add(GameManager.instance.userInfo.GetSkillEqipInfo(i));
        }

        for(int i=0; i< skillPannel.Length; i++)
        {
            if(playerSkill[i] != "null")
            {
                skillPannel[i].Find("skillName").GetComponent<Text>().text = GameManager.instance.skillManager.WhatSkill(playerSkill[i]).skillName;
            }
        }

        collTimeNum = new int[playerSkill.Count];
        for(int i=0; i< collTimeNum.Length; i++)
        {
            collTimeNum[i] = 0;
            skillPannel[i].Find("CollTime").gameObject.SetActive(false);
        }

    }

    void SkillOn(int index)
    {
        skillPannel[index].GetComponent<Image>().DOColor(Color.white, .6f);
    }

    void SkillOff(int index)
    {
        Color black = new Color(.6f, .6f, .6f);
        skillPannel[index].GetComponent<Image>().DOColor(black, .6f);
    }

    public void SkillCoolTimeSet(int num)
    {
        if(num < playerSkill.Count)
        {
            collTimeNum[num] = GameManager.instance.skillManager.WhatSkill(playerSkill[num]).coolTime;
        }


        for (int index=0; index < collTimeNum.Length; index++)
        {
            if(index != num)
            {
                collTimeNum[index]--;
            }

            skillPannel[index].Find("CollTime").gameObject.SetActive(true);

            if (collTimeNum[index] <= 0)
            {
                collTimeNum[index] = 0;
            }
            skillPannel[index].Find("CollTime").GetChild(0).GetComponent<Image>().sprite = number[collTimeNum[index]];

            if (collTimeNum[index] == 0)
            {
                SkillOn(index);
                skillPannel[index].Find("CollTime").gameObject.SetActive(false);
            }
            else
            {
                SkillOff(index);
            }
        }
    }

}
