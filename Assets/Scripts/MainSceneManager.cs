using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    //���� �� �ȿ����� �����ϴ� �����͵��� �������ִ� �Ŵ����Դϴ�.
    [SerializeField] GameObject Player;

    static public MainSceneManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }

}
