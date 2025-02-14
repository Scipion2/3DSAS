using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private KeyCode CursorLock=KeyCode.E;
    [SerializeField] private bool isCursorLocked=true;

    [SerializeField] private LayerMask InterractableLayerMask;

    [SerializeField] private float RotationSpeed=50f, MovementSpeed=10f;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField][Range(-120,-10)] private float Minx=-70;
    [SerializeField][Range(10,90)] private float MaxX=90;
    private float RotationY=0,RotationX=0;

    private Interractable InterractableHitted=null;

    void Start()
    {

        RotationY=this.transform.rotation.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        
    }


    void Update()
    {


        float forward=Input.GetAxis("Vertical");
        float slide=Input.GetAxis("Horizontal");
        float rotate=Input.GetAxis("Mouse X");
        float LookVertical=-Input.GetAxis("Mouse Y");

        if(forward!=0)
            this.transform.Translate(Vector3.forward*forward*MovementSpeed*Time.deltaTime);

        if(slide!=0)
            this.transform.Translate(Vector3.right*slide*MovementSpeed*Time.deltaTime);

        if(rotate!=0)
        {

            RotationY+=rotate*RotationSpeed*Time.deltaTime;
            this.transform.localRotation=Quaternion.Euler(0,RotationY,0);

        }

        if(LookVertical!=0)
        {

            RotationX+=LookVertical*RotationSpeed*Time.deltaTime;
            RotationX=Mathf.Clamp(RotationX,Minx,MaxX);
            CameraTransform.localRotation=Quaternion.Euler(RotationX,0,0);

        }

        if(Input.GetKeyDown(CursorLock))
        {

            Cursor.lockState = isCursorLocked ? CursorLockMode.Confined : CursorLockMode.Locked;
            isCursorLocked=!isCursorLocked;

        }


    }

    public void FixedUpdate()
    {

        //if(!isCursorLocked)
            RaycastSystem();

    }

    private void RaycastSystem()
    {

        Vector3 MousePosition=Input.mousePosition;
        Ray MouseRay=PlayerCamera.ScreenPointToRay(MousePosition);
        RaycastHit Hit;

        if(Physics.Raycast(MouseRay,out Hit,1000,InterractableLayerMask,QueryTriggerInteraction.Collide))
        {


            if(Hit.collider!=null)
            {

                if(InterractableHitted==null)
                {

                    InterractableHitted=Hit.collider.gameObject.GetComponent<Interractable>();

                }

                InterractableHitted.OnRayHit();

            }

        }else
        {

            if(InterractableHitted!=null)
            {

                InterractableHitted.OnRayQuit();
                InterractableHitted=null;

            }    

        }


    }
}
