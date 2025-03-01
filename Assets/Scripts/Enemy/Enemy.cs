using UnityEngine;
using player;

public class Enemy : MonoBehaviour, IAlive
{
    [SerializeField] private Animator anim;
    [SerializeField] public Health health;
    [SerializeField] public CheckWin checkWin;
    [SerializeField] public SpawnMoney spawnMoney;
    
    public void Update()
    {
        if (health.IsDead)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        int randomIndex = Random.Range(0, spawnMoney.moneyPrefabs.Length);
        GameObject randomPrefabMoney = spawnMoney.moneyPrefabs[randomIndex];
        Instantiate(randomPrefabMoney, transform.position, transform.rotation);
        checkWin.Check();
    }

    private void Awake() => anim = GetComponent<Animator>();
    
    public void StopAnimationHit() => anim.SetBool("Hit", false);
    public Health Health { get; }
    public void TakeDamage(float damage)
    {
        health.Remove(damage);
    }
}
