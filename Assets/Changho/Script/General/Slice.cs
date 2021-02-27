
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slice : MonoBehaviour
{




    /// <summary>
    /// 메쉬 절단
    /// </summary>
    /// <param name="target">자를 오브젝트</param>
    /// <returns></returns>
    public  GameObject[] Slicer(GameObject target , Material material)
    {
      
      


        //object의 mesh 정보를 가져와준다

        Mesh orin_Mesh = target.GetComponent<MeshFilter>().sharedMesh;

        Vector3[] orin_vertics = orin_Mesh.vertices;

        Vector3[] orin_normals = orin_Mesh.normals;

        Vector2[] orin_uvs = orin_Mesh.uv;



        // 임의로 노멀을 생성 , 오브젝트 정점중 하나를 단면으로 자를 포인트로 잡는다.
        Vector3 plan_normal = new Vector3(Random.value, Random.value, Random.value);
  
        Vector3 point = orin_vertics[Random.Range(0, orin_vertics.Length)];

        Plane random_plane = new Plane(plan_normal.normalized, point);


        //기존 정점들을 두 가지로 나누어 저장해둘 곳

        List<Vector3> slide_verticsA = new List<Vector3>();

        List<Vector3> slide_verticsB = new List<Vector3>();




        List<Vector3> slide_normalsA = new List<Vector3>();

        List<Vector3> slide_normalsB = new List<Vector3>();




        List<Vector2> slide_uvsA = new List<Vector2>();

        List<Vector2> slide_uvsB = new List<Vector2>();




        List<int> slide_triA = new List<int>();

        List<int> slide_triB = new List<int>();




        //새로운 정점 , uv , normal

        List<Vector3> new_vertics = new List<Vector3>();

        List<Vector3> new_normals = new List<Vector3>();

        List<Vector2> new_uvs = new List<Vector2>();







        int t_cnt = orin_Mesh.triangles.Length / 3;




        for (int i = 0; i < t_cnt; i++)

        {

            int idx0 = i * 3;
            int idx1 = idx0 + 1;
            int idx2 = idx1 + 1;


            int vertIdx0 = orin_Mesh.triangles[idx0];
            int vertIdx1 = orin_Mesh.triangles[idx1];
            int vertIdx2 = orin_Mesh.triangles[idx2];

            Vector3 vert0 = orin_vertics[vertIdx0];
            Vector3 vert1 = orin_vertics[vertIdx1];
            Vector3 vert2 = orin_vertics[vertIdx2];


            Vector3 nor0 = orin_normals[vertIdx0];
            Vector3 nor1 = orin_normals[vertIdx1];
            Vector3 nor2 = orin_normals[vertIdx2];

            Vector2 uv0 = orin_uvs[vertIdx0];
            Vector2 uv1 = orin_uvs[vertIdx1];
            Vector2 uv2 = orin_uvs[vertIdx2];







            //단면 위의 점에서 폴리곤의 세 정점으로 방향과 단면이 바라보고 있는 방향을 내적해

            //세 정점이 단면의 한 방향에 함께 있는지를 확인

            float dot0 = Vector3.Dot(random_plane.normal, vert0 - point);
            float dot1 = Vector3.Dot(random_plane.normal, vert1 - point);
            float dot2 = Vector3.Dot(random_plane.normal, vert2 - point);




            if (dot0 < 0 && dot1 < 0 && dot2 < 0)

            {

                slide_verticsA.Add(vert0);
                slide_verticsA.Add(vert1);
                slide_verticsA.Add(vert2);
                slide_normalsA.Add(nor0);
                slide_normalsA.Add(nor1);
                slide_normalsA.Add(nor2);
                slide_uvsA.Add(uv0);
                slide_uvsA.Add(uv1);
                slide_uvsA.Add(uv2);
                slide_triA.Add(slide_triA.Count);
                slide_triA.Add(slide_triA.Count);
                slide_triA.Add(slide_triA.Count);

            }

            else if (dot0 >= 0 && dot1 >= 0 && dot2 >= 0)

            {

                slide_verticsB.Add(vert0);
                slide_verticsB.Add(vert1);
                slide_verticsB.Add(vert2);
                slide_normalsB.Add(nor0);
                slide_normalsB.Add(nor1);
                slide_normalsB.Add(nor2);
                slide_uvsB.Add(uv0);
                slide_uvsB.Add(uv1);
                slide_uvsB.Add(uv2);
                slide_triB.Add(slide_triB.Count);
                slide_triB.Add(slide_triB.Count);
                slide_triB.Add(slide_triB.Count);

            }

            else

            {

                int aloneVertIdx = Mathf.Sign(dot0) == Mathf.Sign(dot1) ? vertIdx2 : (Mathf.Sign(dot0) == Mathf.Sign(dot2) ? vertIdx1 : vertIdx0);

                int otherVertIdx0 = Mathf.Sign(dot0) == Mathf.Sign(dot1) ? vertIdx0 : (Mathf.Sign(dot0) == Mathf.Sign(dot2) ? vertIdx2 : vertIdx1);

                int otherVertIdx1 = Mathf.Sign(dot0) == Mathf.Sign(dot1) ? vertIdx1 : (Mathf.Sign(dot0) == Mathf.Sign(dot2) ? vertIdx0 : vertIdx2);




                Vector3 aloneVert = orin_vertics[aloneVertIdx];
                Vector3 otherVert0 = orin_vertics[otherVertIdx0];
                Vector3 otherVert1 = orin_vertics[otherVertIdx1];

                Vector3 aloneNomal = orin_normals[aloneVertIdx];
                Vector3 otherNomal0 = orin_normals[otherVertIdx0];
                Vector3 otherNomal1 = orin_normals[otherVertIdx1];




                Vector3 aloneUV = orin_uvs[aloneVertIdx];
                Vector3 otherUV0 = orin_uvs[otherVertIdx0];
                Vector3 otherUV1 = orin_uvs[otherVertIdx1];


                float aloneToPlane = Mathf.Abs(random_plane.GetDistanceToPoint(aloneVert));
                float aloneToOther0 =Mathf.Abs(random_plane.GetDistanceToPoint(otherVert0));
                float aloneToOther1 =Mathf.Abs(random_plane.GetDistanceToPoint(otherVert1));


                float Ratio0 = aloneToPlane / (aloneToPlane + aloneToOther0);
                float Ratio1 = aloneToPlane / (aloneToPlane + aloneToOther1);



                Vector3 createdVert0 = Vector3.Lerp(aloneVert, otherVert0, Ratio0);
                Vector3 createdVert1 = Vector3.Lerp(aloneVert, otherVert1, Ratio1);
                Vector3 createdNor0 = Vector3.Lerp(aloneNomal, otherNomal0, Ratio0);
                Vector3 createdNor1 = Vector3.Lerp(aloneNomal, otherNomal1, Ratio1);
                Vector2 createdUv0 = Vector2.Lerp(aloneUV, otherUV0, Ratio0);
                Vector2 createdUv1 = Vector2.Lerp(aloneUV, otherUV1, Ratio1);

                new_vertics.Add(createdVert0);
                new_vertics.Add(createdVert1);
                new_normals.Add(createdNor0);
                new_normals.Add(createdNor1);
                new_uvs.Add(createdUv0);
                new_uvs.Add(createdUv1);







                float aloneSide = Vector3.Dot(random_plane.normal, aloneVert - point);




                if (aloneSide < 0)

                {

                    //A

                    slide_verticsA.Add(aloneVert);
                    slide_verticsA.Add(createdVert0);
                    slide_verticsA.Add(createdVert1);


                    slide_normalsA.Add(aloneNomal);
                    slide_normalsA.Add(createdNor0);
                    slide_normalsA.Add(createdNor0);

                    slide_uvsA.Add(aloneUV);
                    slide_uvsA.Add(createdUv0);
                    slide_uvsA.Add(createdUv1);

                    slide_triA.Add(slide_triA.Count);
                    slide_triA.Add(slide_triA.Count);
                    slide_triA.Add(slide_triA.Count);

                    //B

                    slide_verticsB.Add(otherVert0);
                    slide_verticsB.Add(otherVert1);
                    slide_verticsB.Add(createdVert0);

                    slide_normalsB.Add(otherNomal0);
                    slide_normalsB.Add(otherNomal1);
                    slide_normalsB.Add(createdNor0);


                    slide_uvsB.Add(otherUV0);
                    slide_uvsB.Add(otherUV1);
                    slide_uvsB.Add(createdUv0);

                    slide_triB.Add(slide_triB.Count);
                    slide_triB.Add(slide_triB.Count);
                    slide_triB.Add(slide_triB.Count);







                    slide_verticsB.Add(otherVert1);

                    slide_verticsB.Add(createdVert1);

                    slide_verticsB.Add(createdVert0);




                    slide_normalsB.Add(otherNomal1);

                    slide_normalsB.Add(createdNor1);

                    slide_normalsB.Add(createdNor0);




                    slide_uvsB.Add(otherUV1);

                    slide_uvsB.Add(createdUv1);

                    slide_uvsB.Add(createdUv0);







                    slide_triB.Add(slide_triB.Count);

                    slide_triB.Add(slide_triB.Count);

                    slide_triB.Add(slide_triB.Count);




                }

                else

                {

                    slide_verticsB.Add(aloneVert);

                    slide_verticsB.Add(createdVert0);

                    slide_verticsB.Add(createdVert1);

                    slide_normalsB.Add(aloneNomal);

                    slide_normalsB.Add(createdNor0);

                    slide_normalsB.Add(createdNor1);

                    slide_uvsB.Add(aloneUV);

                    slide_uvsB.Add(createdUv0);

                    slide_uvsB.Add(createdUv1);

                    slide_triB.Add(slide_triB.Count);

                    slide_triB.Add(slide_triB.Count);

                    slide_triB.Add(slide_triB.Count);




                    //A side

                    slide_verticsA.Add(otherVert0);

                    slide_verticsA.Add(otherVert1);

                    slide_verticsA.Add(createdVert0);

                    slide_normalsA.Add(otherNomal0);

                    slide_normalsA.Add(otherNomal1);

                    slide_normalsA.Add(createdNor0);

                    slide_uvsA.Add(otherUV0);

                    slide_uvsA.Add(otherUV1);

                    slide_uvsA.Add(createdUv0);

                    slide_triA.Add(slide_triA.Count);

                    slide_triA.Add(slide_triA.Count);

                    slide_triA.Add(slide_triA.Count);




                    slide_verticsA.Add(otherVert1);

                    slide_verticsA.Add(createdVert1);

                    slide_verticsA.Add(createdVert0);

                    slide_normalsA.Add(otherNomal1);

                    slide_normalsA.Add(createdNor1);

                    slide_normalsA.Add(createdNor0);

                    slide_uvsA.Add(otherUV1);

                    slide_uvsA.Add(createdUv1);

                    slide_uvsA.Add(createdUv0);

                    slide_triA.Add(slide_triA.Count);

                    slide_triA.Add(slide_triA.Count);

                    slide_triA.Add(slide_triA.Count);




                }




            }

        }



        List<Vector3> sorted_createVerts;
        SortVertices(new_vertics, out sorted_createVerts);


        Mesh aMesh = new Mesh();

        Mesh bMesh = new Mesh();




        aMesh.vertices = slide_verticsA.ToArray();

        aMesh.normals = slide_normalsA.ToArray();

        aMesh.uv = slide_uvsA.ToArray();

        aMesh.SetTriangles(slide_triA, 0);







        bMesh.vertices = slide_verticsB.ToArray();

        bMesh.normals = slide_normalsB.ToArray();

        bMesh.uv = slide_uvsB.ToArray();

        bMesh.SetTriangles(slide_triB, 0);







        GameObject aObject = new GameObject(target.name + "_A", typeof(MeshFilter), typeof(MeshRenderer), typeof(Slice));

        GameObject bObject = new GameObject(target.name + "_B", typeof(MeshFilter), typeof(MeshRenderer), typeof(Slice));




        Material[] mats = target.GetComponent<MeshRenderer>().sharedMaterials;




        aObject.GetComponent<MeshFilter>().sharedMesh = aMesh;

        aObject.GetComponent<MeshRenderer>().sharedMaterials = mats;




        bObject.GetComponent<MeshFilter>().sharedMesh = bMesh;

        bObject.GetComponent<MeshRenderer>().sharedMaterials = mats;




        aObject.transform.position = target.transform.position;

        aObject.transform.rotation = target.transform.rotation;

        aObject.transform.localScale = target.transform.localScale;

        bObject.transform.position = target.transform.position;

        bObject.transform.rotation = target.transform.rotation;

        bObject.transform.localScale = target.transform.localScale;







        target.SetActive(false);




        return new GameObject[] { aObject, bObject };

    }


    public void SortVertices(List<Vector3> verts , out List<Vector3> result)
    {
        result = new List<Vector3>();
        result.Add(verts[0]);
        result.Add(verts[1]);

        int vertSetCount = verts.Count / 2;

        for(int i = 0; i < vertSetCount - 1; i++)
        {
            Vector3 vert0 = verts[i * 2];
            Vector3 vert1 = verts[i * 2 + 1];

            for(int j = i + 1; j < vertSetCount; j++)
            {
                Vector3 cVert0 = verts[j * 2];
                Vector3 cVert1 = verts[j * 2 + 1];

                if(vert1 == cVert0)
                {
                    result.Add(cVert1);
                    
                }

            }

        }

    }


    void SwapTwoIndexSet<T>(ref List<T> verts , int index00 , int index01, int index10, int index11 )
    {

    }




    public void SliceColl()
    {


       // Slicer(this.gameObject);

    }







    private void Update()

    {



        if (Input.GetKeyDown(KeyCode.A))

        {

            SliceColl();

        }


    }










}

