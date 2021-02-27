using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ThrowStones : Items
{
    [SerializeField]
    private GameObject stone;

    [SerializeField]
    private Transform shootPoint;

    [SerializeField]
    private Transform shootPoint2;

    [SerializeField]
    private float throwTime;



    private void Start()
    {
        itemname = "돌맹이";
        subscript = "좀비 공격과 나무에 달려있는 열매를 떨어뜨릴 수 있다.";
        itemcount = 0;
    }

    public int Itemcount
    {
        get
        {
            return itemcount;
        }
        set
        {
            itemcount = value;
        }
    }


   



    public override void ItemUse()
    {
        base.ItemUse();

        Throw();
    }


    public void Throw()
    {
        
      
        Vector3 vo = CalculateVelocity(shootPoint2.position, transform.position, throwTime);

        Rigidbody obj = Instantiate(stone, shootPoint.position, Quaternion.identity).GetComponent<Rigidbody>();

        obj.velocity = vo;


    }


    private Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        var dst = target - origin;
        var dstXZ = dst;
        dstXZ.y = 0f;

        float Sy = dst.y;
        float Sxz = dstXZ.magnitude;


        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;


        Vector3 result = dstXZ.normalized;
        result *= Vxz;
        result.y = Vy;

        return result;

    }


   


}
