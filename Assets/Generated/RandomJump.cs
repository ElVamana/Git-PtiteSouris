using UnityEngine;

public class RandomJump : MonoBehaviour
{
    [Tooltip("Minimum jump height in meters")]
    public float minJumpHeight = 0.3f;

    [Tooltip("Maximum jump height in meters")]
    public float maxJumpHeight = 5f;

    [Tooltip("Time delay between jumps in seconds")]
    public float jumpDelay = 3f;

    private float nextJumpTime;

    private void Start()
    {
        nextJumpTime = Time.time + jumpDelay;
    }

    private void Update()
    {
        if (Time.time >= nextJumpTime)
        {
            JumpRandomly();
            nextJumpTime = Time.time + jumpDelay;
        }
    }

    private void JumpRandomly()
    {
        float jumpHeight = Random.Range(minJumpHeight, maxJumpHeight);
        Vector3 jumpForce = new Vector3(0f, jumpHeight, 0f);
        GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);
    }
}