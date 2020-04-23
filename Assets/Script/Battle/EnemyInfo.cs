using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public Sprite enemySprite;
    public string enemyName;
    public type enemyType;
    public int level;
    public int atk;
    public int hp;
    public float sheild;
    public float critical;
    public List<string> haveSkill;

  
    public void SetInfo()
    {
        enemySprite = GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).enemySprite;
        enemyName = GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).enemyName;
        enemyType = GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).enemyType;
        level = GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).level;
        atk = GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).atk;
        hp = GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).hp;
        sheild = GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).sheild;
        critical = GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).critical;
        haveSkill = new List<string>();
        haveSkill.Add(GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).haveSkill_01);
        haveSkill.Add(GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).haveSkill_02);
        haveSkill.Add(GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).haveSkill_03);
        haveSkill.Add(GameManager.instance.enemyManager.WhatEnemy(StageInfo.Stage).haveSkill_04);

       
    }
    public int GetSkillDamage(int skillAtk, float enemySheild)
    {
        float temp = atk;
        int tempAtk = (int)(temp / 4);
        int tempsheild = (int)(100 - (enemySheild * 0.15f));
        int damage = (int)((float)(skillAtk + tempAtk) / 100 * tempsheild);
        return damage;
    }
}
