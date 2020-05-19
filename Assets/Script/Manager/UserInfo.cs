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

    //장비정보 
    public List<User_Eqip_Info> player_eqip_list = new List<User_Eqip_Info>();

    //가방정보 
    [HideInInspector]
    public int bag_num = 20;

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
        money = 10000000;
        level = 1;
        exp = 0;
        carrotLevel = 1;

        for (int i = 0; i < enhanceInfo.Length; i++)
        {
            enhanceInfo[i] = 1;
        }

        SetItem(Bitamin_kind.bitamin10, 100);
        SetItem(Bitamin_kind.bitamin100, 100);

        
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.거북이등껍질,0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.낡은책가방, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.노란색우비, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.당근판박이, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.무지개머리띠, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.별리본, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.사탕머리띠, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.스마일브로치, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.안개꽃화환, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.용판박이, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.음이온목걸이, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.잉어판박이, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.장비화환, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.최신형만보기, 0));
        player_eqip_list.Add(new User_Eqip_Info(Eqip_kind.해바라기화환, 0));
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

    /// <summary>
    ///  
    /// </summary>
    /// <param name="eqip"></param>
    /// 

    public void Set_Eqipitem(Eqip_kind eqip, int enhance)
    {
        player_eqip_list.Add(new User_Eqip_Info(eqip, enhance));
    }

    public User_Eqip_Info Get_Eqiping_Item(bool eqip_kind)
    {
        for (int i = 0; i < player_eqip_list.Count; i++)
        {
            if (GameManager.instance.itemManager.WhatEqip(player_eqip_list[i].eqip).eqip_kind == eqip_kind)
            {
                if (player_eqip_list[i].isEqip == true)
                {
                    return player_eqip_list[i];
                }
            }
        }

        return null;
    }

    public void Eqipment(User_Eqip_Info eqip)
    {
        for (int i = 0; i < player_eqip_list.Count; i++)
        {
            if (GameManager.instance.itemManager.WhatEqip(eqip.eqip).eqip_kind ==
                GameManager.instance.itemManager.WhatEqip(player_eqip_list[i].eqip).eqip_kind)
            {
                player_eqip_list[i].isEqip = false;
            }
        }

        for (int i = 0; i < player_eqip_list.Count; i++)
        {
            if (player_eqip_list[i] == eqip)
            {
                player_eqip_list[i].isEqip = true;
                return;
            }
        }
    }

    public void Eqip_Item_Enhance(User_Eqip_Info enhace_item)
    {
        enhace_item.enhance++;
        if (enhace_item.enhance > 15)
            enhace_item.enhance = 15;
    }
}


public class User_Eqip_Info
{
    public Eqip_kind eqip;
    public string prefix;
    public int enhance;
    public bool isEqip;
    int origin_atk;
    float origin_critical;
    float origin_shield;
    int origin_hp;
    float origin_atkspeed;
    float origin_speed;

