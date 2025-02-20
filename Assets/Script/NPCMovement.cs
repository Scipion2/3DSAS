using UnityEngine;

public class NPCMovement : Interractable
{
    
    [SerializeField] private bool isAbleToMove=true;

    public void OnRayHit()
    {

        isAbleToMove=false;

    }

    public void OnRayQuit()
    {

        isAbleToMove=true;

    }

    public void Move(Vector3 Movement)
    {

        this.transform.Translate(Movement.x, Movement.y, Movement.z);

    }
}
