using UnityEngine;
using UnityEngine.UI;


public class Slot:MonoBehaviour
{ 
    private Fish fish;  
    private Equipment equipment;    
    private Part part; 
    private Fruit fruit;

    public int cnt = 0;
    public Text item_count;
    
    public Fish _fish{get{return fish;}set{fish = value;}}

    public Equipment _equ{get {return equipment;}set{equipment = value;}}

    public Part _part{get{return part;}set{ part = value; }}


    public Fruit _fruit{ get{  return fruit;}set{  fruit = value;}}


    private void Start()
    {
        if(cnt == 0)
        {

            item_count.text = "";
        }
        else
        {
            item_count.text = cnt.ToString();
        }
    }



    /// <summary>
    /// 슬롯 클릭 했을때 
    /// </summary>
    public void ButtonDownUse()
    {

        var item_panel = GameObject.Find("InventoryPopup(Clone)").GetComponent<Inventory>().item_panel;
        var iteminfo = item_panel.GetComponent<ItemPanel>();


        Debug.Log("ddd");

        if (item_panel.activeSelf == false)
        {
            


            if (fish != null)
            {
                iteminfo._fish = fish;
                iteminfo.nametex.text = fish.GetItemName();
                iteminfo.subscripttex.text = fish.GetItemsubscript();
                iteminfo.itemimage = gameObject.GetComponent<Image>();
                item_panel.SetActive(true);
                iteminfo.cnt = cnt;
                gameObject.GetComponent<Button>().interactable = false;
            }
            if (equipment != null)
            {
                iteminfo._equ = equipment;
                iteminfo.nametex.text = equipment.GetItemName();
                iteminfo.subscripttex.text = equipment.GetItemsubscript();
                iteminfo.itemimage = gameObject.GetComponent<Image>();
                item_panel.SetActive(true);
                iteminfo.cnt = cnt;
                gameObject.GetComponent<Button>().interactable = false;
            }
            if (part != null)
            {
                Debug.Log("ff");
                iteminfo._part = part;
                iteminfo.nametex.text = part.GetItemName();
                iteminfo.subscripttex.text = part.GetItemsubscript();
                iteminfo.itemimage = gameObject.GetComponent<Image>();
                item_panel.SetActive(true);
                iteminfo.cnt = cnt;
                gameObject.GetComponent<Button>().interactable = false;
            }
            if (fruit != null)
            {
                iteminfo._fruit = fruit;
                iteminfo.nametex.text = fruit.GetItemName();
                iteminfo.subscripttex.text = fruit.GetItemsubscript();
                iteminfo.itemimage = gameObject.GetComponent<Image>();
                item_panel.SetActive(true);
                iteminfo.cnt = cnt;
                gameObject.GetComponent<Button>().interactable = false;
            }

           



        }


    }
   
    
}




