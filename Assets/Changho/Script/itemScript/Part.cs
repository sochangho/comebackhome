using UnityEngine;


public enum PartType
{
    Nail, //못
    Rope,
    FireWood
}


public class Part : Items
{

    public PartType part_type;

  
    void Start()
    {
        if(part_type == PartType.Nail)
        {
            itemname = "못";
            subscript = "배를 수리하기 위한 도구";

        }
        else if (part_type == PartType.Rope)
        {
            itemname = "밧줄";
            subscript = "배를 수리하기 위한 도구";
        }
        else if (part_type == PartType.FireWood)
        {
            itemname = "장작";
            subscript ="배를 수리하고 모닥불을 피울 수 있는 도구";
        }
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
