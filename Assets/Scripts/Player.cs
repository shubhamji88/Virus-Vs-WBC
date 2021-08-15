using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 51f;
    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer str;

    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "walk";
    private string DIE_ANIMATION = "die";
    private bool isVaccinated = false;
    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";
    private string VACCINE_TAG = "Vaccine";
    private bool goingRight = true;
    private PopUp pop;
    private DeadPopup deadPopup;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUp>();
        deadPopup= GameObject.FindGameObjectWithTag("GameManager").GetComponent<DeadPopup>();
        if (SceneManager.GetActiveScene().name == "level1")
            pop.PopUpBox("White Blood Cell", "LEVEL - 1  \n WHO IS THE TRAITOR ???", "KILL THE Infected peOple BEFORE TIMER RUNS OUT!! \n OR \n STAY ALIVE TILL 1ST WAVE GETS OVER(30 SEC)", "Don't kill non infected");
        else if (SceneManager.GetActiveScene().name == "level2")
            pop.PopUpBox("White Blood Cell", "LEVEL - 2 \n stop the infection", "KILL THE Infected peOple BEFORE TIMER RUNS OUT!! \n OR \n STAY ALIVE TILL 1ST WAVE GETS OVER(30 SEC)", "Don't kill non infected");

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        playerJump();
    }
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {

        if (movementX > 0)
        {
            if (!goingRight)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            anim.SetBool(WALK_ANIMATION, true);
            goingRight = true;
        }
        else if (movementX < 0)
        {
            if (goingRight)
            {
                transform.Rotate(0f, 180f, 0f);
            }
            goingRight = false;
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("Rotator"))
        {
            Debug.Log("POpppppppppppppppppppppp");
            pop.PopUpBox("White Blood Cell", "LEVEL - 2 \n stop the infection", "KILL THE Infected peOple BEFORE TIMER RUNS OUT!! \n OR \n STAY ALIVE TILL 1ST WAVE GETS OVER(30 SEC)", "Don't kill non infected");
        }*/
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Monster enemy = collision.gameObject.GetComponent<Monster>();
            if (enemy != null && enemy.isInfected)
            {
                anim.SetTrigger("die");
                StartCoroutine(Dead());

            }
            /*else {
                
                Destroy(collision.gameObject);
            }*/

        }
        if (collision.gameObject.CompareTag(VACCINE_TAG))
        {
            Debug.Log("vacineeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            if (SceneManager.GetActiveScene().name == "level1")
                SceneManager.LoadScene("level2");
            else if (SceneManager.GetActiveScene().name == "level2")
                SceneManager.LoadScene("level3");
        }
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.5f);
        deadPopup.PopUpBox("You are infected!!");
        
    }
}