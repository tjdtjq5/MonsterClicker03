using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public void OnSetActiveTrue()
    {
        this.gameObject.SetActive(true);
    }

    public void OnSetActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
