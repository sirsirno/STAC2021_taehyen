using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomOutputWeapon : MonoBehaviour
{
    [SerializeField] Sheet1 dataSheet;
    [SerializeField] float outPutCool;

    private Sheet1Data data;

    private bool isOutput;
    
    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isOutput)
        {
            isOutput = true;
            Sheet1Data item;
            item = PickRandomWeapon(dataSheet);
            Debug.Log($"무기의 이름은 {item.Name}입니다!");
            Invoke("ResetCoolTime", outPutCool);
        }
    }


    Sheet1Data PickRandomWeapon(Sheet1 dataSheet)
    {
        Sheet1Data item;
        int randNum;
        randNum = Random.Range(0, dataSheet.dataArray.Length);
        item = dataSheet.dataArray[randNum];

        return item;
    }

    void ResetCoolTime()
    {
        isOutput = false;
    }

}
