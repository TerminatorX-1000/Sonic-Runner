using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject RingBullet;
    public Transform RingBulletPoint;
    public float RingBulletSpeed = 800;
    
    
    public void GunAttack()
    {
        GameObject Ring = Instantiate(RingBullet, RingBulletPoint.position, Quaternion.identity);
        Ring.GetComponent<Rigidbody>().AddForce(RingBulletPoint.forward * RingBulletSpeed);
    }
}
