using System.Collections;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public Vector2[] pathPoints;
    public float speed;
    public int posIndex;
    [SerializeField] private AudioSource planeSounde;
    [SerializeField] private Transform player;
    [SerializeField] private float maxDistance;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    private void Update()
    {
        if (player != null && planeSounde != null)
        {
            float distance = Vector2.Distance(player.position, transform.position);
            float normalizeDistance = Mathf.Clamp01(distance / maxDistance);
            planeSounde.volume = Mathf.Lerp(maxValue, minValue, normalizeDistance);
        }
    }

    private void Start()
    {
        if (pathPoints.Length > 0)
        {
            transform.position = pathPoints[0];
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        planeSounde.Play();
        while (true)
        {
            if (posIndex < pathPoints.Length)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, pathPoints[posIndex], speed * Time.deltaTime);
                if ((Vector2)transform.position == pathPoints[posIndex])
                {
                    posIndex++;
                }
            }
            else yield break;
            yield return null;
        }
    }
}
