using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityQuickSheet;

public class RandomOutputWeapon : MonoBehaviour
{
    [SerializeField] float outPutCool = 2f;
    [SerializeField] [Header("�÷��̾�� ������ ��û�ϴ� �ǳ��� ���� �Ÿ��Դϴ�.")] float outAnswerPanelDist = 1f;

    private Sheet1Data data;

    private bool isOutput;

    private void Update()
    {
        if(Vector2.Distance(MainSceneManager.Instance.Player.transform.position, this.transform.position) >= outAnswerPanelDist)
        { // �÷��̾ ���ܿ� ���� ���� ��.
            UIManager.Instance.CallAnswerPanel(this.transform);
            if (Input.GetMouseButtonDown(0) && !isOutput)
            {
                if(isTouch())
                {
                    isOutput = true;
                    Sheet1Data item;
                    item = PickRandomWeapon();
                    Debug.Log($"������ �̸��� {item.Name}�Դϴ�!");
                    Invoke("ResetCoolTime", outPutCool);
                }
            }
        }
    }


    Sheet1Data PickRandomWeapon()
    {
        Sheet1Data item;
        int randNum;

        randNum = Random.Range(0, (GameManager.Instance.NameData.Count - 1));
        Debug.Log(randNum);
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

    void ResetCoolTime()
    {
        isOutput = false;
    }

}
