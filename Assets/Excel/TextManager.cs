using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    Dictionary<int,string[]> data;
    public test testSheet;
    void Start()
    {
        data = new Dictionary<int, string[]>();
        loadingText();
    }
    void loadingText(){//여기에서 엑셀파일을 data라는 데이터베이스에 불러옴.
        for(int i=0;testSheet.dataArray[i].Stringnumber!=0;i++){//첫번째 칸부터 0이될때까지 탐색.
            data.Add(testSheet.dataArray[i].Stringnumber-1, testSheet.dataArray[i].Word);//추가(Stringnumber는 1부터 시작하기때문에 1을빼줌).
            //Debug.Log(testSheet.dataArray[i].Word[0]);
            Debug.Log(data[i][0]);
        }
    }

    void Update()
    {
        
    }
}
