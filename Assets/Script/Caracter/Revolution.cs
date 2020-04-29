using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{
    public int currentRevolution;

    [SerializeField]
    GameObject[] rabbit_meshRenderer;

    private void Start()
    {
        Set();
    }

    public void Revolution_Rabbit()
    {
       
        if(!(currentRevolution >= rabbit_meshRenderer.Length -1))
            currentRevolution++;

        Set();
    }

    void Set()
    {
        for (int i = 0; i < rabbit_meshRenderer.Length; i++)
        {
            rabbit_meshRenderer[i].SetActive(false);
        }

        rabbit_meshRenderer[currentRevolution].SetActive(true);

        if (this.gameObject.tag == "UI")
        {
            if (currentRevolution == 0)
            {
                this.transform.localPosition = new Vector3(-1.37f, -2.87f, this.transform.localPosition.z);
            }
            else
            {
                this.transform.localPosition = new Vector3(-0.87f, -1.94f, this.transform.localPosition.z);
            }
        }

        if (this.gameObject.tag == "Item")
        {
            //if (currentRevolution == 0)
            //{
            //    this.transform.localPosition = new Vector3(this.transform.localPosition.x + 5f,
            //        this.transform.localPosition .y - 2.2f, this.transform.localPosition.z - 1.2f);
            //}
            //else
            //{
            //    this.transform.localPosition = new Vector3(this.transform.localPosition.x- 0.87f,
            //        this.transform.localPosition.y - 1.94f, this.transform.localPosition.z);
            //}
        }
    }





}
