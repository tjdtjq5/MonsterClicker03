using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhanceManager : MonoBehaviour
{
    [Serializable]
    public struct enhanceStruct
    {
        public EnhanceKind enhance;
        public string enhanceName;
        public float percent;
    }

    public enhanceStruct[] enhanceList;

    public enhanceStruct WhatEnhace(EnhanceKind enhace)
    {
        for(int i=0; i< enhanceList.Length; i++)
        {
            if(enhanceList[i].enhance == enhace)
            {
                return enhanceList[i];
            }
        }
        return enhanceList[0];
    }
}

public enum EnhanceKind
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

