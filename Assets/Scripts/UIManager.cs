using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] [Header("플레이어가 근접했을때, 제단위에 띄우는 판넬")] GameObject answerPanel;
    [SerializeField] [Header("제단 위에 띄우는 판넬의 텍스트")] Text answerPanelText;
    [SerializeField] [Header("퀴즈를 내는 창")] GameObject quizPanel;

    public static UIManager Instance = null;

    private bool upgradeResult = false;
    private GameObject whereIsOutPut = null;

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

    public void CallAnswerPanel(Transform whereIsIt, bool upgraded)
    {
        whereIsOutPut = whereIsIt.gameObject;
        if (!upgraded)
        {
            answerPanel.transform.position = new Vector2(whereIsIt.position.x - 2, whereIsIt.position.y + 1.75f);
            answerPanelText.text = "제단을 터치해 동작시키십시오!";
            answerPanel.SetActive(true);
        }
        else
        {
            if(upgradeResult)
            {
                answerPanelText.text = "업드레이드를 성공하였습니다!";
            }
            else
            {
                answerPanelText.text = "업그레이드를 실패하였습니다..";
            }

            answerPanel.transform.position = new Vector2(whereIsIt.position.x - 2, whereIsIt.position.y + 1.75f);
            answerPanel.SetActive(true);
        }
    }
    
    public void ResetAnswerPanel()
    {
        answerPanel.SetActive(false);
    }

    public void CallQuizPanel(Sheet1Data itemData)
    {
        quizPanel.GetComponent<RectTransform>().DOAnchorPosY(0, 3).SetEase(Ease.InOutQuart);
        QuizPanel quizPanelData = quizPanel.GetComponent<QuizPanel>();
        quizPanelData.atk.text = $"공격력 : {itemData.Atk.ToString()}";
        quizPanelData.hp.text = $"체력 : {itemData.Hp.ToString()}";
        quizPanelData.type.text = $"타입 : {itemData.Pattern}";
        quizPanelData.itemNameInEng.text = itemData.Name_Eng;
        quizPanelData.itemNameInKor.text = itemData.Name_Kor;
        quizPanelData.info.text = itemData.Info;

        quizPanelData.easyDiffcultyBtn.onClick.AddListener(()=> SetEasyDiffculty(quizPanelData));

    }

    public void SetEasyDiffculty(QuizPanel quizPanelData)
    {
        quizPanelData.atk.text += " X 1.2";
        quizPanelData.hp.text += " X 1.2";
        quizPanelData.easyInput.gameObject.SetActive(true);
        quizPanelData.easyDiffcultyBtn.gameObject.SetActive(false);
        quizPanelData.normalDiffcultyBtn.gameObject.SetActive(false);
        quizPanelData.hardDiffcultyBtn.gameObject.SetActive(false);
        quizPanelData.checkAnswerBtn.gameObject.SetActive(true);
        quizPanelData.multiplication.gameObject.SetActive(true);
        quizPanelData.multiplicationText.text = "정답을 맞출 시 1.2배!";

        quizPanelData.checkAnswerBtn.onClick.AddListener(() => checkBtnInEasy(quizPanelData));
        quizPanelData.easyDiffcultyBtn.onClick.RemoveAllListeners();
    }

    public void checkBtnInEasy(QuizPanel quizPanelData)
    {
        if(quizPanelData.easyInput.text == quizPanelData.itemNameInKor.text)
        {
            upgradeResult = true;
        }
        else
        {
            upgradeResult = false;
        }

        whereIsOutPut.GetComponent<RandomOutputWeapon>().isAleadyOutItem = true;
        RemoveQuizPanel();
    }

    public void RemoveQuizPanel()
    {
        QuizPanel quizPanelData = quizPanel.GetComponent<QuizPanel>();

        quizPanelData.checkAnswerBtn.onClick.RemoveAllListeners();
        quizPanelData.easyDiffcultyBtn.onClick.RemoveAllListeners();
        quizPanelData.hardDiffcultyBtn.onClick.RemoveAllListeners();
        quizPanelData.normalDiffcultyBtn.onClick.RemoveAllListeners();

        quizPanel.GetComponent<RectTransform>().DOAnchorPosY(1400, 3).SetEase(Ease.InOutQuart);
    }
}
