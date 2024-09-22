using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
    {
        public float enemySpeed;
        public Transform pointA;
        public Transform pointB;
        private Rigidbody2D rb;
        private Transform currentPoint;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            currentPoint = pointB;
            //currentPoint = transform;
        }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * enemySpeed);

            if (transform.position == currentPoint.position)
            {
                flip();
                if (currentPoint == pointA.transform)
                {
                    currentPoint = pointB.transform;
                }
                else if (currentPoint == pointB.transform)
                {
                    currentPoint = pointA.transform;
                }

            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlayerController>() != null)
            {

                PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
                //pc.KillPlayer();
                pc.EnemyHit();
            }
        }

        private void flip()
        {
            Vector2 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

