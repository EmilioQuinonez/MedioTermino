using UnityEngine;
using System.Collections;

public class Pattern : MonoBehaviour
{
    [Header("Timing")]
    public float patternDuration = 10f;
    public float fireRate = 2f;

    private BulletHeart heartShooter;
    private BulletCircle circleShooter;
    private BulletInfinite infinityShooter;

    void Start()
    {
        heartShooter = GetComponent<BulletHeart>();
        circleShooter = GetComponent<BulletCircle>();
        infinityShooter = GetComponent<BulletInfinite>();

        StartCoroutine(PatternCycle());
    }

    IEnumerator PatternCycle()
    {
        while (true)
        {
            yield return StartCoroutine(ExecutePattern(heartShooter.ShootHeart));

            yield return StartCoroutine(ExecutePattern(circleShooter.ShootCircle));

            yield return StartCoroutine(ExecutePattern(infinityShooter.ShootInfinity));
        }
    }

    IEnumerator ExecutePattern(System.Action shootFunction)
    {
        float elapsed = 0f;

        while (elapsed < patternDuration)
        {
            shootFunction.Invoke();
            yield return new WaitForSeconds(fireRate);
            elapsed += fireRate;
        }
    }
}
