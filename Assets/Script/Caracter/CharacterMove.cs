using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CharacterMove : MonoBehaviour
{
    [Header ("움직임")]
    public float speed;
    public Transform[] movePoint;
    public Transform[] enemyPoint;

    [Header("공격")]
    public LayerMask enemyLayer;
    public float range;
    public float atkSpeed;
    public GameObject[] missile;
    public Transform[] missilePos;
    public AudioClip atkSound;

    [Header("허수아비")]
    public GameObject scarowHp_bar;
    public Text scarowHpText;

    Vector3[] temp;
    int iCount;
    

    public void Start()
    {
        temp = new Vector3[movePoint.Length];
        for(int i=0; i<movePoint.Length; i++)
        {
            temp[i] = new Vector3(movePoint[i].position.x, this.transform.position.y, movePoint[i].position.z);
        }
        mySequence = DOTween.Sequence();
    }

    bool attackFlag;
    bool isAttack;
    Sequence mySequence;
    public void Update()
    {

        if (!isAttack)
        {
            mySequence.Append(this.transform.DOLookAt(new Vector3(temp[iCount].x, this.transform.position.y, temp[iCount].z), 1.5f));
         
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(temp[iCount].x, this.transform.position.y, temp[iCount].z), GameManager.instance.GetSpeed() * Time.deltaTime);
        }

        if (Vector3.Distance(this.transform.position, new Vector3(temp[iCount].x, this.transform.position.y, temp[iCount].z)) <= 0.3f)
        {
            iCount++;
            if (iCount == movePoint.Length)
            {
                iCount = 0;
            }
        }

        
        if(!attackFlag)
        {
            for(int i=0; i<enemyPoint.Length; i++)
            {
                if(enemyPoint[i].gameObject.activeSelf && Vector3.Distance(this.transform.position, new Vector3(enemyPoint[i].position.x, this.transform.position.y, enemyPoint[i].position.z)) < range)
                {
                    isAttack = true;
                    attackFlag = true;
                    enemyObj = enemyPoint[i].gameObject;
                    enemyObj.GetComponent<Enemy>().SetHp_barPannel();
                    Attack();
                }
            }
    
        }
    }

    GameObject enemyObj;
    bool CheckEnemy()
    {
        if (Vector3.Distance(this.transform.position, new Vector3(enemyObj.transform.position.x, this.transform.position.y, enemyObj.transform.position.z)) < range)
        {
           
            StartCoroutine(LookCoroutine());
            return true;
        }
        scarowHp_bar.SetActive(false);
        return false;
    }

    IEnumerator LookCoroutine()
    {
        mySequence.Append(this.transform.DOLookAt(new Vector3(enemyObj.transform.position.x, this.transform.position.y, enemyObj.transform.position.z), 0.2f));
        yield return new WaitForSeconds(0.1f);
        mySequence.Append(this.transform.DOLookAt(new Vector3(enemyObj.transform.position.x, this.transform.position.y, enemyObj.transform.position.z), 2f));
    }

    void Attack()
    {
        if (!CheckEnemy())
        {
            isAttack = false;
            attackFlag = false;
            return;
        }
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
       

        this.GetComponent<AudioSource>().clip = atkSound;
        this.GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(0.1f);

        if (missile.Length > 0)
        {

            for (int i = 0; i < missile.Length; i++)
            {
                missile[i].transform.position = missilePos[i].position;
                missile[i].GetComponent<Missile>().enemyObj = enemyObj;

                missile[i].transform.DOLookAt(new Vector3(enemyObj.transform.position.x, missile[i].transform.position.y, enemyObj.transform.position.z),0f);
            }
        }


        if (atkSpeed > 0)
            Invoke("Attack", GameManager.instance.GetAtkSpeed());
    }

  
}
