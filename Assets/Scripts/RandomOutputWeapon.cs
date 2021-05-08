using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityQuickSheet;

public class RandomOutputWeapon : MonoBehaviour
{
    [SerializeField] float outPutCool;

    private Sheet1Data data;

    private bool isOutput;

    private void Update()
    {


        if(Input.GetMouseButtonDown(0) && !isOutput)
        {
            isOutput = true;
            Sheet1Data item;
            item = PickRandomWeapon();
            Debug.Log($"무기의 이름은 {item.Name}입니다!");
            Invoke("ResetCoolTime", outPutCool);
        }
    }


    Sheet1Data PickRandomWeapon()
    {
        Sheet1Data item;
        int randNum;

        randNum = Random.Range(0, GameManager.Instance.NameData.Count - 1);
        item = GameManager.Instance.DataBase[GameManager.Instance.NameData[randNum]];

        return item;
    }

    void ResetCoolTime()
    {
        isOutput = false;
    }

}
