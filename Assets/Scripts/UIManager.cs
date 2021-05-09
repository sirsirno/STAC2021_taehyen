using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] [Header("�÷��̾ ����������, �������� ���� �ǳ�")] GameObject answerPanel;
    [SerializeField] [Header("���� ���� ���� �ǳ��� �ؽ�Ʈ")] Text answerPanelText;
    [SerializeField] [Header("��� ���� â")] GameObject quizPanel;

    public static UIManager Instance = null;

    private bool upgradeResult = false;
    private GameObject whereIsOutPut = null;

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

    public void CallAnswerPanel(Transform whereIsIt, bool upgraded)
    {
        whereIsOutPut = whereIsIt.gameObject;
        if (!upgraded)
        {
            answerPanel.transform.position = new Vector2(whereIsIt.position.x - 2, whereIsIt.position.y + 1.75f);
            answerPanelText.text = "������ ��ġ�� ���۽�Ű�ʽÿ�!";
            answerPanel.SetActive(true);
        }
        else
        {
            if(upgradeResult)
            {
                answerPanelText.text = "���巹�̵带 �����Ͽ����ϴ�!";
            }
            else
            {
                answerPanelText.text = "���׷��̵带 �����Ͽ����ϴ�..";
            }

            answerPanel.transform.position = new Vector2(whereIsIt.position.x - 2, whereIsIt.position.y + 1.75f);
            MainSceneManager.Instance.Player.GetComponent<PlayerMove>().bCanMove = true;
            answerPanel.SetActive(true);
        }
    }
    
    public void ResetAnswerPanel()
    {
        answerPanel.SetActive(false);
    }

    public void CallQuizPanel(Sheet1Data itemData)
    {
        MainSceneManager.Instance.Player.GetComponent<PlayerMove>().bCanMove = false;
        quizPanel.GetComponent<RectTransform>().DOAnchorPosY(0, 3).SetEase(Ease.InOutQuart);
        QuizPanel quizPanelData = quizPanel.GetComponent<QuizPanel>();
        quizPanelData.atk.text = $"���ݷ� : {itemData.ATK.ToString()}";
        quizPanelData.hp.text = $"ü�� : {itemData.HP.ToString()}";
        quizPanelData.type.text = $"Ÿ�� : {itemData.Type}";
        quizPanelData.itemNameInEng.text = itemData.Name_Eng;
        quizPanelData.itemNameInKor.text = itemData.Name_Kor;
        quizPanelData.info.text = itemData.Info;

        quizPanelData.easyDiffcultyBtn.onClick.AddListener(()=> SetEasyDiffculty(quizPanelData));
        quizPanelData.normalDiffcultyBtn.onClick.AddListener(() => SetNormalDifficulty(quizPanelData));

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
        quizPanelData.multiplicationText.text = "������ ���� �� 1.2��!";

        quizPanelData.checkAnswerBtn.onClick.AddListener(() => checkBtnInEasy(quizPanelData));
        quizPanelData.easyDiffcultyBtn.onClick.RemoveAllListeners();
        quizPanelData.normalDiffcultyBtn.onClick.RemoveAllListeners();
    }
    public void SetNormalDifficulty(QuizPanel quizPanelData)
    {
        quizPanelData.atk.text += " X 1.5";
        quizPanelData.hp.text += " X 1.5";
        quizPanelData.normalInput.gameObject.SetActive(true);
        quizPanelData.easyDiffcultyBtn.gameObject.SetActive(false);
        quizPanelData.normalDiffcultyBtn.gameObject.SetActive(false);
        quizPanelData.hardDiffcultyBtn.gameObject.SetActive(false);
        quizPanelData.checkAnswerBtn.gameObject.SetActive(true);
        quizPanelData.multiplication.gameObject.SetActive(true);
        quizPanelData.multiplicationText.text = "������ ���� �� 1.5��!";

        quizPanelData.checkAnswerBtn.onClick.AddListener(() => checkBtnInNormal(quizPanelData));
        quizPanelData.easyDiffcultyBtn.onClick.RemoveAllListeners();
        quizPanelData.normalDiffcultyBtn.onClick.RemoveAllListeners();
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
    public void checkBtnInNormal(QuizPanel quizPanelData)
    {
        if (quizPanelData.normalInput.text == quizPanelData.itemNameInEng.text)
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
