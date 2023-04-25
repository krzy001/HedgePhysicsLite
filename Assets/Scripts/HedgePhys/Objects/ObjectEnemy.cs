using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectEnemy : MonoBehaviour
{
    //NavMeshAgent helps entities realistically move around the scene
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange;
    public bool playerInSightRange;

    public float chaseSpeed;

    //the animation of the enemy changes depending on their state.
    public Animator anim;

    //Enemys have an effect when they die.
    public GameObject enemyEffect;

    //Know where the player is and get NavMeshAgent of the entitiy
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    //if the player is out of the enemy's sightrange, patrol the scene. Otherwise chase the player
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange)
        {
            Patrolling();
        }
        else
        {
            Chase();
        }
    }

    //set mini desitinations within the patrol. Once the entity reaches the desitination, set a new destination to change direction.
    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }

        agent.speed = 1;

        //Set the animation to when the player isnt noticed
        anim.SetBool("PlayerNoticed", false);
    }

    private void SearchWalkPoint()
    {
        //Set a random desitination within range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //if the new desitination is still on the ground, proceed. Otherwise a new random value will be made
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    //Set the destination the the player position and increase speed
    private void Chase()
    {
        agent.SetDestination(player.position);

        transform.LookAt(player);

        agent.speed = chaseSpeed;

        //Set the animation to the chasing animation
        anim.SetBool("PlayerNoticed", true);
    }

    //when the player collides with the enemy, if the player was attack (jumping), destory the enemy. Otherwise damage the player.
    private void OnTriggerEnter(Collider other)
    {
        ActionManager ply = other.GetComponent<ActionManager>();
        if (ply.AttackPlayer())
        {
            //ply.HealPlayer(5);
            Instantiate(enemyEffect, transform.position, transform.rotation); //create a new instance of the enemy kill effect at the enemy's location.
            Destroy(this.gameObject);
        }
        else
        {
            ply.DamagePlayer(10);
        }
        
    }
}
