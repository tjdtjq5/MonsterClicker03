using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    public GameObject clickParticle;
    public Camera theCam;
    public AudioClip clickSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 position = new Vector2(Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2));
            this.transform.localPosition = position;
            clickParticle.GetComponent<ParticleSystem>().Play();
            this.GetComponent<AudioSource>().clip = clickSound;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
