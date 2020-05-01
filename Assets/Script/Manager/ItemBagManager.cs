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
    public GameObject[] eqip_btn;

    [Header("Etc...")]
    public Transform pannel;
    public GameObject click_image;


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

    public void OnClickExit()
    {
        cam_main.SetActive(true);
        cam_ui.SetActive(true);
        Item_obj.SetActive(false);
    }

    public void OnClick_EqipBtn(int index)
    {
        if (!eqipBtn_flag)
        {
            for (int i = 0; i < eqip_btn.Length; i++)
            {
                if(i == index)
                {
                    eqip_btn[i].transform.DOScale(new Vector3(1, 1, 1), 0.3f);
                }
                else
                {
                    eqip_btn[i].transform.DOScale(new Vector3(.8f, .8f, .8f), 0.3f);
                }
            }
            StartCoroutine(OnClick_EqipBtn_Coroutine());
        }
    }
    bool eqipBtn_flag;
    IEnumerator OnClick_EqipBtn_Coroutine()
    {
        eqipBtn_flag = true;
        yield return new WaitForSeconds(0.3f);
        eqipBtn_flag = false;
    }

    //아이템 아이콘 클릭 

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

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 10f);
            if (hit)
            {
                string name = hit.transform.gameObject.name;
                if (name.Contains("아이템_칸"))
                {
                    string temp_num = name.Split('(')[1];
                    int num = int.Parse(temp_num.Split(')')[0]);
                    Set_ItemClick(num);
                }
            }
        }
    }

    void Set_ItemClick(int num)
    {
        if (click_flag)
            return;

        click_image.SetActive(false);
        click_image.SetActive(true);
        ClickCoroutine = Click_Image_Coroutine(num);
        StartCoroutine(ClickCoroutine);
    }
    IEnumerator ClickCoroutine;

    bool click_flag;
    IEnumerator Click_Image_Coroutine(int num)
    {
        click_flag = true;
        click_image.transform.position = pannel.GetChild(num).transform.position;
        click_image.GetComponent<Animator>().SetBool("click", true);
        yield return new WaitForSeconds(0.25f);
        click_image.GetComponent<Animator>().SetBool("click", false);
        click_flag = false;
    }
}
