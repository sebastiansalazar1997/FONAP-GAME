using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    PlayerSelect playerSelect;
    Vector2 move;
    public float speedMovements = 5f;

    public SimpleTouchController leftController;

    public GameObject banRobber;

    public GameObject messageRobber;
    public GameObject messageLandSlide;
    public GameObject messageRiver;

    public float speed = 4f;

    public AudioSource clipFail;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSelect = GetComponent<PlayerSelect>();
    }


    void Update()
    {
        move = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        // Check if the device running this is a handheld
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            move = new Vector2(
                    leftController.GetTouchPosition.x,
                    leftController.GetTouchPosition.y
            );
        }
        else
        {
            leftController.gameObject.SetActive(false);
        }

        /*
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + move,
            speed * Time.deltaTime
        );
        */

        if (move != Vector2.zero)
        {
            if (move.y > 0)
            {
                animator.SetBool("walking_up", true);
                animator.SetBool("walking_down", false);
                animator.SetBool("walking_side", false);
            }
            else if (move.y < 0)
            {
                animator.SetBool("walking_down", true);
                animator.SetBool("walking_up", false);
                animator.SetBool("walking_side", false);
            }
            else if (move.x > 0)
            {
                spriteRenderer.flipX = false;
                animator.SetBool("walking_side", true);
                animator.SetBool("walking_up", false);
                animator.SetBool("walking_down", false);
            }
            else if (move.x < 0)
            {
                spriteRenderer.flipX = true;
                animator.SetBool("walking_side", true);
                animator.SetBool("walking_up", false);
                animator.SetBool("walking_down", false);
            }
            else
            {
                spriteRenderer.flipX = false;
                animator.SetBool("walking_side", false);
                animator.SetBool("walking_up", false);
                animator.SetBool("walking_down", false);
            }
        }
        else
        {
            animator.SetBool("walking_down", false);
            animator.SetBool("walking_up", false);
            animator.SetBool("walking_side", false);
        }
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Collision_Warning"))
        {
            messageLandSlide.GetComponent<DinamicMessages>().showMessage();

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            messageLandSlide.SetActive(true);
            clipFail.Play();
        }

        if (collision.CompareTag("Collision_Warning_River"))
        {
            messageRiver.GetComponent<DinamicMessages>().showMessage();

            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            messageRiver.SetActive(true);
            clipFail.Play();
        }

        if (collision.CompareTag("Robber"))
        {
            messageRobber.GetComponent<DinamicMessages>().showMessage();

            banRobber.SetActive(true);
            messageRobber.SetActive(true);
            clipFail.Play();
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Collision_Warning"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            messageLandSlide.SetActive(false);
        }

        if (collision.CompareTag("Collision_Warning_River"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            messageRiver.SetActive(false);
        }

        if (collision.CompareTag("Robber"))
        {
            banRobber.SetActive(false);
            messageRobber.SetActive(false);
        }
    }
}
