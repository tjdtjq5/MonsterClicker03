using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillManager : MonoBehaviour
{
    [Serializable]
    public struct skillStruct
    {
        public string skillIndex;
        public string skillCode;
        public string skillName;
        public string skillRating;
        public type skillType;
        public float atkTime;
        public int coolTime;
        public int atk;
        public int atkCount;
        public skillEffect skillEffect;
        public float skillEffectPercent;
        public float skillEffectDamage;
        public float skillEffectAdateCount;
        public float statusPlusAtk;
        public float statusPlusSheild;
        public float statusPlusHp;
        public float statusPlusSpeed;
        public float statusPlusAtkSpeed;
        public float statusPlusCriticalPercent;
    }

    public skillStruct[] skillList;

    public skillStruct WhatSkill(string skillIndex)
    {
        for (int i = 0; i < skillList.Length; i++)
        {
            if (skillList[i].skillIndex == skillIndex)
            {
                return skillList[i];
            }
        }
        skillStruct nullStruct = new skillStruct();
        nullStruct.skillIndex = "null";
        return nullStruct;
    }

    public int GetSkillListLength()
    {
        return skillList.Length;
    }

    void SetSkill()
    {
        skillList = new skillStruct[this.GetComponent<DatabaseManager>().GetLineSize() - 2];
        for (int i=0; i< skillList.Length; i++)
        {
            List<string> skillData = this.GetComponent<DatabaseManager>().GetRowData(i+2);
            skillList[i].skillIndex = skillData[0];
            skillList[i].skillCode = skillData[1];
            skillList[i].skillName = skillData[2];
            skillList[i].skillRating = skillData[3];
            if (skillList[i].skillCode.Contains("Pure"))
                skillList[i].skillType = type.순수;
            if (skillList[i].skillCode.Contains("Fight"))
                skillList[i].skillType = type.타격;
            if (skillList[i].skillCode.Contains("Poison"))
                skillList[i].skillType = type.독;
            if (skillList[i].skillCode.Contains("Fire"))
                skillList[i].skillType = type.불;
            if (skillList[i].skillCode.Contains("Water"))
                skillList[i].skillType = type.물;
            if (skillList[i].skillCode.Contains("Electricity"))
                skillList[i].skillType = type.전기;

            int outInt;
            float outFloat;
            if (float.TryParse(skillData[5], out outFloat))
                skillList[i].atkTime = outFloat + 0.6f;
            else
                skillList[i].atkTime = 3;
            if (int.TryParse(skillData[6], out outInt))
                skillList[i].coolTime = outInt;
            else
                skillList[i].coolTime = 0;

            if (int.TryParse(skillData[7], out outInt))
                skillList[i].atk = outInt;
            else
                skillList[i].atk = 0;

            if (int.TryParse(skillData[8], out outInt))
                skillList[i].atkCount = outInt;
            else
                skillList[i].atkCount = 0;
        }

    }

    private void Start()
    {
        SetSkill();
    }
}



public enum type
{
    물,
    불,
    전기,
    순수,
    독,
    타격
}


public enum skillEffect
{
    Null,
    도트데미지,
    마비
}

