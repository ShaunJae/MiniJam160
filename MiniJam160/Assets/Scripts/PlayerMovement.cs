using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    private Transform footLocation;
    private PlayerCamera playerCamera;

    private int jumpsAvailable = 2;

    public float jumpSpeed = 7.5f;
    public int jumpCount = 2;
    public float moveSpeed = 7.5f;

    public bool speedPowerup = false;
    public bool tripleJump = false;

    void Start() {

        rb = GetComponent<Rigidbody>();
        footLocation = transform.Find("Foot");
        playerCamera = GetComponent<PlayerCamera>();

    }

    void Update() {

        Move();
        Jump();

        if (speedPowerup)
        {
            speedPowerup = false;
            moveSpeed = moveSpeed * 1.5f;
            StartCoroutine(SpeedPowerupTimer());
        }
        if (tripleJump)
        {
            tripleJump = false;
            jumpCount = 3;
            StartCoroutine(JumpPowerupTimer());
        }

    }

    void Move() {

        Vector3 moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        
        Vector3 newVelocity = Quaternion.AngleAxis(playerCamera.GetRotation().x - 90, Vector3.up) * moveDirection * moveSpeed * (Input.GetKey(KeyCode.LeftShift) ? 1.5f : 1f);
        newVelocity.y = rb.velocity.y;
        rb.velocity = newVelocity;

    }

    void Jump() {

        if (Input.GetKeyDown(KeyCode.Space)) {

            RaycastHit hit;

            if (Physics.Raycast(footLocation.position, Vector3.down, out hit, 0.1f) || jumpsAvailable > 0) {
                Vector3 newVelocity = rb.velocity;
                newVelocity.y = jumpSpeed;
                rb.velocity = newVelocity;
                jumpsAvailable--;
            }

        }

    }

    private void OnCollisionEnter(Collision collision) {
        if(Vector2.Angle(Vector3.up, collision.GetContact(0).normal) < 35) {
            jumpsAvailable = jumpCount;
        }
    }
    IEnumerator SpeedPowerupTimer()
    {
        yield return new WaitForSeconds(15);
        moveSpeed = moveSpeed / 1.5f;

    }
    IEnumerator JumpPowerupTimer()
    {
        yield return new WaitForSeconds(15);
        jumpCount = 2;
    }
}
