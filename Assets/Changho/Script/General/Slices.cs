using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slices : MonoBehaviour
{
    private  List<GameObject> mesh_List = new List<GameObject>();

    [SerializeField] float m_force = 0f;
    [SerializeField] Vector3 m_offest = Vector3.zero;

    public void ExplotionFragment()
    {
        for(int i = 0;  i < gameObject.transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.activeSelf != false)
            {

                mesh_List.Add(transform.GetChild(i).gameObject);    

            }

        }

       

        foreach(var ml in mesh_List)
        {
            ml.AddComponent<Rigidbody>().AddExplosionForce(m_force, transform.position + m_offest, 10f);
          
        }

    }

}
