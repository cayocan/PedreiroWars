using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int life = 2;
    public int damageDealt = 1;
    public float timeBetweenAttacks = 1.5f;
    [Space(10)]
    //public GameObject playerReference;

    //Private Zone
    private NavMeshAgent navAgent;
    private Transform playerTransform;
    private float timer;
    private bool canAttack;
    private PlayerController playerController;

    void Start()
    {
        canAttack = true;
    }
    // Use this for initialization
    void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        try
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        catch
        {
            //Quando o player morre ocorre essa exceção pois o navmesh continua tentando acessar o transform.
        }

    }

    // Update is called once per frame
    void Update()
    {
        followPLayer();
        attackValidator();
        die();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerController = col.GetComponent<PlayerController>();
            attack(canAttack);
        }
    }

    //=============================================================================================

    void followPLayer()
    {
        try
        {
            navAgent.SetDestination(playerTransform.position);
        }
        catch
        {
            //Quando o player morre ocorre essa exceção pois o navmesh continua tentando acessar o transform.
        }

    }

    void attack(bool _canAttack)
    {
        if (canAttack)
        {
            playerController.life -= damageDealt;
            playerController.blinkScreenWithDamage();
            timer = 0;
        }
    }

    void attackValidator()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }

    void die()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}