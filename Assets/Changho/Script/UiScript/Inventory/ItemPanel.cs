using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemPanel : Slot
{
    [SerializeField]
    public TextMeshProUGUI nametex;

    [SerializeField]
    public TextMeshProUGUI subscripttex;

    [SerializeField]
    private GameObject use_button;

    [SerializeField]
    private GameObject cancel_button;

    public Image itemimage;


    public void Start()
    {
        if(_part != null)
        {
            use_button.SetActive(false);
        }
    }


    public void UseButtonclick()
    {
        var itemslot = GameObject.Find("ItemSlot").GetComponent<ItemSlot>();

        if(itemslot.slot_items.Count == 4)
        {
            return;
            
        }


        if (_fish != null)
        {

            FindKey(_fish, itemslot);
          
        }
        else if (_equ != null)
        {

            FindKey(_equ, itemslot);

        }
        else if (_fruit != null)
        {
            FindKey(_fruit, itemslot);
        }
        


    }


    public void CancelButton()
    {

        if (gameObject.activeSelf == true)
        {
           var inventory  = gameObject.GetComponentInParent<Inventory>();

           foreach(var inS in inventory.slots)
            {
                if(inS.GetComponent<Button>().interactable == false)
                {
                    inS.GetComponent<Button>().interactable = true;
                }


            }


            if (_fish != null)
            {
                _fish = null;
            }
            else if (_equ != null)
            {
                _equ = null;
            }
            else if (_fruit != null)
            {
                _fruit = null;
            }
            else if (_part != null)
            {
                _part = null;
            }



            gameObject.SetActive(false);
        }
    }



    private void FindKey<T>(T type , ItemSlot its) where T: Items
    {
        bool eg = false ;

        foreach (var i in its.slot_items)
        {
            if (i.Key == type)
            {

                eg = true;
                break;
               
            }
          
        }

        if (eg == false)
        {
            its.slot_items.Add(type, new ItemInfo(cnt , itemimage));
            its.SetItemWindow();
            Debug.Log("사용" + its.slot_items.Count );
        }
        else
        {

            Debug.Log("이미 사용중");
        }


    }
}
