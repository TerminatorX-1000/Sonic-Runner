using Player;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        private string _currentState = "IdleState";
        private Transform _target;

        public float chaseRange = 5;
        public float attackRange = 2;
        public float speed = 3;

        public int health;
        public int maxHealth;

        public Animator animator;

        void Start()
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
            health = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            if (PlayerManager.GameOver)
            {
                animator.enabled = false;
                this.enabled = false;
            }

            float distance = Vector3.Distance(transform.position, _target.position);

            if(_currentState == "IdleState")
            {
                if (distance < chaseRange)
                    _currentState = "ChaseState";
            }
            else if(_currentState == "ChaseState")
            {
                //play the run animation
                animator.SetTrigger("chase");
                animator.SetBool("isAttacking", false);

                if(distance < attackRange)
                    _currentState = "AttackState";

                //move towards the player
                if(_target.position.x > transform.position.x)
                {
                    //move right
                    transform.Translate(transform.right * speed * Time.deltaTime);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    //move left
                    transform.Translate(-transform.right * speed * Time.deltaTime);
                    transform.rotation = Quaternion.identity;
                }

            }
            else if(_currentState == "AttackState")
            {
                animator.SetBool("isAttacking", true);

                if (distance > attackRange)
                    _currentState = "ChaseState";
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            _currentState = "ChaseState";

            if(health < 20)
            {
                Die();
            }
        }

        private void Die()
        {
            //play a die animation
            //animator.SetTrigger("isDead");

            //disable the script and the collider
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, 3);
            this.enabled = false;
        }
    }
}
    