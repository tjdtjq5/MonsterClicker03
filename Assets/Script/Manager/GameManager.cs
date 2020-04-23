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
        tempAtk = (tempAtk + carrotAtk);
        return tempAtk;
    }

    public int GetHp(int level, int enhanceNum)
    {
        int tempHp = level * hpForLevel;

        for (int i = 0; i < enhanceNum; i++)
        {
            tempHp += (int)(enhanceManager.WhatEnhace(EnhanceKind.hpEnhance).percent / 100 * tempHp);
        }
        return tempHp;
    }

    public float GetSpeed()
    {
        float tempSpeed = initialSpeed;

        tempSpeed = tempSpeed + (userInfo.GetEnhance(EnhanceKind.speedEnhace) * enhanceManager.WhatEnhace(EnhanceKind.speedEnhace).percent);
        return tempSpeed;
    }

    public float GetSheild()
    {
        float tempSheild = initialSheild;

        tempSheild = tempSheild + (userInfo.GetEnhance(EnhanceKind.sheildEnhance) * enhanceManager.WhatEnhace(EnhanceKind.sheildEnhance).percent);
        return tempSheild;
    }

    public float GetCritical()
    {
        float tempCritical = initialCritical;

        tempCritical = tempCritical + (userInfo.GetEnhance(EnhanceKind.criticalEnhance) * enhanceManager.WhatEnhace(EnhanceKind.criticalEnhance).percent);
        return tempCritical;
    }

    public float GetAtkSpeed()
    {
        float tempAtkSpeed = initialAtkSpeed;

        tempAtkSpeed -= (userInfo.GetEnhance(EnhanceKind.atkSpeedEnhance) * enhanceManager.WhatEnhace(EnhanceKind.atkSpeedEnhance).percent);
        return tempAtkSpeed;
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


    
