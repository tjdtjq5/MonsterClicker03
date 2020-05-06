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
        public int atk;
        public float shield;
        public int hp;
        public float critical;
        public float atkspeed;
        public float speed;
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
    testitem
}

public enum Food_kind
{
    Null
}

public enum Skill_item_kind
{
    Null
}
