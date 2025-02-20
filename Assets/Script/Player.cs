using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Cursor Datas")]
        [SerializeField] private KeyCode CursorLock=KeyCode.E;
        [SerializeField] private bool isCursorLocked=true;

    [Header("Movement Datas")]
        [SerializeField] private float RotationSpeed=50f, MovementSpeed=10f;
        [SerializeField][Range(-120,-10)] private float Minx=-70;
        [SerializeField][Range(10,90)] private float MaxX=90;
        [SerializeField]private float RotationY=0,RotationX=0;

    [Header("Components")]
        [SerializeField] private Rigidbody PlayerBody;
        [SerializeField] private Transform CameraTransform;
        [SerializeField] private Camera PlayerCamera;

    [Header("Ray Datas")]
        [SerializeField] private LayerMask InterractableLayerMask;
        private Interractable InterractableHitted=null;


    //ESSENTIALS

        void Start()
        {

            RotationY=this.transform.rotation.eulerAngles.y;
            Cursor.lockState = CursorLockMode.Locked;
            
        }//Initialyze Datas


        void Update()
        {

            Move();

            Action();


        }//Do Routine

        public void FixedUpdate()
        {

            //if(!isCursorLocked)
                RaycastSystem();

        }

    //INPUT GESTURE

        private void Move()
        {

            //Set The Input System
            float forward=Input.GetAxis("Vertical");
            float slide=Input.GetAxis("Horizontal");
            float rotate=Input.GetAxis("Mouse X");
            float LookVertical=-Input.GetAxis("Mouse Y");


            //Do Move
            if(forward!=0)
                this.transform.Translate(Vector3.forward*forward*MovementSpeed*Time.deltaTime);

            if(slide!=0)
                this.transform.Translate(Vector3.right*slide*MovementSpeed*Time.deltaTime);

            //Do Rotate
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

        }//Check Movement Inputs

        private void Action()
        {

            if(Input.GetKeyDown(CursorLock))
            {

                Cursor.lockState = isCursorLocked ? CursorLockMode.Confined : CursorLockMode.Locked;
                isCursorLocked=!isCursorLocked;

            }

        }//Check Action Inputs

    //RAY GESTURE

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

                    }else
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
