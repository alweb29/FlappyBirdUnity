using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed ;
    //moving to the left
    private Vector2 leftVector = new Vector2(-1, 0);

    void Update()
    {
        Vector2 actuallpostion = transform.position;
        Vector2 newPosition = actuallpostion + (leftVector * speed * Time.deltaTime);
        transform.position  = newPosition;
    }
}
