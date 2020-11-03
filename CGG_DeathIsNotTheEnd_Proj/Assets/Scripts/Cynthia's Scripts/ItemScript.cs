using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    public int itemsTotal;
    public int itemsCollected;
    public Text countText;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        itemsCollected = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(itemsCollected >= itemsTotal)
        {
            Debug.Log("You have collected all the items");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collision.gameObject.SetActive(false);
            itemsCollected += 1;
            CountText();
        }
    }

    public void CountText()
    {
        countText.text = itemsCollected.ToString();
    }
}
