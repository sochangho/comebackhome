using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Lightning")
        {
           var slice = transform.GetComponentInParent<Slice>();
            
            slice.Slicer(slice.meshSliceTarget, slice.mt, collision.contacts[0].point,slice.idx = 0);

            collision.collider.gameObject.SetActive(false);
        }
    }


}
