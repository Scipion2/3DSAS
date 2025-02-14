using UnityEngine;

public class Interractable : MonoBehaviour
{
    
    [SerializeField] private GameObject ReliefGameObject;
    [SerializeField] private bool isSelected=false,isAnimated=false;
    [SerializeField] private enum Type{Door,PNJ}
    [SerializeField] private Type ObjectType;
    [SerializeField] private Animator ObjectAnimator;

    public void OnRayHit()
    {

        ReliefGameObject.gameObject.SetActive(true);
        isSelected=true;

    }

    public void OnRayQuit()
    {

        ReliefGameObject.gameObject.SetActive(false);
        isSelected=false;

    }

    public void FixedUpdate()
    {

        if(isSelected && Input.GetKeyUp(KeyCode.Mouse1))
        {


            Action();

        }

    }

    public void Action()
    {

        
        Debug.Log(isAnimated);

        switch(ObjectType)
        {

            case Type.Door :

                ObjectAnimator.SetBool("isDoorClosing",isAnimated);
                ObjectAnimator.SetBool("isDoorOpening",!isAnimated);

                break;

            case Type.PNJ :

                //

                break;

            default :

                Debug.Log("This Object Type is not defined");

                break;

        }

        isAnimated=!isAnimated;

    }

}
