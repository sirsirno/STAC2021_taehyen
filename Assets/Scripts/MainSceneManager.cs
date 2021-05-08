using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    //메인 씬 안에서만 존재하는 데이터들을 관리해주는 매니저입니다.
    [SerializeField] GameObject Player;

    static public MainSceneManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    private void OnDestroy()
    {
        Instance = null;
    }

}
