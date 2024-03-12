using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform startPosition, startPositionBackup;
    public Transform endPosition, endPositionBackup;
    public float slideSpeed = 1.0f;

    private bool isMoving = false;

    public void Start() {
        
    }

    private void Update()
    {
        // Debug.Log(isMoving);

        if (isMoving)
        {
            float step = slideSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPosition.position, step);

            if (transform.position == endPosition.position)
            {
                isMoving = false;
            }
        }
    }

    public void Open()
    {
        isMoving = true;
    }

    public void Close()
    {
        isMoving = true;
        endPosition.position = endPositionBackup.position;
        startPosition.position = startPositionBackup.position;
    }

    private void OnDrawGizmos()
    {
        /*Shows the general direction of the interaction*/
        if (startPosition && endPosition)
            Gizmos.DrawLine(startPosition.position, endPosition.position);
    }
}
