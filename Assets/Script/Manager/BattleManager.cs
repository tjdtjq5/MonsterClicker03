using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("blackpannel and gameendPannel")]
    public GameObject blackpannel;
    public GameObject game_end_pannel;

    [Header("NextScene")]
    public NextScene next_scene;

    int round;

    int player_hp;
    int enemy_hp;

    bool game_set_win;
    bool game_set_lose;

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
            game_set_lose = true;
        }
    }
    void EnemyGetDamage(int damage)
    {
        enemy_hp -= damage;
        screenManager.SetEnemyHpBar(enemy_hp);

        if (enemy_hp <= 0)
        {
            game_set_win = true;
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

        if(game_set_lose || game_set_win)
        {
            GameEnd();
        }
        else
        {
            EnemySkillTrun();
        }
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

        if (game_set_lose || game_set_win)
        {
            GameEnd();
        }
        else
        {
            trunPannel.TurnEnd(round);
        }
    }

    public void AutoAttack()
    {
        for (int i = 0; i < skillPannel.collTimeNum.Length; i++)
        {
            if (skillPannel.collTimeNum[i] == 0)
            {
                return;
            }
        }

        round++;
        int damage = GameManager.instance.GetSkillDamage(GameManager.instance.skillManager.skillList[0].atk, enemyInfo.sheild) / GameManager.instance.skillManager.skillList[0].atkCount;
        AtkEffectManager.SkillEffect(GameManager.instance.skillManager.skillList[0].skillCode, damage);
        skillPannel.SkillCoolTimeSet(100);
        StartCoroutine(SkillBtnCoroutine(GameManager.instance.skillManager.skillList[0].atkTime));
    }

    bool gameend_flag;
    string temp_stage_string;
    void GameEnd()
    {
        blackpannel.SetActive(true);
        game_end_pannel.SetActive(true);

        if (game_set_win)
        {
            game_end_pannel.transform.Find("결과").GetComponent<Text>().text = "승리";
            temp_stage_string = (int)StageInfo.Stage.x + "/" + (int)StageInfo.Stage.y + "/true/true";
        }
        if (game_set_lose)
        {
            game_end_pannel.transform.Find("결과").GetComponent<Text>().text = "패배";
            temp_stage_string = (int)StageInfo.Stage.x + "/" + (int)StageInfo.Stage.y + "/true/false";
        }

        gameend_flag = true;
    }

    public void OnClickNextScene()
    {
        if (gameend_flag)
        {
            next_scene.OnNextScene(temp_stage_string);
        }
    }
}
