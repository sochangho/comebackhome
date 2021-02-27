
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Popup
{

    //하위오브젝트 슬롯들
    public List<GameObject> slots;

    public GameObject item_panel;

    //슬롯 프리팹 오브젝트
    public Image Bigfish_Image;

    public Image Middlefish_Image;

    public Image Smallfish_Image;

    public Image Apple_Image;

    public Image Plum_Image;

    public Image Chestnut_Image;

    public Image Axe_Image;

    public Image Bonfire_Image;

    public Image Fishing_Image;

    public Image Ston_Image;

    public Image Nail_Image;

    public Image Rope_Image;

    public Image Firewood_Image;



    private void Start()
    {

        item_panel.SetActive(false);

       
        SetItem();
        SetSprit();
    }

    public void OnCloseButtonPress()
    {
        if(item_panel.activeSelf == true)
        {
            item_panel.SetActive(false);
        }
        PlayerControl.Instance.enabled = true;
        Close();
    }


    /// <summary>
    /// 인벤토리에 들어갈 아이템 개수를 초기화 시킵니다.
    /// </summary>
    private void SetItem()
    {


        var itemslot = ItemSystem.Instance.items;

        for (int i = 0; i < itemslot.Count; i++)
        {

            for (int j = 0; j < slots.Count; j++)
            {

                if (slots[j].GetComponent<Slot>()._fish == null
                    && slots[j].GetComponent<Slot>()._equ == null
                    && slots[j].GetComponent<Slot>()._part == null && slots[j].GetComponent<Slot>()._fruit == null)
                {
                    if (itemslot[i] != null && itemslot[i].GetComponent<Fish>() != null)
                    {
                        slots[j].GetComponent<Slot>()._fish = itemslot[i].GetComponent<Fish>();
                        slots[j].GetComponent<Slot>().cnt++;

                        if(i == itemslot.Count)
                        {
                            return;
                        }


                        break;
                    }
                    else if (itemslot[i] != null &&itemslot[i].GetComponent<Equipment>() != null)
                    {
                        slots[j].GetComponent<Slot>()._equ = itemslot[i].GetComponent<Equipment>();
                        slots[j].GetComponent<Slot>().cnt++;

                        if (i == itemslot.Count)
                        {
                            return;
                        }

                        break;
                    }
                    else if (itemslot[i] != null && itemslot[i].GetComponent<Part>() != null)
                    {
                        slots[j].GetComponent<Slot>()._part = itemslot[i].GetComponent<Part>();
                        slots[j].GetComponent<Slot>().cnt++;
                        if (i == itemslot.Count)
                        {
                            return;
                        }

                        break;
                    }
                    else if (itemslot[i] != null && itemslot[i].GetComponent<Fruit>() != null)
                    {
                        slots[j].GetComponent<Slot>()._fruit = itemslot[i].GetComponent<Fruit>();
                        slots[j].GetComponent<Slot>().cnt++;
                        if (i == itemslot.Count)
                        {
                            return;
                        }


                        break;
                    }


                }
                else
                {
                    if (slots[j].GetComponent<Slot>()._fish != null && itemslot[i].GetComponent<Fish>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._fish.fish_type == itemslot[i].GetComponent<Fish>().fish_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count )
                            {
                                return;
                            }


                            break;
                        }
                    }
                    if (slots[j].GetComponent<Slot>()._equ != null && itemslot[i].GetComponent<Equipment>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._equ.equipment_type == itemslot[i].GetComponent<Equipment>().equipment_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count)
                            {
                                return;
                            }


                            break;
                        }
                    }
                    if (slots[j].GetComponent<Slot>()._part != null && itemslot[i].GetComponent<Part>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._part.part_type == itemslot[i].GetComponent<Part>().part_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count )
                            {
                                return;
                            }


                            break;
                        }
                    }
                    if (slots[j].GetComponent<Slot>()._fruit != null && itemslot[i].GetComponent<Fruit>() != null)
                    {
                        if (slots[j].GetComponent<Slot>()._fruit.fluit_type == itemslot[i].GetComponent<Fruit>().fluit_type)
                        {
                            slots[j].GetComponent<Slot>().cnt++;

                            if (i == itemslot.Count )
                            {
                                return;
                            }


                            break;
                        }
                    }
                }




            }

        }


        for (int i = 0; i < slots.Count; i++)
        {

            Debug.Log(slots[i].GetComponent<Slot>().cnt);
        }
    }


    /// <summary>
    /// 스프라이트 이미지를 적용
    /// </summary>
    private void SetSprit()
    {
        foreach(var slot in slots)
        {
            if(slot.GetComponent<Slot>()._fish != null)
            {
                var sp_type = slot.GetComponent<Slot>()._fish.fish_type;
                if(sp_type != FishType.Big)
                {
                    slot.GetComponent<Image>().sprite = Bigfish_Image.sprite;
                }
                if (sp_type != FishType.Middle)
                {
                    slot.GetComponent<Image>().sprite = Middlefish_Image.sprite;
                }
                if (sp_type != FishType.Small)
                {
                    slot.GetComponent<Image>().sprite = Smallfish_Image.sprite;
                }

            }
            if(slot.GetComponent<Slot>()._equ != null)
            {
                var sp_type = slot.GetComponent<Slot>()._equ.equipment_type;
                if (sp_type != EquipmentType.Axe)
                {
                    slot.GetComponent<Image>().sprite = Axe_Image.sprite;
                }
                if (sp_type != EquipmentType.Bonfire)
                {
                    slot.GetComponent<Image>().sprite = Bonfire_Image.sprite;
                }
                if (sp_type != EquipmentType.Fishing)
                {
                    slot.GetComponent<Image>().sprite = Fishing_Image.sprite;
                }
                if(sp_type != EquipmentType.Ston)
                {
                    slot.GetComponent<Image>().sprite = Ston_Image.sprite;
                }
            }
            if(slot.GetComponent<Slot>()._part != null)
            {
                var sp_type = slot.GetComponent<Slot>()._part.part_type;
                if (sp_type != PartType.FireWood)
                {
                    slot.GetComponent<Image>().sprite = Firewood_Image.sprite;
                }
                if (sp_type != PartType.Nail)
                {
                    slot.GetComponent<Image>().sprite = Nail_Image.sprite;
                }
                if (sp_type != PartType.Rope)
                {
                    slot.GetComponent<Image>().sprite = Rope_Image.sprite;
                }
            }
            if (slot.GetComponent<Slot>()._fruit != null)
            {
                var sp_type = slot.GetComponent<Slot>()._fruit.fluit_type;
                if (sp_type != FuritType.Apple)
                {
                    slot.GetComponent<Image>().sprite = Apple_Image.sprite;
                }
                if (sp_type != FuritType.Chestnut)
                {
                    slot.GetComponent<Image>().sprite = Chestnut_Image.sprite;
                }
                if (sp_type != FuritType.Plum)
                {
                    slot.GetComponent<Image>().sprite = Plum_Image.sprite;
                }
            }



        }
    }
    

}
