using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    [Serializable]
    public struct enemyStruct
    {
        public Vector2 stageCode;
        public Sprite enemySprite;
        public string enemyName;
        public type enemyType;
        public int level;
        public int atk;
        public int hp;
        public float sheild;
        public float critical;
        public string haveSkill_01;
        public string haveSkill_02;
        public string haveSkill_03;
        public string haveSkill_04;
    }

    public enemyStruct[] enemyList;

    public enemyStruct WhatEnemy(Vector2 stageCode)
    {
        for (int i = 0; i < enemyList.Length; i++)
        {
            if (enemyList[i].stageCode == stageCode)
            {
                return enemyList[i];
            }
        }
        enemyStruct nullStruct = new enemyStruct();
        nullStruct.stageCode = Vector2.zero;
        return nullStruct;
    }


}