    public User_Eqip_Info(Eqip_kind eqip, int enhance)
    {
        this.eqip = eqip;
        this.enhance = enhance;

        float prefix_iCount = 0;
        //공격력
        int atk_rand = Random.RandomRange(0, 100);
        if (GameManager.instance.itemManager.WhatEqip(eqip).atk_generation_percent > atk_rand)
        {
            int width = (int)GameManager.instance.itemManager.WhatEqip(eqip).atk_width;
            float atk_width_rand = Random.RandomRange(-width, width) / (float)100;
            float temp_atk = GameManager.instance.itemManager.WhatEqip(eqip).atk;
            temp_atk += temp_atk * atk_width_rand;
            origin_atk = (int)temp_atk;

            prefix_iCount += atk_width_rand;
        }
        //크리티컬
        int critical_rand = Random.RandomRange(0, 100);
        if (GameManager.instance.itemManager.WhatEqip(eqip).critical_generation_percent > critical_rand)
        {
            int width = (int)GameManager.instance.itemManager.WhatEqip(eqip).critical_width;
            float critical_width_rand = Random.RandomRange(-width, width) / (float)100;
            float temp_critical = GameManager.instance.itemManager.WhatEqip(eqip).critical;
            temp_critical += temp_critical * critical_width_rand;
            origin_critical = temp_critical;

            prefix_iCount += critical_width_rand;
        }
        //방어력
        int shield_rand = Random.RandomRange(0, 100);
        if (GameManager.instance.itemManager.WhatEqip(eqip).shield_generation_percent > shield_rand)
        {
            int width = (int)GameManager.instance.itemManager.WhatEqip(eqip).shield_width;
            float shield_width_rand = Random.RandomRange(-width, width) / (float)100;
            float temp_shield = GameManager.instance.itemManager.WhatEqip(eqip).shield;
            temp_shield += temp_shield * shield_width_rand;
            origin_shield = temp_shield;

            prefix_iCount += shield_width_rand;
        }
        //체력
        int hp_rand = Random.RandomRange(0, 100);
        if (GameManager.instance.itemManager.WhatEqip(eqip).hp_generation_percent > hp_rand)
        {
            int width = (int)GameManager.instance.itemManager.WhatEqip(eqip).hp_width;
            float hp_width_rand = Random.RandomRange(-width, width) / (float)100;
            float temp_hp = GameManager.instance.itemManager.WhatEqip(eqip).hp;
            temp_hp += temp_hp * hp_width_rand;
            origin_hp = (int)temp_hp;

            prefix_iCount += hp_width_rand;
        }
        //공격속도
        int atkspeed_rand = Random.RandomRange(0, 100);
        if (GameManager.instance.itemManager.WhatEqip(eqip).atkspeed_generation_percent > atkspeed_rand)
        {
            int width = (int)GameManager.instance.itemManager.WhatEqip(eqip).atkspeed_width;
            float atkspeed_width_rand = Random.RandomRange(-width, width) / (float)100;
            float temp_atkspeed = GameManager.instance.itemManager.WhatEqip(eqip).atkspeed;
            temp_atkspeed += temp_atkspeed * atkspeed_width_rand;
            origin_atkspeed = -temp_atkspeed;

            prefix_iCount += atkspeed_width_rand;
        }
        //속력
        int speed_rand = Random.RandomRange(0, 100);
        if (GameManager.instance.itemManager.WhatEqip(eqip).speed_generation_percent > speed_rand)
        {
            int width = (int)GameManager.instance.itemManager.WhatEqip(eqip).speed_width;
            float speed_width_rand = Random.RandomRange(-width, width) / (float)100;
            float temp_speed = GameManager.instance.itemManager.WhatEqip(eqip).speed;
            temp_speed += temp_speed * speed_width_rand;
            origin_speed = -temp_speed;

            prefix_iCount += speed_width_rand;
        }

        prefix_iCount *= 100;

        if (prefix_iCount <= 10)
            this.prefix = "";
        if (11 <= prefix_iCount && prefix_iCount <= 20)
            this.prefix = "쓸만한";
        if (21 <= prefix_iCount && prefix_iCount <= 30)
            this.prefix = "준수한";
        if (31 <= prefix_iCount && prefix_iCount <= 40)
            this.prefix = "희귀한";
        if (41 <= prefix_iCount && prefix_iCount <= 50)
            this.prefix = "특별한";
        if (51 <= prefix_iCount && prefix_iCount <= 60)
            this.prefix = "뛰어난";
        if (61 <= prefix_iCount && prefix_iCount <= 80)
            this.prefix = "화려한";
        if (81 <= prefix_iCount && prefix_iCount <= 100)
            this.prefix = "달빛";
        if (101 <= prefix_iCount && prefix_iCount <= 120)
            this.prefix = "태양빛";
        if (121 <= prefix_iCount && prefix_iCount <= 140)
            this.prefix = "온누리의";
        if (141 <= prefix_iCount && prefix_iCount <= 161)
            this.prefix = "우주의";
        if (161 <= prefix_iCount )
            this.prefix = "신의";


        
    }

    public int Atk()
    {
        if (enhance <= 0)
            return origin_atk;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (int)(origin_atk * percent);
    }
    public int Atk(int enhance)
    {
        if (enhance <= 0)
            return origin_atk;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (int)(origin_atk * percent);
    }

    public float Critical()
    {
        if (enhance <= 0)
            return origin_critical;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (origin_critical * percent);
    }
    public float Critical(int enhance)
    {
        if (enhance <= 0)
            return origin_critical;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (origin_critical * percent);
    }

    public float Shield()
    {
        if (enhance <= 0)
            return origin_shield;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (origin_shield * percent);
    }
    public float Shield(int enhance)
    {
        if (enhance <= 0)
            return origin_shield;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (origin_shield * percent);
    }

    public int Hp()
    {
        if (enhance <= 0)
            return origin_hp;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (int)(origin_hp * percent);
    }
    public int Hp(int enhance)
    {
        if (enhance <= 0)
            return origin_hp;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (int)(origin_hp * percent);
    }

    public float AtkSpeed()
    {
        if (enhance <= 0)
            return origin_atkspeed;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (origin_atkspeed * percent);
    }
    public float AtkSpeed(int enhance)
    {
        if (enhance <= 0)
            return origin_atkspeed;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (origin_atkspeed * percent);
    }

    public float Speed()
    {
        if (enhance <= 0)
            return origin_speed;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (origin_speed * percent);
    }
    public float Speed(int enhance)
    {
        if (enhance <= 0)
            return origin_speed;

        float percent = float.Parse(GameManager.instance.databaseManager.Enhance_DB.GetRowData(enhance)[4]);
        return (origin_speed * percent);
    }
}