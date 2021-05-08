using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityQuickSheet;

public class GameManager : MonoSingleton<GameManager>
{
    Dictionary<string, Sheet1Data> dataBase = new Dictionary<string, Sheet1Data>();

    [SerializeField] Sheet1 dataSheet = null;

    public Dictionary<string, Sheet1Data> DataBase
    {
        get { return dataBase; } private set { dataBase = value; }
    }
    public Sheet1 DataSheet
    {
        get { return dataSheet; } private set { dataSheet = value; }
    }

    public void OnEnable()
    {
        InputData();
    }

    public void InputData()
    {
        if(DataSheet == null)
        {
            Debug.LogWarning("DataSheet�� �������� �ʽ��ϴ�!");
            return;
        }

        DataBase.Clear(); // Data���̽��� ���� �ֱ� �� �ѹ� �����.
        for (int i = 0; i < DataSheet.dataArray.Length; i++)
        {
            DataBase.Add(DataSheet.dataArray[i].Name, DataSheet.dataArray[i]);
            Debug.Log(DataSheet.dataArray[i].Name);
        }
    }

    // TODO ���� ������ �̵��ϸ� ������ ���� ������ ����.
}
