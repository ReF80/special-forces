using UnityEngine;
using player;

public class Enemy : MonoBehaviour, IAlive
{
    [SerializeField] private Animator anim;
    [SerializeField] public Health health;
    [SerializeField] public CheckWin checkWin;
    [SerializeField] public GameObject moneyPrefab;
    
    public void Update()
    {
        if (health.IsDead == true)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(moneyPrefab, transform.position, transform.rotation);
        checkWin.Check();
    }

    private void Awake() => anim = GetComponent<Animator>();
    
    public void StopAnimationHit() => anim.SetBool("Hit", false);
    public Health Health { get; }
}
