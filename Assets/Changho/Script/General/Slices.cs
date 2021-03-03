using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slices : MonoBehaviour
{
    private  List<GameObject> mesh_List = new List<GameObject>();

    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offest = Vector3.zero;

    public void ExplotionFragment(GameObject pragment)
    {

            
            pragment.GetComponent<Rigidbody>().AddExplosionForce(m_force, transform.position + m_offest, 10f);
          
        

    }

}
