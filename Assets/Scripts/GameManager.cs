using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityQuickSheet;

public class GameManager : MonoSingleton<GameManager>
{
    // 여러 씬들을 이동하는 와중에도 있어야할 데이터들을 보관하는 매니저입니다.

    Dictionary<string, Sheet1Data> dataBase = new Dictionary<string, Sheet1Data>();
    List<string> nameData = new List<string>();

    [SerializeField] Sheet1 dataSheet = null;

    public List<string> NameData { get { return nameData; } private set { nameData = value; } }
    public Dictionary<string, Sheet1Data> DataBase { get { return dataBase; } private set { dataBase = value; } }

    public void Awake()
    {
        InputData();
    }

    public void InputData()
    {
        if(dataSheet == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning("DataSheet가 존재하지 않습니다!");
#endif
            return;
        }

        DataBase.Clear(); // Data베이스에 값을 넣기 전 한번 비워줌.
        for (int i = 0; i < dataSheet.dataArray.Length; i++)
        {
            NameData.Add(dataSheet.dataArray[i].Name);
            DataBase.Add(dataSheet.dataArray[i].Name, dataSheet.dataArray[i]);
        }
    }

}
