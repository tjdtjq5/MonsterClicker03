using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    //유저정보 
    string userNickname;
    string petName;
    string achievement;
    long money;
    int level;
    float exp;
    int carrotLevel;

    //블로그(강화) 정보
    int[] enhanceInfo;

    //알바 정보 
    int alba01;
    int alba02;
    int alba03;
    int alba04;
    int alba05;
    int alba06;
    int alba07;
    int alba08;
    int alba09;
    int alba10;

    int[] bitamin_info;

    //스킬정보 
    public List<string> skillHaveInfo;
    public string[] skillEqipInfo;


    // 초기 설정
    void Start()
    {
        skillHaveInfo = new List<string>();
        skillEqipInfo = new string[4];

        bitamin_info = new int[this.GetComponent<ItemManager>().bitamin_list.Length];
        enhanceInfo = new int[this.GetComponent<EnhanceManager>().enhanceList.Length];

        userNickname = "유저이름";
        petName = "펫 이름";
        achievement = "업적이름 ???";
        money = 1000000;
        level = 1;
        exp = 0;
        carrotLevel = 1;

        for (int i = 0; i < enhanceInfo.Length; i++)
        {
            enhanceInfo[i] = 1;
        }

        SetItem(Bitamin_kind.bitamin10, 100);
        SetItem(Bitamin_kind.bitamin100, 100);
      
    }


    // 유저정보
    public void SetUserNickname(string userNickname)
    {
        this.userNickname = userNickname;
    }

    public void SetPetName(string petName)
    {
        this.petName = petName;
    }

    public void SetAchievement(string achievement)
    {
        this.achievement = achievement;
    }

    public void SetMoney(long money)
    {
        this.money = money;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void SetExp(float exp)
    {
        this.exp = exp;
    }

    public void SetCarrotLevel(int level)
    {
        this.carrotLevel = level;
    }




    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>


    public string GetUserNickname()
    {
        return userNickname;
    }

    public string GetPetName()
    {
        return petName;
    }

    public string GetAchievement()
    {
        return achievement;
    }

    public long GetMoney()
    {
        return money;
    }

    public int GetLevel()
    {
        return level;
    }

    public float GetExp()
    {
        return exp;
    }
    public int GetCarrotLevel()
    {
        return this.carrotLevel;
    }



    //(강화) 정보
    public void SetEnhance(EnhanceKind enhance, int num)
    {
        if (enhanceInfo.Length != GameManager.instance.enhanceManager.enhanceList.Length)
        {
            Debug.Log("강화 정보가 맞지 않습니다.");
        }

        for (int i = 0; i < enhanceInfo.Length; i++)
        {
            if (GameManager.instance.enhanceManager.enhanceList[i].enhance == enhance)
            {
                enhanceInfo[i] = num;
                return;
            }
        }
    }

    public int GetEnhance(EnhanceKind enhance)
    {
        if (enhanceInfo.Length != GameManager.instance.enhanceManager.enhanceList.Length)
        {
            Debug.Log("강화 정보가 맞지 않습니다.");
        }

        for (int i = 0; i < enhanceInfo.Length; i++)
        {
            if (GameManager.instance.enhanceManager.enhanceList[i].enhance == enhance)
            {
                return enhanceInfo[i];
            }
        }

        return 0;
    }


    // 알바 정보 

    public void SetAlba(int whatAlba, int iCount)
    {
        switch (whatAlba)
        {
            case 0:
                alba01 = iCount;
                break;
            case 1:
                alba02 = iCount;
                break;
            case 2:
                alba03 = iCount;
                break;
            case 3:
                alba04 = iCount;
                break;
            case 4:
                alba05 = iCount;
                break;
            case 5:
                alba06 = iCount;
                break;
            case 6:
                alba07 = iCount;
                break;
            case 7:
                alba08 = iCount;
                break;
            case 8:
                alba09 = iCount;
                break;
            case 9:
                alba10 = iCount;
                break;
        }

    }

    public int GetAlba(int whatAlba)
    {
        switch (whatAlba)
        {
            case 0:
                return alba01;
            case 1:
                return alba02;
            case 2:
                return alba03;
            case 3:
                return alba04;
            case 4:
                return alba05;
            case 5:
                return alba06;
            case 6:
                return alba07;
            case 7:
                return alba08;
            case 8:
                return alba09;
            case 9:
                return alba10;
        }
        return 0;
    }

    // 아이템정보 

    public void SetItem(Bitamin_kind bitamin , int num)
    {
        if (bitamin_info.Length != GameManager.instance.itemManager.bitamin_list.Length)
        {
            Debug.Log("아이템 정보가 맞지 않습니다.");
        }

        for (int i=0; i< bitamin_info.Length; i++)
        {
            if(GameManager.instance.itemManager.bitamin_list[i].bitamin == bitamin)
            {
                bitamin_info[i] = num;
                return;
            }
        }
    }

    public int GetItem(Bitamin_kind bitamin)
    {
        if (bitamin_info.Length != GameManager.instance.itemManager.bitamin_list.Length)
        {
            Debug.Log("아이템 정보가 맞지 않습니다.");
        }

        for (int i = 0; i < bitamin_info.Length; i++)
        {
            if (GameManager.instance.itemManager.bitamin_list[i].bitamin == bitamin)
            {
                return bitamin_info[i];
            }
        }

        return 0;
    }

    public void SetSkillHave(string skillIndex)
    {
        // 스킬매니저의 whatSkill에서 한번 검증을 받고 온다
        // 잘못된 스킬 인덱스라면 아무일도 일어나지 않는다.
        string tempStringSkill = this.GetComponent<SkillManager>().WhatSkill(skillIndex).skillIndex;
        if(tempStringSkill != "null")
            skillHaveInfo.Add(tempStringSkill);
    }

    public string GetSkillHave(string skillIndex)
    {
        //스킬 인덱스를 입력해서 가지고 있는 스킬 정보를 얻는다. 
        //입력한 스킬 인덱스가 없다면 null값이 반환된다.
        for(int i=0; i<skillHaveInfo.Count; i++)
        {
            if (skillHaveInfo[i] == skillIndex)
                return skillHaveInfo[i];
        }

        string tempSkillHaveInfo = "null";
        return tempSkillHaveInfo;
    }

    public void SetSkillEqipInfo(int index, string skillIndex)
    {
        //장착시키려는 인덱스 값이 장착가능한 공간을 넘어갈 경우 무시
        if (skillEqipInfo.Length <= index)
            return;

        skillEqipInfo[index] = skillIndex;
    }

    public string GetSkillEqipInfo(int index)
    {
        // 찾으려는 인덱스 값이 장착 가능한 갯수보다 넘어갈때 null값을 반환
        if(skillEqipInfo.Length <= index)
            return "null";
        //찾으려는 장착정보가 없을 경우에 null반환
        if (skillEqipInfo[index] == null || !skillEqipInfo[index].Contains("Skill"))
            return "null";

        return skillEqipInfo[index];
    }
}
