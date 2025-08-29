using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float MAX_LIFE_TIME = 5f;
    private float _lifeTime;
    public Vector2 Velocity;

    void OnEnable()
    {
        UIContador.ActualizarContador(1);
    }

    void OnDisable()
    {
        UIContador.ActualizarContador(-1);
    }

    void Update()
    {
        transform.position += (Vector3)Velocity * Time.deltaTime;
        _lifeTime += Time.deltaTime;

        if (_lifeTime > MAX_LIFE_TIME)
            Disable();
    }

    void Disable()
    {
        _lifeTime = 0f;
        gameObject.SetActive(false);
    }
}

