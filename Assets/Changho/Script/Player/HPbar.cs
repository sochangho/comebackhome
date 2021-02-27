using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPbar : MonoBehaviour
{
    public Image hpfill;
    public TextMeshProUGUI hpfilltext;


    public void Update()
    {
        HpbarUpdate();

    }


    private void HpbarUpdate()
    {
       var hp  = PlayerControl.Instance.player_hp;

        if (PlayerControl.Instance.player_hp > 100) {

            PlayerControl.Instance.player_hp = 100;
            hp = 100;
        } 
       hpfill.fillAmount = hp / 100;
       hpfilltext.text = hp.ToString();
    }




}
