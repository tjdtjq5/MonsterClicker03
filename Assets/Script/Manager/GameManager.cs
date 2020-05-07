using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public UserInfo userInfo;
    [HideInInspector]
    public ItemManager itemManager;
    [HideInInspector]
    public EnhanceManager enhanceManager;
    [HideInInspector]
    public SkillManager skillManager;
    [HideInInspector]
    public DatabaseManager databaseManager;
    [HideInInspector]
    public EnemyManager enemyManager;

    public void Awake()
    {
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);

        if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        userInfo = GetComponent<UserInfo>();
        itemManager = GetComponent<ItemManager>();
        enhanceManager = GetComponent<EnhanceManager>();
        skillManager = GetComponent<SkillManager>();
        databaseManager = GetComponent<DatabaseManager>();
        enemyManager = GetComponent<EnemyManager>();
    }

 

    //능력치 정보 
    int atk;
    int hp;
    int speed;
    float critical;

    [Header("레벨당 수치")]
    public int atkForLevel;
    public int hpForLevel;
    [Header("초기 수치")]
    public float initialSpeed;
    public float initialCritical;
    public float initialSheild;
    public float initialAtkSpeed;
    public int initialEnhanceMoney;
    [Header("강화 상승량")]
    public int enhanceMoneyPercent;
    [Header("전투력 수치 조정")]
    public float atkBattle;  
    public float hpBattle;
    public float speedBattle;
    public float sheildBattle;
    public float criticalBattle;
    public float atkSpeedBattle;
    [Header("허수아비 능력치")]
    public int lvPerPlayerLv;
    public int initialScarowHp;
    public float increaseHpPercent;


    public int GetSkillDamage(int skillAtk, float enemySheild)
    {
        float temp = GetAtk(userInfo.GetLevel(), userInfo.GetEnhance(EnhanceKind.atkEnhance));
        int tempAtk = (int)(temp / 4);
        int tempsheild = (int)(100 - (enemySheild * 0.15f));
        int damage = (int)((float)(skillAtk + tempAtk) / 100  * tempsheild);
        return damage;
    }

    /// 능력 정보 
    public int GetBattle()
    {
        int atkTemp = (int)(GetAtk(userInfo.GetLevel(), userInfo.GetEnhance(EnhanceKind.atkEnhance)) * atkBattle);
        int hpTemp = (int)(GetHp(userInfo.GetLevel(), userInfo.GetEnhance(EnhanceKind.hpEnhance)) * hpBattle);
        int speedTemp = (int)((GetSpeed() - initialSpeed) * speedBattle);
        int sheildTemp = (int)((GetSheild() - initialSheild) * sheildBattle);
        int criticalTemp = (int)((GetCritical() - initialCritical) * criticalBattle);
        int atkSpeedTemp = (int)((GetAtkSpeed() - initialAtkSpeed) * atkSpeedBattle);

        int battleTemp = atkTemp + hpTemp + speedTemp + sheildTemp + criticalTemp + atkSpeedTemp;
        return battleTemp;
    }

    public int GetAtk(int level, int enhanceNum)
    {
        // 레벨당 공격력 -> 강화 수치만큼 복리로 증가 + 당근장비 공격력 

        int tempAtk = level * atkForLevel;

        for(int i=0; i< enhanceNum; i++)
        {
            tempAtk += (int)(enhanceManager.WhatEnhace(EnhanceKind.atkEnhance).percent / 100 * tempAtk);
        }

        int carrotAtk = userInfo.GetCarrotLevel();

        // 장착중인 장비 더하기
        int eqipAtk_false = 0;
        int eqipAtk_true = 0;
        if (userInfo.Get_Eqiping_Item(false) != null)
            eqipAtk_false = userInfo.Get_Eqiping_Item(false).atk;
        if (userInfo.Get_Eqiping_Item(true) != null)
            eqipAtk_true = userInfo.Get_Eqiping_Item(true).atk;

        tempAtk = (tempAtk + carrotAtk) + eqipAtk_false + eqipAtk_true;
        return tempAtk;
    }

    public int GetHp(int level, int enhanceNum)
    {
        int tempHp = level * hpForLevel;

        for (int i = 0; i < enhanceNum; i++)
        {
            tempHp += (int)(enhanceManager.WhatEnhace(EnhanceKind.hpEnhance).percent / 100 * tempHp);
        }

        // 장착중인 장비 더하기
        int eqipHp_false = 0;
        int eqipHp_true = 0;
        if (userInfo.Get_Eqiping_Item(false) != null)
            eqipHp_false = userInfo.Get_Eqiping_Item(false).hp;
        if (userInfo.Get_Eqiping_Item(true) != null)
            eqipHp_true = userInfo.Get_Eqiping_Item(true).hp;

        return tempHp + eqipHp_false + eqipHp_true;
    }

    public float GetSpeed()
    {
        float tempSpeed = initialSpeed;

        tempSpeed = tempSpeed + (userInfo.GetEnhance(EnhanceKind.speedEnhace) * enhanceManager.WhatEnhace(EnhanceKind.speedEnhace).percent);

        // 장착중인 장비 더하기
        float eqipSpeed_false = 0;
        float eqipSpeed_true = 0;
        if (userInfo.Get_Eqiping_Item(false) != null)
            eqipSpeed_false = userInfo.Get_Eqiping_Item(false).speed;
        if (userInfo.Get_Eqiping_Item(true) != null)
            eqipSpeed_true = userInfo.Get_Eqiping_Item(true).speed;


        return tempSpeed + eqipSpeed_false + eqipSpeed_true;
    }

    public float GetSheild()
    {
        float tempSheild = initialSheild;

        tempSheild = tempSheild + (userInfo.GetEnhance(EnhanceKind.sheildEnhance) * enhanceManager.WhatEnhace(EnhanceKind.sheildEnhance).percent);

        // 장착중인 장비 더하기
        float eqipSheild_false = 0;
        float eqipSheild_true = 0;
        if (userInfo.Get_Eqiping_Item(false) != null)
            eqipSheild_false = userInfo.Get_Eqiping_Item(false).shield;
        if (userInfo.Get_Eqiping_Item(true) != null)
            eqipSheild_true = userInfo.Get_Eqiping_Item(true).shield;

        return tempSheild + eqipSheild_false + eqipSheild_true;
    }

    public float GetCritical()
    {
        float tempCritical = initialCritical;

        tempCritical = tempCritical + (userInfo.GetEnhance(EnhanceKind.criticalEnhance) * enhanceManager.WhatEnhace(EnhanceKind.criticalEnhance).percent);

        // 장착중인 장비 더하기
        float eqipCritical_false = 0;
        float eqipCritical_true = 0;
        if (userInfo.Get_Eqiping_Item(false) != null)
            eqipCritical_false = userInfo.Get_Eqiping_Item(false).critical;
        if (userInfo.Get_Eqiping_Item(true) != null)
            eqipCritical_true = userInfo.Get_Eqiping_Item(true).critical;

        return tempCritical + eqipCritical_false + eqipCritical_true;
    }

    public float GetAtkSpeed()
    {
        float tempAtkSpeed = initialAtkSpeed;

        tempAtkSpeed -= (userInfo.GetEnhance(EnhanceKind.atkSpeedEnhance) * enhanceManager.WhatEnhace(EnhanceKind.atkSpeedEnhance).percent);

        // 장착중인 장비 더하기
        float eqipAtkSpeed_false = 0;
        float eqipAtkSpeed_true = 0;
        if (userInfo.Get_Eqiping_Item(false) != null)
            eqipAtkSpeed_false = userInfo.Get_Eqiping_Item(false).atkspeed;
        if (userInfo.Get_Eqiping_Item(true) != null)
            eqipAtkSpeed_true = userInfo.Get_Eqiping_Item(true).atkspeed;

        return tempAtkSpeed + eqipAtkSpeed_false + eqipAtkSpeed_true;
    }

    public float GetExpPercent()
    {
        float tempExp_percent = 0;

        tempExp_percent += (userInfo.GetEnhance(EnhanceKind.expPercentEnhance) * enhanceManager.WhatEnhace(EnhanceKind.expPercentEnhance).percent);



        return tempExp_percent;
    }

    public float GetAlbaMoney()
    {
        float tempGetAlbaMoney = 0;

        tempGetAlbaMoney += (userInfo.GetEnhance(EnhanceKind.albaMoneyEnhace) * enhanceManager.WhatEnhace(EnhanceKind.albaMoneyEnhace).percent);
        return tempGetAlbaMoney;
    }

    // 강화 정보 
    public int EnhanceMoney(EnhanceKind enhance)
    {
        int tempMoney = initialEnhanceMoney;
        for(int i=0; i<userInfo.GetEnhance(enhance); i++)
        {
            tempMoney += tempMoney * enhanceMoneyPercent / 100;
        }
        return tempMoney;
    }


    // 적 정보
    public int GetScarowLv()
    {
        int userLv = userInfo.GetLevel();
        int tempScarowLv = 0;
        if (lvPerPlayerLv < 2)
            tempScarowLv = userLv / lvPerPlayerLv;
        else
            tempScarowLv = userLv / lvPerPlayerLv + 1;
        return tempScarowLv;
    }

    public int GetScarowHp()
    {
        float tempHp = initialScarowHp;

        for(int i=0; i<GetScarowLv(); i++)
        {
            tempHp = tempHp + (tempHp * increaseHpPercent);
        }

        return (int)tempHp;
    }
}


    
