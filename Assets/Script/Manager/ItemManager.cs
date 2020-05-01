using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
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

}
public enum Bitamin_kind
{
    Null,
    bitamin10,
    bitamin100
}

public enum Eqip_kind
{
    Null
}

public enum Food_kind
{
    Null
}

public enum Skill_item_kind
{
    Null
}
