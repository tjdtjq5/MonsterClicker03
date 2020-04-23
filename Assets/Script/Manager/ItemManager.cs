using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    [Serializable]
    public struct itemStruct
    {
        public itemKind item;
        public string itemName;
        public Sprite itemImage;
    }

    public itemStruct[] itemList;

    public itemStruct WhatItem(itemKind item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i].item == item)
            {
                return itemList[i];
            }
        }
        return itemList[0];
    }

}
public enum itemKind
{
    Null,
    atkEnhance,
    hpEnhance,
    speedEnhace,
    sheildEnhance,
    criticalEnhance,
    atkSpeedEnhance,
    expPercentEnhance,
    albaMoneyEnhace
}
