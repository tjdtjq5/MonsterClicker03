using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class StroyCaracterSetting : MonoBehaviour
{
    [Header("캐릭터 이미지")]
    public Image caracter_image;
    [Header("스크립트 텍스트")]
    public Text text;

    [Header("연희")]
    public Sprite[] yunhei;
    [Header("미소")]
    public Sprite[] misso;
    [Header("예빈")]
    public Sprite[] yaebin;
    [Header("호진")]
    public Sprite[] hojin;
    [Header("데니스 킴")]
    public Sprite[] denis_kim;
    [Header("영기")]
    public Sprite[] yeunggi;

    [Header("캐릭터 이미지 전환 텍스트")]
    public ScriptStruct[] scriptStructs;

    public void Start()
    {
        Vector2 current = StageInfo.Stage;
        switch ((int)current.x)
        {
            case 1:
                switch ((int)current.y)
                {
                    case 1:
                        caracter_image.sprite = misso[0];
                        break;
                    case 2:
                        caracter_image.sprite = yaebin[0];
                        break;
                    case 3:
                        caracter_image.sprite = hojin[0];
                        break;
                    case 4:
                        caracter_image.sprite = denis_kim[0];
                        break;
                    case 5:
                        caracter_image.sprite = yeunggi[0];
                        break;
                }
                break;
        }
    }

    [Serializable]
    public struct ScriptStruct
    {
        public string script;
        public Sprite sprite_caracter;
    }

    public void SetCaracter()
    {
        string script_text = text.text;
        for (int i = 0; i < scriptStructs.Length; i++)
        {
            if(scriptStructs[i].script.Contains(script_text))
            {
                caracter_image.sprite = scriptStructs[i].sprite_caracter;
            }
        }
    }
}
