using UnityEngine;

public class RingBullet : MonoBehaviour
{
    public GameObject damageEffect;
    public int damageAmount = 40;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Instantiate(damageEffect, transform.position, damageEffect.transform.rotation);
            other.GetComponent<Enemy.Enemy>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }
}