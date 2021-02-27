using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{


    [HideInInspector]
    public List<GameObject> items = new List<GameObject>();

    private static ItemSystem _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static ItemSystem Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(ItemSystem)) as ItemSystem;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }



    // 아이템 클릭 획득
    public void ItemClickAdd(GameObject item)
    {

        if (item.GetComponent<Items>() != null)
        {
            var it = item;
            items.Add(it);
        }


        item.SetActive (false);

    }

    // 아이템 낚시로 획득
    public void FishingItemAdd(GameObject item)
    {

        if (item.GetComponent<Items>() != null)
        {
            if (item.GetComponent<Equipment>() == null && item.GetComponent<Fruit>() == null)
            {
                items.Add(item);

                Destroy(item);

            }
        }
        else
        {
            return;
        }
       


    }


    public void BonfireAdd() // 모닥불 생성
    {
        float fw_cnt = 0;
        float st_cnt = 0;


        foreach (var item in items)
        {
            if (item.GetComponent<Items>() != null)
            {
                if (item.GetComponent<Part>() != null)
                {
                    var item_part = item.GetComponent<Part>();

                    if (item_part.part_type == PartType.FireWood)
                    {
                        fw_cnt++;
                    }

                }
                else if (item.GetComponent<Equipment>() != null)
                {
                    var item_eqi = item.GetComponent<Equipment>();


                    if (item_eqi.equipment_type == EquipmentType.Ston)
                    {

                        st_cnt++;
                    }

                }
            }



        }



    


        if ((fw_cnt >= 5) && (st_cnt >= 1))
        {
            GameObject obj = new GameObject();
            items.Add(obj);
            var last = items[items.Count - 1];
            var eqi = last.AddComponent<Equipment>();
            eqi.equipment_type = EquipmentType.Bonfire;
        }
        else
        {
            return;
        }


    }

    /// <summary>
    /// 아이템을 사용할 경우 회복아이템과 장비에서 모닥불 아이템, 돌은 사용할 경우 개수를 감소킵니다.
    /// </summary>

    public void ItemUseRemove<T>(T it) where T: Items
    {
        Debug.Log("아이템 제거");
        foreach(var item in items)
        {
            if(item.GetComponent<T>() != null)
            {
                 if(it == item.GetComponent<T>())
                {
                    items.Remove(item);

                    Debug.Log("아이템 리스트 " + items.Count);

                    break;
                }
              

            }


        }
        

       

    }



}


