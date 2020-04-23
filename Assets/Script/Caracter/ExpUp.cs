using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUp : MonoBehaviour
{
   

    [Header("파티클 , 스크롤 바 , 텍스트")]
    public ParticleSystem levelUpParticle;
    public Scrollbar expScrollbar;
    public Text expText;

    [Header("말풍선")]
    public SpeechBubble speechBubble;

    [Header("INFO")]
    public Info info;

    public void EUp(int getExp)
    {
        StartCoroutine(ExpUpCoroutine(getExp));
    }

    IEnumerator ExpUpCoroutine(int getExp)
    {
        float tempExp = GameManager.instance.userInfo.GetExp() + getExp;
        while (tempExp >= howManyExp())
        {
            tempExp -= howManyExp();
            LevelUp();
            yield return new WaitForSeconds(0.1f);
        }
        GameManager.instance.userInfo.SetExp(tempExp);
        expText.text = "경험치 : " + Mathf.Round((tempExp / howManyExp() * 100) ) + "%";
        expScrollbar.size = tempExp / howManyExp();
    }

    void LevelUp()
    {
        levelUpParticle.Play();
        speechBubble.SpeechInput("레벨 업 ~ ", true);
        GameManager.instance.userInfo.SetLevel(GameManager.instance.userInfo.GetLevel() + 1);
        info.SetInfoAll();
    }

    float howManyExp()
    {
        int G = 100 + ((GameManager.instance.userInfo.GetLevel() / 10) * 500);
        return ((GameManager.instance.userInfo.GetLevel() - 1) * 1.2f * G) + G;
    }


}
