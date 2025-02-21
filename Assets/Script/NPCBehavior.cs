using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : Interractable
{
    
        

    [Header("Components")]
    [Space(10)]
        [SerializeField] private NavMeshAgent Agent;
        [SerializeField] private Transform Target;

    //GETTERS

    //SETTERS
        public void SetTaget(Transform NewTarget){Target=NewTarget;} //Setter For Target

    //ESSENTIALS

        public void Start()
        {

            Target=NPCManager.instance.GetTarget();

        }

        public void Update()
        {

            if(Target!=null)
                Agent.SetDestination(Target.position);

             if (Agent.remainingDistance > Agent.stoppingDistance)
                Move(Agent.desiredVelocity);

            if(isSelected && Input.GetKeyUp(KeyCode.Mouse1))
            {

                NPCManager.instance.Respawn(this);

            }

        }


    //MOVEMENT GESTURE

        public void Move(Vector3 Movement)
        {

            if(!isSelected)
                this.transform.Translate(Movement.x, Movement.y, Movement.z);

        }


}
