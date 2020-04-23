using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [HideInInspector]
    public GameObject enemyObj;
    public GameObject hitParticle;
    Transform hitPos;

    float posZ;


    private void Update()
    {
        if (enemyObj != null)
        {
       
            this.transform.position = Vector3.MoveTowards(this.transform.position ,new Vector3(enemyObj.transform.position.x , this.transform.position.y , enemyObj.transform.position.z),  23 * Time.deltaTime);
            posZ = this.transform.position.z;
            //this.GetComponent<Rigidbody>().velocity = Vector3.back * 20f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == enemyObj)
        {
            this.transform.position = new Vector3(500, 500, 500);
            hitPos = enemyObj.transform.Find("HitPos");
            hitParticle.transform.position = hitPos.transform.position;
            hitParticle.GetComponent<ParticleSystem>().Play();
            enemyObj.GetComponent<Animator>().SetTrigger("Hit");

            int damage = GameManager.instance.GetAtk(GameManager.instance.userInfo.GetLevel(), GameManager.instance.userInfo.GetEnhance(EnhanceKind.atkEnhance));
            int tempCritical = (int)GameManager.instance.GetCritical();
            int rand = Random.RandomRange(1, 101);
            if (tempCritical >= rand)
                damage *= 2;

            enemyObj.GetComponent<Enemy>().Damage(damage);

     
        }
    }
}
