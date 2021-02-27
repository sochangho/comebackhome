using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : Popup
{


    private int bigFish;

    private int middleFish;

    private int smallFish;

    private int apple;

    private int plum;

    private int chestnut;

    private int axe;

    private int fishing;

    private int bonfire;

    private int ston;

    private int nail;

    private int rope;

    private int fireWood;


    private List<QuestSlot> qusts = new List<QuestSlot>();

    // 퀘스트슬롯 프리팹
    [SerializeField]
    private GameObject qustslot_prefab;



    public void OnCloseButtonPress()
    {
        PlayerControl.Instance.enabled = true;
        Close();

    }


    public void SetQuestitem()
    {
      


        
        
    }

    /// <summary>
    /// 모든 퀘스트들 설명과 조건들을 qusts변수에 Add시켜준다 그 후에 추가된 개수만큼 프리팹 생성을 시켜준다.
    /// </summary>

    public void SetMission()
    {



    }


}
