using UnityEngine;

public class Interractable : MonoBehaviour
{
    
    [Header("Components")]
    [Space(10)]
        [SerializeField] private GameObject ReliefGameObject;
        [SerializeField] private Type ObjectType;
        [SerializeField] private Animator ObjectAnimator;

    [Header("Script Datas")]
    [Space(10)]
        [SerializeField] private bool isSelected=false,isAnimated=false;
        [SerializeField] private enum Type{Door,NPC}
    
    //ESSENTIALS
        public void FixedUpdate()
        {

            if(isSelected && Input.GetKeyUp(KeyCode.Mouse1))
            {


                Action();

            }

        }//Check Inputs

    //RAY GESTURE

        public void OnRayHit()
        {

            ReliefGameObject.gameObject.SetActive(true);
            isSelected=true;

        }//Display Hover Reaction

        public void OnRayQuit()
        {

            ReliefGameObject.gameObject.SetActive(false);
            isSelected=false;

        }//Hide Hover Reaction

    //ACTION GESTURE

        public void Action()
        {


            switch(ObjectType)
            {

                case Type.Door :

                        DoorAnimation();

                    break;

                case Type.NPC :

                        NPCTalk();

                    break;

                default :

                    Debug.Log("This Object Type is not defined");

                    break;

            }

            isAnimated=!isAnimated;

        }//Select The Action To Do

        private void DoorAnimation()
        {

            ObjectAnimator.SetBool("isDoorClosing",isAnimated);
            ObjectAnimator.SetBool("isDoorOpening",!isAnimated);

        }//Animate The Door

        private void NPCTalk()
        {

            //

        }//Launch The Talk With This NPC

}
