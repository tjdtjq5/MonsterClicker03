using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenManager : MonoBehaviour
{
    [Header ("Hp_bar")]
    public Transform player_hp_bar;
    public Transform enemy_hp_bar;
    [Header("character")]
    public GameObject player;
    public GameObject enemy;
    [Header("shadow")]
    public GameObject player_shadow;
    public GameObject enemy_shadow;
    [Header("etc...")]
    public EnemyInfo enemyInfo;

    Scrollbar player_hp_scroll;
    Scrollbar enemy_hp_scroll;
    Text player_hp_text;
    Text enemy_hp_text;

    int player_origin_hp;
    int enemy_origin_hp;

    public void InitialScreen(int player_origin_hp, int enemy_origin_hp)
    {
        player_hp_scroll = player_hp_bar.Find("hp_bar").GetComponent<Scrollbar>();
        player_hp_scroll.size = 1;
        enemy_hp_scroll = enemy_hp_bar.Find("hp_bar").GetComponent<Scrollbar>();
        enemy_hp_scroll.size = 1;
        player_hp_text = player_hp_bar.Find("hp_bar").Find("Text").GetComponent<Text>();
        player_hp_text.text = player_origin_hp + "/" + player_origin_hp;
        enemy_hp_text = enemy_hp_bar.Find("hp_bar").Find("Text").GetComponent<Text>();
        enemy_hp_text.text = enemy_origin_hp + "/" + enemy_origin_hp;
        this.player_origin_hp = player_origin_hp;
        this.enemy_origin_hp = enemy_origin_hp;

        player_hp_bar.Find("레벨").GetComponent<Text>().text = "Lv " + GameManager.instance.userInfo.GetLevel();
        enemy_hp_bar.Find("레벨").GetComponent<Text>().text = "Lv " + enemyInfo.level;
    }

    public void SetPlayerHpBar(int player_hp)
    {
        player_hp_scroll.size = (float)player_hp / player_origin_hp;
        player_hp_text.text = player_hp + "/" + player_origin_hp;
    }

    public void SetEnemyHpBar(int enemy_hp)
    {
        enemy_hp_scroll.size = (float)enemy_hp / enemy_origin_hp;
        enemy_hp_text.text = enemy_hp + "/" + enemy_origin_hp;
    }


}
