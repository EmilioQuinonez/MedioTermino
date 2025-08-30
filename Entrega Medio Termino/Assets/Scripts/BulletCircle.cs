using UnityEngine;

public class BulletCircle : MonoBehaviour
{
    [Header("Circle Settings")]
    [SerializeField] private float shootForce = 5f;
    [SerializeField] private int bulletCount = 100;

    public void ShootCircle()
    {
        float angleStep = 2 * Mathf.PI / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;

            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

            Bullet bullet = BulletPool.Instance.RequestBullet();
            bullet.transform.position = transform.position;
            bullet.Velocity = dir * shootForce;
        }
    }
}
