using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField][Header("플레이어가 근접했을때, 제단위에 띄우는 판넬")]  GameObject AnswerPanel;

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

    void CallAnswerPanel()
    {
        AnswerPanel.SetActive(true);
    }
    void ResetAnswePanel()
    {
        AnswerPanel.SetActive(false);
    }


}
