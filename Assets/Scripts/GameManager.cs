using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityQuickSheet;

public class GameManager : MonoSingleton<GameManager>
{

    Dictionary<string, Sheet1Data> dataBase = new Dictionary<string, Sheet1Data>();

    [SerializeField] Sheet1 dataSheet = null;

    public Dictionary<string, Sheet1Data> DataBase { get { return dataBase; } private set { dataBase = value; } }

    public void OnEnable()
    {
        InputData();
    }

    public void InputData()
    {
        if(dataSheet == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning("DataSheet�� �������� �ʽ��ϴ�!");
#endif
            return;
        }

        DataBase.Clear(); // Data���̽��� ���� �ֱ� �� �ѹ� �����.
        for (int i = 0; i < dataSheet.dataArray.Length; i++)
        {
            DataBase.Add(dataSheet.dataArray[i].Name, dataSheet.dataArray[i]);
            Debug.Log(DataBase[dataSheet.dataArray[i].Name].Name);
        }
    }

    // TODO ���� ������ �̵��ϸ� ������ ���� ������ ����.
}
