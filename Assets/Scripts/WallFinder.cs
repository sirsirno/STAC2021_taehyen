using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFinder : MonoBehaviour
{
    private PlayerMove player;
    [SerializeField]
    private int num;
    void Start()
    {
        player=GameManager.Instance.player.GetComponent<PlayerMove>();
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(){
        if(!player.wallChk)
            player.wallChk=true;
    }
    private void OnTriggerExit2D(){
        player.wallChk=false;
    }
}
