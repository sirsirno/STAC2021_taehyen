using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    static public MainSceneManager Instance = null;
    //���� �� �ȿ����� �����ϴ� �����͵��� �������ִ� �Ŵ����Դϴ�.
    [SerializeField] GameObject player;
 
    public GameObject Player { get { return player; } private set { player = value; } }

    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }

}
