using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradation : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 endPos;
    public float speed;

    public void Start()
    {
        this.transform.localPosition = startPos;
    }

    public void Update()
    {
        this.transform.localPosition = Vector2.MoveTowards(this.transform.localPosition, endPos, speed);
        if(Vector2.Distance(this.transform.localPosition, endPos) <= 0)
        {
            this.transform.localPosition = startPos;
        }
    }
}
