using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 플레이어 이동 및 아이템 파밍 , 키를 눌렀을 때 행동
public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private ThrowStones player_throw;

    [SerializeField]
    private Camera player_camera;

    [SerializeField]
    private float speed;

    [SerializeField]
    private ItemSystem itemsystem;

    [SerializeField]
    private Transform bottompos;

    [SerializeField]
    private GameObject Character;

    [SerializeField]
    private ItemSlot itemslot;

    [SerializeField]
    private UIButton button; 

    private Vector3 target;

   

   // private Rigidbody rigid;
    private Rigidbody character_rigid;

    public float distanceX;   // 캐릭터x와 - 카메라x의 거리
    public float distanceZ;   // 캐릭터z와 - 카메라z의 위치
    private float distanceY; 



    public float player_hp = 20f;



    private static PlayerControl _instance;
    // 인스턴스에 접근하기 위한 프로퍼티
    public static PlayerControl Instance
    {
        get
        {
            // 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(PlayerControl)) as PlayerControl;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        // 인스턴스가 존재하는 경우 새로생기는 인스턴스를 삭제한다.
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        // 아래의 함수를 사용하여 씬이 전환되더라도 선언되었던 인스턴스가 파괴되지 않는다.
        DontDestroyOnLoad(gameObject);
    }




    private void Start()
    {
        //rigid = GetComponent<Rigidbody>();
        //character_rigid = Character.GetComponent<Rigidbody>();


        distanceY = Mathf.Abs(transform.position.y - player_camera.transform.position.y);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;

            if (Physics.Raycast(player_camera.ScreenPointToRay(Input.mousePosition), out hit, 10000f))   
            {
            
                   
                
                if(hit.collider.GetComponent<Items>() != null) // 마우스로 클릭한 것이 아이템 일 경우
                {

                    if (Vector3.Distance(transform.position, hit.point) < 10f)
                    {
                        GameObject item = hit.collider.gameObject;
                        ItemSystem.Instance.ItemClickAdd(item);
                    }
               

                }
                else if(hit.collider.gameObject != this.gameObject)
                {
                    target = hit.point;
                }



            }
            // 마우스로 찍은 포인터 값을 target에 반환한다.
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            itemslot.ItemUseZ();
                   
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            itemslot.ItemUseX();

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            itemslot.ItemUseC();

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            itemslot.ItemUseV();

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            var inventory = GameObject.Find("InventoryPopup(Clone)");
            if (inventory != null)
            {
                inventory.GetComponent<Inventory>().OnCloseButtonPress();
            }
            else
            {
                button.InventoryButton();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var quest = GameObject.Find("QuestPopup(Clone)");
            if (quest != null)
            {
                quest.GetComponent<Quest>().OnCloseButtonPress();
            }
            else
            {

                button.QuestButton();
            }
        }

        if (player_hp == 0f)
        {
            //애니메이션
            //플레이어 죽음
        }



        if (PlayerRun())
        {
         

            PlayerTurn();

            

        }
     
        FollowCamera();
    }

    //플레이어 이동
    private bool PlayerRun()
    {
        var distance = Vector3.Distance(transform.position, target);
       

        if (distance >= 0.01f )
        {


            transform.localPosition = Vector3.MoveTowards(transform.position, target , speed * Time.deltaTime);

          
            return true;
        }


        return false;
        

    }

    // 플레이어 회전
    private void PlayerTurn()
    {
        var distance = Vector3.Distance(transform.position, target);
        var dir = target - transform.position;
        var dirXZ = new Vector3(dir.x, 0f, dir.z);
        var targetRotation = Quaternion.LookRotation(dirXZ);


        if (!(dir.x ==0 && dir.z==0))
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,10* Time.deltaTime);

            Debug.Log("회전");

        }
    
        
      
    }

    // 카메라 이동
    private void FollowCamera()
    {

        Vector3 cameraTarget = new Vector3(transform.position.x  - distanceX, transform.position.y + distanceY, transform.position.z - distanceZ );

        player_camera.transform.position = Vector3.Lerp(player_camera.transform.position, cameraTarget, Time.deltaTime * speed);

             
    }




}
