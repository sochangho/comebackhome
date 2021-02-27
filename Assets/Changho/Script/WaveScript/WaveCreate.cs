
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WaveCreate : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    private int xSize;
    private int zSize;
    
    public int Dimension;

    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 3;
    public float offset = 0f;



    public static WaveCreate instance;

    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;


        }
        else if(instance  != this){

            Debug.Log("instance already exists , destroying object");
            Destroy(this);


        }
    }



    private void Start()
    {   
        xSize = Dimension;
        zSize = Dimension;

        

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateWavePlan();
        UpdateWave();


        this.transform.localScale = new Vector3(18, 1, 18);
        this.transform.localPosition = new Vector3(-187, 1, -589);

    }



    private void Update()
    {
        offset += Time.deltaTime * speed;

        for (int i = 0; i < vertices.Length; i++)
        {
            
           vertices[i] = new Vector3(vertices[i].x, PerlinWave(vertices[i].x, vertices[i].z, 0.5f) + GetWaveHeight(transform.position.x + vertices[i].x), vertices[i].z);

          
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }



    
    private void CreateWavePlan()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for(int i =0 ,z=0; z <= zSize; z++)
        {
            for(int x = 0; x <= xSize; x++)
            {
                vertices[i] = new Vector3(x, 0, z);

                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;
             
                vert++;
                tris += 6;
             
                
            }
            vert++;
        }       
    }


    void UpdateWave()
    {
    
        mesh.Clear();
          
        mesh.vertices = vertices;
        mesh.triangles = triangles;
           
        mesh.RecalculateNormals();
    }

    public float GetWaveHeight(float _x)
    {
        return amplitude * Mathf.Sin(_x / length + offset);
    }



    public float SinWave(float x, float z)
    {

        return Mathf.Sin(Time.time + x) + Mathf.Cos(Time.time + z);

    }

    public float PerlinWave(float x, float z,float scale)
    {
        return Mathf.PerlinNoise(Time.time + x * scale, Time.time + z * scale);

    }




    public float GetHeight(Vector3 position)
    {
        //바다에 서 상대적인 위치 
        var scale = new Vector3(1 / transform.lossyScale.x, 0, 1 / transform.lossyScale.z);
        var localPos = Vector3.Scale((position - transform.position), scale);

       
        var p1 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Floor(localPos.z));
        var p2 = new Vector3(Mathf.Floor(localPos.x), 0, Mathf.Ceil(localPos.z));
        var p3 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Floor(localPos.z));
        var p4 = new Vector3(Mathf.Ceil(localPos.x), 0, Mathf.Ceil(localPos.z));

      
        p1.x = Mathf.Clamp(p1.x, 0, Dimension);
        p1.z = Mathf.Clamp(p1.z, 0, Dimension);
        p2.x = Mathf.Clamp(p2.x, 0, Dimension);
        p2.z = Mathf.Clamp(p2.z, 0, Dimension);
        p3.x = Mathf.Clamp(p3.x, 0, Dimension);
        p3.z = Mathf.Clamp(p3.z, 0, Dimension);
        p4.x = Mathf.Clamp(p4.x, 0, Dimension);
        p4.z = Mathf.Clamp(p4.z, 0, Dimension);

      
        var max = Mathf.Max(Vector3.Distance(p1, localPos), Vector3.Distance(p2, localPos), Vector3.Distance(p3, localPos), Vector3.Distance(p4, localPos) + Mathf.Epsilon);
        var dist = (max - Vector3.Distance(p1, localPos))
                 + (max - Vector3.Distance(p2, localPos))
                 + (max - Vector3.Distance(p3, localPos))
                 + (max - Vector3.Distance(p4, localPos) + Mathf.Epsilon);
      
        var height = mesh.vertices[index(p1.x, p1.z)].y * (max - Vector3.Distance(p1, localPos))
                   + mesh.vertices[index(p2.x, p2.z)].y * (max - Vector3.Distance(p2, localPos))
                   + mesh.vertices[index(p3.x, p3.z)].y * (max - Vector3.Distance(p3, localPos))
                   + mesh.vertices[index(p4.x, p4.z)].y * (max - Vector3.Distance(p4, localPos));

        //scale
        return height * transform.lossyScale.y / dist;

    }

    private int index(float x, float z)
    {
        return (int)(x * (Dimension + 1) + z);
    }


}


