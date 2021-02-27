
using UnityEngine;



public enum FuritType
{
    Apple,
    Plum,
    Chestnut
}
public class Fruit : Items
{
    public FuritType fluit_type;


    private void Start()
    {
        if (fluit_type == FuritType.Apple)
        {
          
            itemname = "사과";
            subscript = "HP를 5% 회복시켜준다.";
        }
        else if (fluit_type == FuritType.Plum)
        {
            itemname = "매실";
            subscript = "HP를 10% 회복시켜준다.";
        }
        else if (fluit_type == FuritType.Chestnut)
        {
            itemname = "밤";
            subscript = "HP를 3% 회복시켜준다.";
        }



    }




    public override void ItemUse()
    {
        Debug.Log("과일 사용");
        if (fluit_type == FuritType.Apple)
        {
            Debug.Log("사과 사용");
            //HP를 5%회복
            PlayerControl.Instance.player_hp += 5;
        }
        else if (fluit_type == FuritType.Plum)
        {
            Debug.Log("plum 사용");
            //HP를 5%회복
            //HP를 10%회복
            PlayerControl.Instance.player_hp += 10;
        }
        else if (fluit_type == FuritType.Chestnut)
        {
            Debug.Log("밤 사용");            
            //HP를 3%회복
            PlayerControl.Instance.player_hp += 3;
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
