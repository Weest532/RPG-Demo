using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public GameObject item;

    public Text questBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (item.name.Contains("Gold"))
            {
                item.SetActive(false);
                other.GetComponent<Player>().menuCanvas.GetComponent<Inventory>().addItemtoInventory("Gold");
            } 
            else if (item.name.Contains("Scroll"))
            {
                item.SetActive(false);
                other.GetComponent<Player>().menuCanvas.GetComponent<Inventory>().addItemtoInventory("Scroll");
                questBox.text = "Go back to the guard";
            } 
            else
            {
                Debug.Log("Item " + item + "Is Not a Valid Option for Pickup");
            }
        }
    }

}
