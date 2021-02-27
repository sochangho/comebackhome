using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : BaseScene
{
    [SerializeField]
    private GameObject player;

    public void InventoryButton()
    {
       
        OpenPopup<Inventory>("UI/Popup/InventoryPopup");
        PlayerControl.Instance.enabled = false;
       
    }

    public void QuestButton()
    {

        OpenPopup<Quest>("UI/Popup/QuestPopup");
        PlayerControl.Instance.enabled = false;
    }


 

}
