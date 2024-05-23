using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public Transform target; // Reference to the OVR camera's transform
    public float followSpeed = 1.0f; // Speed at which the character follows the camera
    public float distance = 2.0f; // Distance between the character and the camera

    private Animator animator; // Reference to the character's animator component

    void Start()
    {
        animator = GetComponent<Animator>(); // Get the animator component
    }

    void Update()
    {
        if (target != null)
        {
            // Calculate the target position with an offset
            Vector3 targetPosition = target.position - target.forward * distance;

            // Calculate the direction from the character to the camera
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            // Calculate the rotation that makes the character face towards the camera
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x, 0, directionToTarget.z));

            // Rotate the character 180 degrees around the y-axis to face the camera from the front side
            targetRotation *= Quaternion.Euler(0, 180, 0);

            // Move towards the target position with a speed limit
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Rotate towards the target rotation with a speed limit
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, followSpeed * Time.deltaTime);

            // Set movement speed in animator
            Vector3 velocity = (targetPosition - transform.position) / Time.deltaTime;
            float speed = Mathf.Clamp01(velocity.magnitude / followSpeed);
            animator.SetFloat("Speed", speed);
        }
        else
        {
            Debug.LogWarning("Target not assigned in CharacterFollow script!");
        }
    }
}
