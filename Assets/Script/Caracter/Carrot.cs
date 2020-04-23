using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    public GameObject carrot;
    Animator theAni;
    void Start()
    {
        theAni = carrot.GetComponent<Animator>();
        theAni.SetBool("isMove", true);
    }
  
}
