using System;
using Trader;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class OpenBox : MonoBehaviour
{
    [SerializeField] public Animator Animator1;
    [SerializeField] public Animator Animator2;
    [SerializeField] private string Tag;
    [SerializeField] public SpawnItems SpawnItems;
    [SerializeField] public bool isOpen = false;
    [SerializeField] public Sprite newSprite;
    [SerializeField] public SpriteRenderer spriteRenderer;
    public Trade trade;
    
    private void Awake()
    {
        Animator1 = GetComponent<Animator>();
        Animator2 = GetComponent<Animator>();
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
                Animator1.Play("door_front_right_open");
                Open();
                break;
            case "RightCarDoor":
                Animator2.Play("door_front_left_open");
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
            int randomIndex1 = UnityEngine.Random.Range(0, SpawnItems.ItemPrefabs.Length);
            int randomIndex2 = UnityEngine.Random.Range(0, SpawnItems.ItemPrefabs.Length);
            GameObject randomPrefab1 = SpawnItems.ItemPrefabs[randomIndex1];
            GameObject randomPrefab2 = SpawnItems.ItemPrefabs[randomIndex2];
                           
            isOpen = true;
            Instantiate(randomPrefab1, transform.position + new Vector3(-0.2f, 0f, 0f), Quaternion.identity);
            Instantiate(randomPrefab2, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                
            //openBoxMessenge.Play(); 
        }
    }
}
