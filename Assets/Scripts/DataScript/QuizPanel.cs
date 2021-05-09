using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizPanel : MonoBehaviour
{
    [SerializeField] public Button easyDiffcultyBtn;
    [SerializeField] public Button normalDiffcultyBtn;
    [SerializeField] public Button hardDiffcultyBtn;
    [SerializeField] public Text atk;
    [SerializeField] public Text hp;
    [SerializeField] public Text type;
    [SerializeField] public Text info;
    [SerializeField] [Header("아이템의 한국어 이름 텍스트")] public Text itemNameInKor;
    [SerializeField] [Header("아이템의 영어 이름 텍스트")] public Text itemNameInEng;
    [SerializeField] [Header("초급 난이도에서 나올 입력구간")] public InputField easyInput;
    [SerializeField] [Header("중급 난이도에서 나올 입력구간")] public InputField normalInput;
    [SerializeField] [Header("00배라고 써놓을 텍스트 게임오브젝트 접근용 변수")] public GameObject multiplication;
    [SerializeField] [Header("답 맞출시 00배라고 써놓을 텍스트")] public Text multiplicationText;
    [SerializeField] [Header("정답 입력 후 누를 버튼")] public Button checkAnswerBtn;
}
