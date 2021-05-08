using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField][Header("�÷��̾ ����������, �������� ���� �ǳ�")]  GameObject AnswerPanel;

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

    void CallAnswerPanel()
    {
        AnswerPanel.SetActive(true);
    }
    void ResetAnswePanel()
    {
        AnswerPanel.SetActive(false);
    }


}
