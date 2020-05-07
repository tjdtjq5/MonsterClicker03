using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    /// <summary>
    /// 비타민
    /// </summary>
    
    [Serializable]
    public struct Bitamin_Struct
    {
        public Bitamin_kind bitamin;
        public string bitamin_Name;
        public Sprite bitamin_image;
    }
    public Bitamin_Struct[] bitamin_list;
    public Bitamin_Struct WhatBitamin(Bitamin_kind bitamin)
    {
        for (int i = 0; i < bitamin_list.Length; i++)
        {
            if (bitamin_list[i].bitamin == bitamin)
            {
                return bitamin_list[i];
            }
        }
        return bitamin_list[0];
    }

    /// <summary>
    /// 장비
    /// </summary>

    [Serializable]
    public struct Eqip_Struct
    {
        public Eqip_kind eqip;
        public string eqip_Name;
        public Sprite eqip_image;
        public bool eqip_kind;
        public string grade; // 등급 
        public string specialization; // 특화
        public int atk;
        public float atk_width;
        public float atk_generation_percent;
        public float critical;
        public float critical_width;
        public float critical_generation_percent;
        public float shield;
        public float shield_width;
        public float shield_generation_percent;
        public int hp;
        public float hp_width;
        public float hp_generation_percent;
        public float atkspeed;
        public float atkspeed_width;
        public float atkspeed_generation_percent;
        public float speed;
        public float speed_width;
        public float speed_generation_percent;
    }
    public Eqip_Struct[] eqip_list;
    public Eqip_Struct WhatEqip(Eqip_kind eqip)
    {
        for (int i = 0; i < eqip_list.Length; i++)
        {
            if (eqip_list[i].eqip == eqip)
            {
                return eqip_list[i];
            }
        }
        return eqip_list[0];
    }

}
public enum Bitamin_kind
{
    Null,
    bitamin10,
    bitamin100
}

public enum Eqip_kind
{
    Null,
    끈리본,
    사탕머리띠,
    나뭇잎브로치,
    나비리본,
    무지개머리띠,
    스마일브로치,
    별리본,
    안개꽃화환,
    당근판박이,
    최신형만보기,
    장비화환,
    잉어판박이,
    음이온목걸이,
    해바라기화환,
    용판박이
}

public enum Food_kind
{
    Null
}

public enum Skill_item_kind
{
    Null
}
