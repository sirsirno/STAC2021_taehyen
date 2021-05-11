using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityQuickSheet;

public class GameManager : MonoSingleton<GameManager>
{
    // ���� ������ �̵��ϴ� ���߿��� �־���� �����͵��� �����ϴ� �Ŵ����Դϴ�.

    Dictionary<string, Sheet1Data> dataBase = new Dictionary<string, Sheet1Data>();
    List<string> nameData = new List<string>();

    [SerializeField] Sheet1 dataSheet = null;

    public List<string> NameData { get { return nameData; } private set { nameData = value; } }
    public Dictionary<string, Sheet1Data> DataBase { get { return dataBase; } private set { dataBase = value; } }
    public GameObject player{get; private set;}
    public void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerMove>().gameObject;
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
            NameData.Add(dataSheet.dataArray[i].Name);
            DataBase.Add(dataSheet.dataArray[i].Name, dataSheet.dataArray[i]);
        }
    }

}
