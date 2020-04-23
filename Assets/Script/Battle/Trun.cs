using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Trun : MonoBehaviour
{
    public Transform originPos;
    public GameObject trunPannel;

    public GameObject player;
    public GameObject enemy;
    public GameObject playerShadow;
    public GameObject enemyShadow;

    public BattleManager battleManager;

    public void Summon()
    {
        trunPannel.transform.position = originPos.position;
        trunPannel.transform.GetChild(0).GetComponent<Text>().text = "몬스터 소환";
    }

    bool flag;
    public void SummonBtn()
    {
        if (!flag && trunPannel.transform.GetChild(0).GetComponent<Text>().text.Contains("몬스터 소환"))
        {
            StartCoroutine(SummonBtnCoroutine());
        }
    }
    IEnumerator SummonBtnCoroutine()
    {
        flag = true;
        player.SetActive(true);
        enemy.SetActive(true);
        playerShadow.SetActive(true);
        enemyShadow.SetActive(true);
        player.GetComponent<Animator>().SetBool("summon", true);
        enemy.GetComponent<Animator>().SetBool("summon", true);
        yield return new WaitForSeconds(1f);
        player.GetComponent<Animator>().SetBool("summon", false);
        enemy.GetComponent<Animator>().SetBool("summon", false);
        trunPannel.transform.position = new Vector2(1500, 1500);
        flag = false;
    }

    public void TrunStart()
    {
        trunPannel.transform.position = new Vector2(1500, 1500);



    }
    public void PlayerTrun()
    {
        trunPannel.transform.position = originPos.position;
        trunPannel.transform.GetChild(0).GetComponent<Text>().text = "플레이어 턴";
    }
    public void EnemyTrun()
    {
        trunPannel.transform.position = originPos.position;
        trunPannel.transform.GetChild(0).GetComponent<Text>().text = "적 턴";
    }
    public void TurnEnd(int round)
    {
        trunPannel.transform.position = originPos.position;
        trunPannel.transform.GetChild(0).GetComponent<Text>().text = "";
        string text = round + "라운드";
        trunPannel.transform.GetChild(0).GetComponent<Text>().DOText(text, 1f).OnComplete(()=> { TrunStart();
            battleManager.AutoAttack();
        });


        
    }




}
