using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] [Header("플레이어가 근접했을때, 제단위에 띄우는 판넬")] GameObject AnswerPanel;
    [SerializeField] [Header("제단 위에 띄우는 판넬의 텍스트")] Text AnswerPanelText;

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

    public void CallAnswerPanel(Transform whereIsIt)
    {
        AnswerPanel.transform.position = new Vector2(whereIsIt.position.x - 2, whereIsIt.position.y + 1.75f);
        AnswerPanelText.text = "제단을 터치해 동작시키십시오!";
        AnswerPanel.SetActive(true);
    }
    public void CallUpgradeResult(bool isUpgradeSuccess, Transform whereIsIt)
    {
        AnswerPanel.transform.position = new Vector2(whereIsIt.position.x - 2, whereIsIt.position.y + 1.75f);
        if (isUpgradeSuccess)
            AnswerPanelText.text = "업드레이드를 성공하였습니다!";
        else
            AnswerPanelText.text = "업그레이드를 실패하였습니다..";
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
