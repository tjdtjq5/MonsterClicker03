using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public SkillPannel skillPannel;
    public AtkEffectManager AtkEffectManager;
    public EnemyEffectManager enemyEffectManager;
    public Trun trunPannel;
    public EnemyInfo enemyInfo;
    public ScreenManager screenManager;
    public DamageEffect[] damageEffects;
    public EnemyDamageEffect[] enemyDamageEffects;

    [HideInInspector]
    public List<string> playerSkill;

    int round;

    int player_hp;
    int enemy_hp;

    private void Start()
    {
        initialBattleSet();
    }

    void initialBattleSet()
    {
        enemyInfo.SetInfo();
        round = 1;
        trunPannel.Summon();
        player_hp = GameManager.instance.GetHp(GameManager.instance.userInfo.GetLevel(), GameManager.instance.userInfo.GetEnhance(EnhanceKind.hpEnhance));
        enemy_hp = enemyInfo.hp;
        screenManager.InitialScreen(player_hp, enemy_hp);
    }

    void PlayerGetDamage(int damage)
    {
        player_hp -= damage;
        screenManager.SetPlayerHpBar(player_hp);

        if(player_hp <= 0)
        {
            Debug.Log("게임패배");
        }
    }
    void EnemyGetDamage(int damage)
    {
        enemy_hp -= damage;
        screenManager.SetEnemyHpBar(enemy_hp);

        if (enemy_hp <= 0)
        {
            Debug.Log("게임승리");
        }
    }

    public void SkillBtn(int num)
    {
        if(skillPannel.collTimeNum[num] <= 0)
        {
            round++;
            int damage = GameManager.instance.GetSkillDamage(GameManager.instance.skillManager.WhatSkill(playerSkill[num]).atk, enemyInfo.sheild) / GameManager.instance.skillManager.WhatSkill(playerSkill[num]).atkCount;
            AtkEffectManager.SkillEffect(GameManager.instance.skillManager.WhatSkill(playerSkill[num]).skillCode, damage);
            skillPannel.SkillCoolTimeSet(num);
            StartCoroutine(SkillBtnCoroutine(GameManager.instance.skillManager.WhatSkill(playerSkill[num]).atkTime));
        }
    }

    IEnumerator SkillBtnCoroutine(float time)
    {
        trunPannel.PlayerTrun();
        yield return new WaitForSeconds(time);

        int damage = 0;
        for(int i=0; i< damageEffects.Length; i++)
        {
            damage += damageEffects[i].realDamge;
        }
        EnemyGetDamage(damage);

        EnemySkillTrun();
    }

    void EnemySkillTrun()
    {
        int randomSkillNum = Random.RandomRange(0, 4);
        int damage = enemyInfo.GetSkillDamage(GameManager.instance.skillManager.WhatSkill(enemyInfo.haveSkill[randomSkillNum]).atk, GameManager.instance.GetSheild()) / GameManager.instance.skillManager.WhatSkill(enemyInfo.haveSkill[randomSkillNum]).atkCount;
        enemyEffectManager.SkillEffect(GameManager.instance.skillManager.WhatSkill(enemyInfo.haveSkill[randomSkillNum]).skillCode, damage);
        StartCoroutine(EnemySkillTrunCoroutine(GameManager.instance.skillManager.WhatSkill(enemyInfo.haveSkill[randomSkillNum]).atkTime));
    }

    IEnumerator EnemySkillTrunCoroutine(float time)
    {
        trunPannel.EnemyTrun();
        yield return new WaitForSeconds(time);

        int damage = 0;
        for (int i = 0; i < enemyDamageEffects.Length; i++)
        {
            damage += enemyDamageEffects[i].realDamge;
        }
        PlayerGetDamage(damage);

        trunPannel.TurnEnd(round);
    }

    public void AutoAttack()
    {
        for (int i = 0; i < skillPannel.collTimeNum.Length; i++)
        {
            if (skillPannel.collTimeNum[i] == 0)
            {
                Debug.Log(i + " : " + skillPannel.collTimeNum[i]);
                return;
            }
        }

        round++;
        int damage = GameManager.instance.GetSkillDamage(GameManager.instance.skillManager.skillList[0].atk, enemyInfo.sheild) / GameManager.instance.skillManager.skillList[0].atkCount;
        AtkEffectManager.SkillEffect(GameManager.instance.skillManager.skillList[0].skillCode, damage);
        skillPannel.SkillCoolTimeSet(100);
        StartCoroutine(SkillBtnCoroutine(GameManager.instance.skillManager.skillList[0].atkTime));
    }

}
