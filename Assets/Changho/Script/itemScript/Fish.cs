
using UnityEngine;


public enum FishType
{
    Big,
    Middle,
    Small
}


public class Fish : Items
{
    public FishType fish_type;

    //[HideInInspector]
    //public float big_cnt;

    //[HideInInspector]
    //public float middle_cnt;

    //[HideInInspector]
    //public float small_cnt;


   

    // Start is called before the first frame update
    void Start()
    {
        if(fish_type == FishType.Big)
        {
            itemname = "큰 물고기";
            subscript = "HP 15% 회복시켜준다.";
        }
        else if (fish_type == FishType.Middle)
        {
            itemname = "중간 물고기";
            subscript = "HP 10% 회복시켜준다.";
        }
        else if (fish_type == FishType.Small)
        {
            itemname = "작은 물고기";
            subscript ="HP 5% 회복시켜준다.";
        }
       
    }


    public override void ItemUse()
    {

        Debug.Log("물고기 사용");
        if (fish_type == FishType.Big)
        {
            //HP를 15%회복

            PlayerControl.Instance.player_hp += 15;

        }
        else if (fish_type == FishType.Middle)
        {
            //HP를 10%회복
            PlayerControl.Instance.player_hp += 10;
        }
        else if (fish_type == FishType.Small)
        {
            //HP를 5%회복
            PlayerControl.Instance.player_hp += 5;
        }


        ItemSystem.Instance.ItemUseRemove(this);

    }

    public override string GetItemName()
    {
        return itemname;
    }

    public override string GetItemsubscript()
    {
        return subscript;
    }

}
