using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityQuickSheet;

public class RandomOutputWeapon : MonoBehaviour
{
    [SerializeField] float outPutCool = 2f;
    [SerializeField] [Header("플레이어에게 응답을 요청하는 판넬을 띄우는 거리입니다.")] float outAnswerPanelDist = 1f;

    float closePanelTime = 3f;
    float closePanelTimer = 0f;
    private Sheet1Data data;

    private bool isTouched = false;
    public bool isAleadyOutItem = false;

    private void Update()
    {
        if(Vector2.Distance(MainSceneManager.Instance.Player.transform.position, this.transform.position) <= outAnswerPanelDist)
        { // 플레이어가 제단에 근접 했을 때.

            UIManager.Instance.CallAnswerPanel(this.transform, isAleadyOutItem); // 이미 사용됐는지에 따라 다른 결과 출력

            if (Input.GetMouseButtonDown(0) && !isTouched)
            {
                if(isTouch())
                {
                    isTouched = true;
                    Sheet1Data item;
                    item = PickRandomWeapon();
                    UIManager.Instance.CallQuizPanel(item);
                    //Invoke("ResetCoolTime", outPutCool);
                }
            }
            closePanelTimer = 0f;
        }
        else if(closePanelTimer >= closePanelTime)
        {
            UIManager.Instance.ResetAnswerPanel();
        }
        else
        {
            closePanelTimer += Time.deltaTime;
        }

    }


    Sheet1Data PickRandomWeapon()
    {
        Sheet1Data item;
        int randNum;

        randNum = Random.Range(0, (GameManager.Instance.NameData.Count - 1)); 
        item = GameManager.Instance.DataBase[GameManager.Instance.NameData[randNum]];

        return item;
    }

    bool isTouch()
    {

        RaycastHit2D hit;
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        hit = Physics2D.Raycast(ray.origin, ray.direction, 100);

        if (hit == this.gameObject)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
