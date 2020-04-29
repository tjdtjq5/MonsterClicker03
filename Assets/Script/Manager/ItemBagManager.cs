using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ItemBagManager : MonoBehaviour
{
    [Header("Camera")]
    public GameObject cam_main;
    public GameObject cam_ui;

    [Header("Item_bag")]
    public GameObject Item_obj;

    [Header("theCam_rotation")]
    public Transform theCam_rotation;
    public float sensibility;

    [Header("Eqip_btn")]
    public GameObject eqip_btn;

    public void OnClick_itembag()
    {
        cam_main.SetActive(false);
        cam_ui.SetActive(false);
        Item_obj.SetActive(true);
    }

    bool first_touch_flag;
    Vector2 first_touch_pos;

    bool touch_on_flag;
    public void Screen_Touch_On()
    {
        if (!touch_on_flag)
        {
            touch_on_flag = true;
            first_touch_flag = true;
            first_touch_pos = Input.mousePosition;
        }
       
    }

    public void Screen_Touch_Exit()
    {
        StartCoroutine(Screen_Touch_Exit_Coroutine());
    }

    IEnumerator Screen_Touch_Exit_Coroutine()
    {
        first_touch_flag = false;
        theCam_rotation.DOLocalRotate(Vector3.zero, 0.5f);
        yield return new WaitForSeconds(0.5f);
        touch_on_flag = false;
    }

    public void Update()
    {
        if (first_touch_flag)
        {
            float temp_x = Input.mousePosition.x - first_touch_pos.x;
            float temp_y = Input.mousePosition.y - first_touch_pos.y;

            if (temp_y > 0)
                temp_y = 0;

            theCam_rotation.localRotation = Quaternion.Euler(theCam_rotation.localRotation.x + temp_y * sensibility, theCam_rotation.localRotation.y + temp_x * sensibility, theCam_rotation.localRotation.z);
        }
    }

    public void OnClickExit()
    {
        cam_main.SetActive(true);
        cam_ui.SetActive(true);
        Item_obj.SetActive(false);
    }

    bool eqip_btn_flag;
    public void Eqip_right()
    {
        if (!eqip_btn_flag)
        {
            eqip_btn_flag = true;
            StartCoroutine(Eqip_Coroutine("right"));
        }
    }
    public void Eqip_left()
    {
        if (!eqip_btn_flag)
        {
            eqip_btn_flag = true;
            StartCoroutine(Eqip_Coroutine("left"));
        }
    }

    IEnumerator Eqip_Coroutine(string ani)
    {
        eqip_btn.GetComponent<Animator>().SetBool(ani, true);
        yield return new WaitForSeconds(.7f);
        eqip_btn.GetComponent<Animator>().SetBool(ani, false);
        eqip_btn_flag = false;
    }
}
