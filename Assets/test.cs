using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class test : MonoBehaviour
{
    public SkillPannel skillPannel;
    public BattleManager battleManager;

    public InputField skillInput01;
    public InputField skillInput02;
    public InputField skillInput03;
    public InputField skillInput04;

    string skill01;
    string skill02;
    string skill03;
    string skill04;

    public void SkillSet()
    {
        skill01 = skillInput01.text;
        skill02 = skillInput02.text;
        skill03 = skillInput03.text;
        skill04 = skillInput04.text;

        if(GameManager.instance.skillManager.WhatSkill(skill01).skillIndex == "null")
        {
            skillInput01.text = "잘못된 정보 입력";
        }

        if (GameManager.instance.skillManager.WhatSkill(skill02).skillIndex == "null")
        {
            skillInput02.text = "잘못된 정보 입력";
        }

        if (GameManager.instance.skillManager.WhatSkill(skill03).skillIndex == "null")
        {
            skillInput03.text = "잘못된 정보 입력";
        }

        if (GameManager.instance.skillManager.WhatSkill(skill04).skillIndex == "null")
        {
            skillInput04.text = "잘못된 정보 입력";
        }

        GameManager.instance.userInfo.SetSkillHave(skill01);
        GameManager.instance.userInfo.SetSkillHave(skill02);
        GameManager.instance.userInfo.SetSkillHave(skill03);
        GameManager.instance.userInfo.SetSkillHave(skill04);

        GameManager.instance.userInfo.SetSkillEqipInfo(0,skill01);
        GameManager.instance.userInfo.SetSkillEqipInfo(1,skill02);
        GameManager.instance.userInfo.SetSkillEqipInfo(2,skill03);
        GameManager.instance.userInfo.SetSkillEqipInfo(3,skill04);

        skillPannel.SkillSet();
        battleManager.playerSkill = skillPannel.playerSkill;
    }
}
