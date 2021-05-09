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
    [SerializeField] [Header("�������� �ѱ��� �̸� �ؽ�Ʈ")] public Text itemNameInKor;
    [SerializeField] [Header("�������� ���� �̸� �ؽ�Ʈ")] public Text itemNameInEng;
    [SerializeField] [Header("�ʱ� ���̵����� ���� �Է±���")] public InputField easyInput;
    [SerializeField] [Header("�߱� ���̵����� ���� �Է±���")] public InputField normalInput;
    [SerializeField] [Header("00���� ����� �ؽ�Ʈ ���ӿ�����Ʈ ���ٿ� ����")] public GameObject multiplication;
    [SerializeField] [Header("�� ����� 00���� ����� �ؽ�Ʈ")] public Text multiplicationText;
    [SerializeField] [Header("���� �Է� �� ���� ��ư")] public Button checkAnswerBtn;
}
