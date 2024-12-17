using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform player1;
   [SerializeField] private Transform player2;

    private float cameraY = 3.69f;
    private float cameraZ = -7.26f;

    [SerializeField] private float minX; 
    [SerializeField] private float maxX;

    public float maxDistance = 10f;
    void Update()
    {
        if (player1 != null && player2 != null)
        {

            float targetX = (player1.position.x + player2.position.x) / 2f;


            targetX = Mathf.Clamp(targetX, minX, maxX);


            transform.position = new Vector3(targetX, cameraY, cameraZ);

            float distance = Vector3.Distance(player1.position, player2.position);

            if (distance > maxDistance)
            {

                Vector3 direction = (player2.position - player1.position).normalized;

                Vector3 midpoint = (player1.position + player2.position) / 2f;

                player1.position = midpoint - direction * maxDistance / 2f;
                player2.position = midpoint + direction * maxDistance / 2f;
            }
        }


    }
}
