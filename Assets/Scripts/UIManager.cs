using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] [Header("�÷��̾ ����������, �������� ���� �ǳ�")] GameObject AnswerPanel;
    [SerializeField] [Header("���� ���� ���� �ǳ��� �ؽ�Ʈ")] Text AnswerPanelText;

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

    public void CallAnswerPanel(Transform whereIsIt)
    {
        AnswerPanel.transform.position = new Vector2(whereIsIt.position.x - 2, whereIsIt.position.y + 1.75f);
        AnswerPanelText.text = "������ ��ġ�� ���۽�Ű�ʽÿ�!";
        AnswerPanel.SetActive(true);
    }
    public void CallUpgradeResult(bool isUpgradeSuccess, Transform whereIsIt)
    {
        AnswerPanel.transform.position = new Vector2(whereIsIt.position.x - 2, whereIsIt.position.y + 1.75f);
        if (isUpgradeSuccess)
            AnswerPanelText.text = "���巹�̵带 �����Ͽ����ϴ�!";
        else
            AnswerPanelText.text = "���׷��̵带 �����Ͽ����ϴ�..";
        AnswerPanel.SetActive(true);

    }
    public void ResetAnswePanel()
    {
        AnswerPanel.SetActive(false);
    }

    public void CallQuizPanel()
    {

    }


}
