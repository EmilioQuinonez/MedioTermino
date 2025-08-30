using UnityEngine;

public class BulletInfinite : MonoBehaviour
{
    [Header("Infinity Settings")]
    [SerializeField] private float shootForce = 5f;
    [SerializeField] private int bulletCount = 200;

    public void ShootInfinity()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float t = Mathf.PI * 2 * i / bulletCount;

            float x = Mathf.Cos(t) / (1 + Mathf.Pow(Mathf.Sin(t), 2));
            float y = Mathf.Cos(t) * Mathf.Sin(t) / (1 + Mathf.Pow(Mathf.Sin(t), 2));

            Vector2 dir = new Vector2(x, y);

            Bullet bullet = BulletPool.Instance.RequestBullet();
            bullet.transform.position = transform.position;
            bullet.Velocity = dir * shootForce;
        }
    }
}
