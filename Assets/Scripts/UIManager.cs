using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    private void Awake()
    {

#if UNITY_EDITOR
        if (Instance != null)
            Debug.Log("UIManager�� �̹� �����մϴ�! ġ������ ������ ����ų�� �ֽ��ϴ�.");
#endif

        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }



}
