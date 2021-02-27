
using UnityEngine;
using TMPro;

public class QuestSlot : MonoBehaviour
{
    private bool complete = false;

    private bool accept = false;

    private bool fail = false;

    [SerializeField]
    private TextMeshProUGUI suscript;

    [SerializeField]
    private TextMeshProUGUI condition;


    public bool Complete
    {
        get
        {
            return complete;
        }
        set
        {
            complete = value;
        }
    }

    public bool Accept
    {
        get
        {
            return accept;
        }
        set
        {
            accept = value;
        }
    }

    public bool Fail
    {
        get
        {
            return fail;
        }
        set
        {
            fail = value;
        }
    }

    public string Subscript
    {

        set
        {
            suscript.text = value;
        }
    }


    public string Condition
    {

        set
        {
            condition.text = value;
        }
    }


}
