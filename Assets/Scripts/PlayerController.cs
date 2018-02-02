using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int life = 3;
    public float moveSpeed = 10;
	public float shootCadency;
    [Range(1, 30)]
    public float shootRange;
    public GameObject projectilePrefab;
    public Transform shootPivot;
    public Transform playerPointer;
   

    //Temporary Zone
    [Space(10)]
    public float screenBlinkVelocity;
    public Image screenBlinkImage;
    public Color screenBlinkColor;
    public GameObject restartButton;

    //Private Zone
    private Vector3 movement;
    private Rigidbody rigid;
    private RaycastHit rayHit;
	private float shootTimer;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rotatePlayer();
        die();
        shootEnemy();
        testShoot();
        normalizeScreenColor();
    }

    void FixedUpdate()
    {
        movePlayer();
    }

    //============================================================================================================================================

    void movePlayer()
    {
        movement = new Vector3(CnInputManager.GetAxis("Horizontal"), 0, CnInputManager.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;
        rigid.velocity = movement;
    }

    void rotatePlayer()
    {
        playerPointer.position = new Vector3(CnInputManager.GetAxis("HorizontalRotation"), 0, CnInputManager.GetAxis("VerticalRotation")) + transform.position;
        this.transform.LookAt(playerPointer.position);
    }

    void shootEnemy()//Corrigir
    {
		shootTimer += Time.deltaTime;

        Physics.Raycast(transform.position, transform.forward, out rayHit, shootRange);
        try
        {
            if (rayHit.collider.gameObject.CompareTag("Enemy") && shootTimer >= shootCadency)
            {
                Instantiate(projectilePrefab, shootPivot.transform.position, transform.rotation);
				shootTimer = 0;
            }
        }
        catch { }

    }

    void testShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, shootPivot.transform.position, transform.rotation);
        }
    }

    public void blinkScreenWithDamage()
    {
        screenBlinkImage.color = screenBlinkColor;
    }

    void normalizeScreenColor()
    {
        screenBlinkImage.color = Color.Lerp(screenBlinkImage.color, Color.clear, screenBlinkVelocity * Time.deltaTime);
    }

    void die()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            restartButton.SetActive(true);
        }
    }
}
