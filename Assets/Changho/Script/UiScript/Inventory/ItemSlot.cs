
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [HideInInspector]
    public Dictionary<Items,ItemInfo> slot_items = new Dictionary<Items, ItemInfo>();

    public List<GameObject> slots_temp = new List<GameObject>();

  


    /// <summary>
    /// Z입력
    /// </summary>
    public void ItemUseZ()
    {

        if(slot_items.Count < 1)
        {
            return;
        }

        FindItemType(0);

    }


    /// <summary>
    /// X입력
    /// </summary>
    public void ItemUseX()
    {

        if (slot_items.Count < 2)
        {
            return;
        }

        FindItemType(1);

    }


    /// <summary>
    /// C입력
    /// </summary>

    public void ItemUseC()
    {

        if (slot_items.Count < 3)
        {
            return;
        }

        FindItemType(2);
    }
    /// <summary>
    /// V입력
    /// </summary>
    public void ItemUseV()
    {
        if (slot_items.Count < 4)
        {
            return;
        }


        FindItemType(3);
    }


    /// <summary>
    /// 아이템 사용 키값으로 개수 감소
    /// </summary>
    /// <typeparam name="T">Items에 상속받은 아이템타입만 매개변수로 받는다</typeparam>
    /// <param name="type">변수 이름 </param>
    private void FindKey<T>(T type) where T: Items
    {
        var keyList = new List<Items>(slot_items.Keys);
        type.ItemUse();
        foreach (var keylist in keyList)
        {

            if (keylist.GetComponent<T>() == (T)type)
            {
                var k = (T)keylist;
                slot_items[k].cnt--;

                if (slot_items[k].cnt == 0)
                {
                    slot_items.Remove(k);
                }
                SetItemWindow();
                break;
            }
        }

    }

    /// <summary>
    /// 아이템 타입비교
    /// </summary>
    /// <param name="num">슬롯 번호</param>
    private void FindItemType(int num)
    {
        var itemlist = new List<Items>(slot_items.Keys);

        if (itemlist[num].GetComponent<Fish>() != null)
        {
            FindKey(itemlist[num].GetComponent<Fish>());
        }
        if (itemlist[num].GetComponent<Equipment>() != null)
        {
            var eqi = itemlist[num].GetComponent<Equipment>();

            if (eqi.equipment_type != EquipmentType.Axe)
            {
                FindKey(itemlist[num].GetComponent<Equipment>());
            }
        }
        if (itemlist[num].GetComponent<Part>() != null)
        {
            FindKey(itemlist[num].GetComponent<Part>());
        }
        if (itemlist[num].GetComponent<Fruit>() != null)
        {
            FindKey(itemlist[num].GetComponent<Fruit>());
        }

    }


    public void SetItemWindow()
    {
        var listitem = new List<ItemInfo>(slot_items.Values);

        int i;

        for(i = 0; i < listitem.Count; i++)
        {
            slots_temp[i].GetComponent<Itemelement>().cnt_text.text = listitem[i].cnt.ToString();
            slots_temp[i].GetComponent<Itemelement>().img.sprite = listitem[i].info_image.sprite;

            if (slots_temp[i].GetComponent<Itemelement>().img.sprite != null)
            {
                Color color = slots_temp[i].GetComponent<Itemelement>().img.color;
                color.a = 1;
                slots_temp[i].GetComponent<Itemelement>().img.color = color;
            }

        }


        for(int j = i; j < slots_temp.Count; j++)
        {
            slots_temp[i].GetComponent<Itemelement>().cnt_text.text = "";
            slots_temp[i].GetComponent<Itemelement>().img.sprite = null;


            if (slots_temp[i].GetComponent<Itemelement>().img.sprite == null)
            {
                Color color = slots_temp[i].GetComponent<Itemelement>().img.color;
                color.a = 0;
                slots_temp[i].GetComponent<Itemelement>().img.color = color;
            }

        }

    }


}



public class ItemInfo
{
   public int cnt;
   public Image info_image;

    public ItemInfo(int cnt , Image image)
    {
        this.cnt = cnt;
        info_image = image;
    }


}
