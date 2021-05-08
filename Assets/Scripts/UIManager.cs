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
            Debug.Log("UIManager가 이미 존재합니다! 치명적인 오류를 일으킬수 있습니다.");
#endif

        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }



}
