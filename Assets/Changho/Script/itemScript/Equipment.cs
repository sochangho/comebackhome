using UnityEngine;


public enum EquipmentType
{
    Axe,
    Fishing,
    Bonfire,
    Ston
}


public class Equipment : Items
{


    public EquipmentType equipment_type;

    //[HideInInspector]
    //public float axe_cnt = 0;

    //[HideInInspector]
    //public float fishing_cnt = 0;

    //[HideInInspector]
    //public float bonfire_cnt = 0;

    //[HideInInspector]
    //public float ston_cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(equipment_type == EquipmentType.Axe)
        {
            itemname = "도끼";
            subscript = "나무를 벨 수 있다.";
                
        }
        else if (equipment_type == EquipmentType.Fishing)
        {
            itemname = "낚시";
            subscript = "물고기를 잡을 수 있습니다.";
        }
        else if(equipment_type == EquipmentType.Bonfire)
        {
            itemname = "모닥불";
            subscript = "HP회복과 일정범위 이내의 좀비가 나타나는 것을 막을 수 있습니다. ";
        }else if(equipment_type == EquipmentType.Ston)
        {
            itemname = "돌맹이";
            subscript = "좀비를 때리거나 높이있는 과일들을 맞춰 떨어뜨릴 수 있습니다. ";
        }
    }


    public override void ItemUse()
    {
        base.ItemUse();


        if (equipment_type == EquipmentType.Axe)
        {
            //장작 획득과 
            //나무배는 애니메이션
        }
        else if (equipment_type == EquipmentType.Fishing)
        {
            //물고기 획득과
            //낚시하는 애니매이션

        }
        else if (equipment_type == EquipmentType.Bonfire)
        {
            // 현재 플레이어 위치에서 모닥불 소환
            ItemSystem.Instance.ItemUseRemove(this);
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

    private void OnCollisionEnter(Collision collision)
    {
        if(equipment_type == EquipmentType.Ston)
        {
            if(collision.collider.tag == "Terrain")
            {

                Destroy(this.gameObject);
                return;
            }
            if(collision.collider.tag == "Tree")
            {
                //파티클 시스템
                Destroy(this.gameObject);
                return;
            }


        }

        return;
    }

}
