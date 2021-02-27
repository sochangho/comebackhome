using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
   
    protected int itemcount;
    protected string subscript;
    protected string itemname; 

    virtual public void ItemUse()
    {

        Debug.Log("item사용");
    }


    virtual public string GetItemName()
    {
        return itemname;
    }

    virtual public string GetItemsubscript()
    {
        return subscript;
    }
}
