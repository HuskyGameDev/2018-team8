using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Physics : MonoBehaviour
{

    public float minGroundNormalY = .65f;
    public float gravity_mod = 1f;
    protected Vector2 velocity;
    protected Rigidbody2D rb2d;

    protected Vector2 groundNormal;
    protected Vector2 targetVelocity;

    protected const float minMoveDistance = 0.001f;
    protected const float shell_rad = 0.01f;
    protected bool grounded;

    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBuffer_list = new List<RaycastHit2D>(16);

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }

    protected virtual void ComputeVelocity()
    {

    }

    private void FixedUpdate()
    {
        velocity += gravity_mod * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;
        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;
        Movement(move, true);

    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;

        if(distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shell_rad);
            hitBuffer_list.Clear();
            for(int i = 0; i < count; i++)
            {
                hitBuffer_list.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBuffer_list.Count; i++)
            {
                Vector2 currentNormal = hitBuffer_list[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }

                float mod_distance = hitBuffer_list[i].distance - shell_rad;
                distance = mod_distance < distance ? mod_distance : distance;
            }

        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }
}

