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

    [Header("라운드 텍스트")]
    public GameObject roundText;

    public void Summon()
    {
        trunPannel.transform.position = originPos.position;
    }

    bool flag;
    bool summon_flag;
    public void SummonBtn()
    {
        if (!flag && !summon_flag)
        {
            summon_flag = true;
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
    }
    public void EnemyTrun()
    {
        trunPannel.transform.position = originPos.position;
    }
    public void TurnEnd(int round)
    {
        StartCoroutine(TurnEndCoroutine(round));
    }

    IEnumerator TurnEndCoroutine(int round)
    {
        trunPannel.transform.position = originPos.position;
        roundText.GetComponent<Text>().text = round + "라운드";
        roundText.GetComponent<Animator>().SetBool("Round", true);
        yield return new WaitForSeconds(1.7f);
        roundText.GetComponent<Animator>().SetBool("Round", false);
        TrunStart();
        battleManager.AutoAttack();
    }


}
