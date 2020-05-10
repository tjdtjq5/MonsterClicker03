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
        public string eqip_Name;
        public Eqip_kind eqip;
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


    private void Awake()
    {
        for (int i = 0; i < eqip_list.Length; i++)
        {
            List<string> dataList = this.GetComponent<DatabaseManager>().Eqip_Item_DB.GetRowData(i + 1);
            eqip_list[i].eqip_Name = dataList[3];
            eqip_list[i].grade = dataList[2];
            eqip_list[i].specialization = dataList[4];

            float outFloat;
            if (float.TryParse(dataList[5], out outFloat))
                eqip_list[i].atk = (int)outFloat;
            else
                eqip_list[i].atk = 0;

            if (float.TryParse(dataList[6], out outFloat))
                eqip_list[i].atk_width = outFloat;
            else
                eqip_list[i].atk_width = 0;

            if (float.TryParse(dataList[7], out outFloat))
                eqip_list[i].atk_generation_percent = outFloat;
            else
                eqip_list[i].atk_generation_percent = 0;

            if (float.TryParse(dataList[8], out outFloat))
                eqip_list[i].critical = outFloat;
            else
                eqip_list[i].critical = 0;

            if (float.TryParse(dataList[9], out outFloat))
                eqip_list[i].critical_width = outFloat;
            else
                eqip_list[i].critical_width = 0;

            if (float.TryParse(dataList[10], out outFloat))
                eqip_list[i].critical_generation_percent = outFloat;
            else
                eqip_list[i].critical_generation_percent = 0;

            if (float.TryParse(dataList[11], out outFloat))
                eqip_list[i].shield = outFloat;
            else
                eqip_list[i].shield = 0;

            if (float.TryParse(dataList[12], out outFloat))
                eqip_list[i].shield_width = outFloat;
            else
                eqip_list[i].shield_width = 0;

            if (float.TryParse(dataList[13], out outFloat))
                eqip_list[i].shield_generation_percent = outFloat;
            else
                eqip_list[i].shield_generation_percent = 0;

            if (float.TryParse(dataList[14], out outFloat))
                eqip_list[i].hp = (int)outFloat;
            else
                eqip_list[i].hp = 0;

            if (float.TryParse(dataList[15], out outFloat))
                eqip_list[i].hp_width = outFloat;
            else
                eqip_list[i].hp_width = 0;

            if (float.TryParse(dataList[16], out outFloat))
                eqip_list[i].hp_generation_percent = outFloat;
            else
                eqip_list[i].hp_generation_percent = 0;

            if (float.TryParse(dataList[17], out outFloat))
                eqip_list[i].atkspeed = outFloat;
            else
                eqip_list[i].atkspeed = 0;

            if (float.TryParse(dataList[18], out outFloat))
                eqip_list[i].atkspeed_width = outFloat;
            else
                eqip_list[i].atkspeed_width = 0;

            if (float.TryParse(dataList[19], out outFloat))
                eqip_list[i].atkspeed_generation_percent = outFloat;
            else
                eqip_list[i].atkspeed_generation_percent = 0;

            if (float.TryParse(dataList[20], out outFloat))
                eqip_list[i].speed = outFloat;
            else
                eqip_list[i].speed = 0;

            if (float.TryParse(dataList[21], out outFloat))
                eqip_list[i].speed_width = outFloat;
            else
                eqip_list[i].speed_width = 0;

            if (float.TryParse(dataList[21], out outFloat))
                eqip_list[i].speed_generation_percent = outFloat;
            else
                eqip_list[i].speed_generation_percent = 0;

        }
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
    신문지망토,
    낡은책가방,
    박스날개,
    색종이망토,
    리본장식가방,
    종이날개,
    노란색우비,
    브랜드가방,
    무지개날개,
    비단망토,
    상어지느러미,
    공작새날개,
    무지개망토,
    거북이등껍질,
    천사날개,
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
