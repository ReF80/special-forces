using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using player;
using Trader;
using UnityEngine.Serialization;


public class Player : MonoBehaviour, IAlive
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public float speed ;
    [SerializeField] Vector2 moveVector;
    [SerializeField] private Animator animator;
    [SerializeField] private Camera cam;
    [SerializeField] Vector2 mousePos;
    
    [SerializeField] public Health health;
    [SerializeField] public Money money;
    [SerializeField] public Shoot shoot;
    [SerializeField] public GrenadeControl grenadeControl;
    [SerializeField] private MissionTextTyping MissionTextTyping;
    [SerializeField] private GameObject panelLose;
    
    [SerializeField] public ForwardMover forwardMover;
    [SerializeField] public int grenadeAmount = 5;
    [SerializeField] private AudioSource audioSource;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (moveVector.x > 0 || moveVector.x < 0 || moveVector.y > 0 || moveVector.y < 0)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Stay", false);
        }
        else
        {
            animator.SetBool("Right", false);
            animator.SetBool("Stay", true);
        }

        if (health.IsDead == true)
        {
            Die();
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && grenadeAmount > 0)
        {
            if (grenadeAmount != 0)
            {
                audioSource.Play();
                grenadeAmount -= 1;
                grenadeControl.AmountController();
                forwardMover.Throw();
            }
        }
    }

    //Animations
    public void AnimationFire(int currentAmmo)
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            animator.SetBool("Fire", true);
        }
        else
        {
            animator.SetBool("Fire", false);
        }
    }
    public void StopAnimationFire() => animator.SetBool("Fire", false);
    
    void FixedUpdate()
    {
        rb.MovePosition(speed * Time.deltaTime * moveVector + rb.position);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    
    public async Task Die()
    { 
        MissionTextTyping.LoseMission();
        panelLose.SetActive(true);
        Destroy(this.gameObject);
        await Task.Delay(5000);
        SceneManager.LoadScene("MainMenu");

    }

    public Health Health { get; }
    public void TakeDamage(float damage)
    {
        health.Remove(damage);
    }
}