using System;
using Trader;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class OpenBox : MonoBehaviour
{
    [SerializeField] private string Tag;
    [SerializeField] private AudioSource openBoxSound;
    
    [SerializeField] public Animator animator1;
    [SerializeField] public Animator animator2;
    [SerializeField] public SpawnItems spawnItems;
    [SerializeField] public bool isOpen = false;
    [SerializeField] public Sprite newSprite;
    [SerializeField] public SpriteRenderer spriteRenderer;
    public Trade trade;
    
    private void Awake()
    {
        animator1 = GetComponent<Animator>();
        animator2 = GetComponent<Animator>();
    } 
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            OpenObject();
        }
    }

    public void OpenObject()
    {
        switch (Tag)
        {
            case "Chest":
                spriteRenderer.sprite = newSprite;
                Open();
                break;
            case "LeftCarDoor":
                animator1.Play("door_front_right_open");
                Open();
                break;
            case "RightCarDoor":
                animator2.Play("door_front_left_open");
                Open();
                break;
            case "Trader":
                trade.Trading();
                break;
        }
    }
    
    public void Open()
    {
        if (!isOpen)
        {
            int randomIndex1 = UnityEngine.Random.Range(0, spawnItems.ItemPrefabs.Length);
            int randomIndex2 = UnityEngine.Random.Range(0, spawnItems.ItemPrefabs.Length);
            var randomPrefab1 = spawnItems.ItemPrefabs[randomIndex1];
            var randomPrefab2 = spawnItems.ItemPrefabs[randomIndex2];
                           
            isOpen = true;
            Instantiate(randomPrefab1, transform.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
            Instantiate(randomPrefab2, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                
            openBoxSound.Play(); 
        }
    }
}
