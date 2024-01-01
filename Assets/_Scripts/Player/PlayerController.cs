using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    bool onGround;
    AnimationHandler handler;
    public float groundTimer;
    // déplacée dans PlayerHealthHandler public float PlayerHealth = 10f;
    
    //flashing
    SkinnedMeshRenderer _skin;
    public Color flashColor;
    private Color normalColor;
    public float intensity;





    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        handler = gameObject.GetComponent<AnimationHandler>();
        
        //For flashing
        _skin = GetComponentInChildren<SkinnedMeshRenderer>();
        normalColor = _skin.material.GetVector("_EmissionColor");
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            groundTimer = 0.2f;
            onGround = true;
        }
        if (groundTimer > 0)
        {
            groundTimer -= Time.deltaTime;
            handler.Landed();
        }
        else
        {
            handler.Airborn();
        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {

            handler.Run();
            gameObject.transform.forward = move;
        }
        else
        {
            handler.Idle();
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
        {
            if (groundTimer > 0)
            {
                groundTimer = 0;
                handler.Jump();
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                onGround = false;
            }
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            handler.Attack();
        }
    }

    public void flashRed()
    {
        _skin.material.SetVector("_EmissionColor", flashColor*intensity);
        Invoke("normal", 0.12f);
    }

    public void normal()
    {
        _skin.material.SetVector("_EmissionColor", normalColor);
    }
}
