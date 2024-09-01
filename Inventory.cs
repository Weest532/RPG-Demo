using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using Button = UnityEngine.UI.Button;

public class Inventory : MonoBehaviour
{
    Dictionary<string, int> inventory = new Dictionary<string, int>(); //Player Inventory

    public Canvas canvas; //The Inventory Canvas

    public Text itemTitle;
    public Text itemDescription;

    GameObject displayitem; //The Current Display Item
    GameObject[] itemPool; //Array of GameObjects for Display Items


    // Start is called before the first frame update
    void Start()
    {
        //Initialises the itemPool, for Display Items, by Finding the Display
        //Objects Active on Start and Initialising the Array with Them
        itemPool = new GameObject[] { 
            GameObject.Find("DisplayBroadsword"), 
            GameObject.Find("DisplayZweihander"), 
            GameObject.Find("DisplayHalberd"),
            GameObject.Find("DisplayCoin"),
            GameObject.Find("DisplayScroll")};

        //Deactivates All Discovered Display Items
        for (int i = 0; i < itemPool.Length; i++)
        {
            itemPool[i].SetActive(false);
        }

        //Adds Some Default Items to the Inventory and Initialises It
        inventory.Add("Broadsword", 1);
        inventory.Add("Zweihander", 1);
        inventory.Add("Halberd", 1);
        inventory.Add("Gold",10);
        initialiseUIInventory();

    }

    // Update is called once per frame
    void Update()
    {
        //If There is a Current Display Weapon, Rotates It On The Y Axis
        if (displayitem != null)
        {
            if (displayitem == GameObject.Find("DisplayScroll"))
            {
                displayitem.transform.Rotate(new Vector3(0, 0, 1f));
            } 
            else
            {
                displayitem.transform.Rotate(new Vector3(0, 1f, 0));
            }
        }
    }

    //Initialises the UI Elements of the Inventory Canvas
    void initialiseUIInventory()
    {
        int i = 1;

        //Creates a KeyValuePair item from the Inventory Data and Adds the Key to The Next Available Inventory Button Slot
        foreach (KeyValuePair<string,int> item in inventory)
        {
            GameObject.Find("ItemSlot" + i.ToString()).GetComponentInChildren<Text>().text = item.Key.ToString();
            i++;
        }

        //For All Remaining Slots, Clears Out Text Content and "Empties" the Inventory of Any Existing False Data
        for (; i < 6;i++)
        {
            GameObject.Find("ItemSlot" + i.ToString()).GetComponentInChildren<Text>().text = " ";
        }

        //Refreshes the Item Information If the Inventory Has Already Been Opened or Otherwise Altered
        GameObject.Find("ItemTitle").GetComponent<Text>().text = " ";
        GameObject.Find("ItemDescription").GetComponent<Text>().text = " ";
    }

    //Takes the String Parameter newItem and Either Adds It Into the Inventory or Increments It's Value by 1, Depending on If It Already Exists In the Inventory
    public void addItemtoInventory(string newItem)
    {
        if(inventory.ContainsKey(newItem))
        {
            inventory[newItem] += 1;
        } else
        {
            inventory.Add(newItem, 1);
        }

    }

    //Takes the String Parameter item and Either Removes It from The Inventory Entirely or Removes 1 from it's Value, Depending on How Many of the Item Exist
    public void removeItemfromInventory(string item)
    {
        if (inventory.ContainsKey(item))
        {
            if (inventory[item] >= 2)
            {
                inventory[item] -= 1;
            } else
            {
                inventory.Remove(item);
            }
        }
        else
        {
            Debug.Log("No Item Found");
        }
    }

    //Enables UI and Initialises the Inventory 
    public void openInventoryUI()
    {
        initialiseUIInventory();
        canvas.GetComponent<Canvas>().enabled = true;
    }

    //Disables UI
    public void closeInventoryUI()
    {
        canvas.GetComponent<Canvas>().enabled = false;
        for (int i = 0; i < itemPool.Length; i++)
        {
            itemPool[i].SetActive(false);
        }
    }

    //Reactivates All Display Items for Use in Finding and Refreshing Display Panel Content in Other Methods
    void refreshDisplayItems()
    {
        for (int i = 0; i < itemPool.Length; i++)
        {
            itemPool[i].SetActive(true);
        }
    }

    //Gets a Given String Item as Parameter and Returns an int for However Many of That Item are Found
    public int getNumberOfGivenItem(string item)
    {
        if (inventory.ContainsKey(item))
        {
            return inventory[item];
        } 
        else
        {
            Debug.Log("Item Does Not Exist");
            return -1;
        }
    }

    //Testing Method to Print Display Pool Items
    void debugPrintDisplayItems()
    {
        for (int i = 0; i < itemPool.Length; i++)
        {
            Debug.Log(itemPool[i]);
        }
    }

    //When Inventory Button Is Clicked, Sets Display Object and Updates Information Panel Text
    public void uiButtonClick(GameObject button)
    {
        string selectedItem = button.GetComponentInChildren<Text>().text; //Gets the Text Component of the Sent Button
        switch (selectedItem) { //Determines the Selected Item from that text content

            //Every Other Example Follows This Case Layout, So These Following Comments are to be used for all of them
            case "Broadsword":

                refreshDisplayItems(); //Briefly Activates All Display Items for the Search

                //Searches the Display Item Pool for The Correct Model and Deactivates Any Other Results
                for (int i = 0; i < itemPool.Length; i++) 
                {
                    if (itemPool[i] == GameObject.Find("DisplayBroadsword"))
                    {
                        itemPool[i].SetActive(true);
                        displayitem = itemPool[i]; //Sets Displayed Weapon to the Correct Result If Found
                    }
                    else
                    {
                        itemPool[i].SetActive(false); 
                    }
                }

                //Sets Information Panel Text to Relevant Contents
                GameObject.Find("ItemTitle").GetComponent<Text>().text = "Broadsword";
                GameObject.Find("ItemDescription").GetComponent<Text>().text = "The Trusty Broadsword, Fast but Hard to Hold, Make Sure to Wear Steel Boots";

                break;

            case "Zweihander":

                refreshDisplayItems();

                for (int i = 0; i < itemPool.Length; i++)
                {
                    if (itemPool[i] == GameObject.Find("DisplayZweihander"))
                    {
                        itemPool[i].SetActive(true);
                        displayitem = itemPool[i];
                    }
                    else
                    {
                        itemPool[i].SetActive(false);
                    }
                }

                GameObject.Find("ItemTitle").GetComponent<Text>().text = "Zweihander";
                GameObject.Find("ItemDescription").GetComponent<Text>().text = "Very Heavy and Unsubtle, Used by Barbarians and Drunk Paladins";

                break;

            case "Halberd":

                refreshDisplayItems();

                for (int i = 0; i < itemPool.Length; i++)
                {
                    if (itemPool[i] == GameObject.Find("DisplayHalberd"))
                    {
                        itemPool[i].SetActive(true);
                        displayitem = itemPool[i];
                    }
                    else
                    {
                        itemPool[i].SetActive(false);
                    }
                }

                GameObject.Find("ItemTitle").GetComponent<Text>().text = "Halberd";
                GameObject.Find("ItemDescription").GetComponent<Text>().text = "Recommended by the Town Guards Union for the Fourth Year Running";

                break;

            case "Gold":

                refreshDisplayItems();

                for (int i = 0; i < itemPool.Length; i++)
                {
                    if (itemPool[i] == GameObject.Find("DisplayCoin"))
                    {
                        itemPool[i].SetActive(true);
                        displayitem = itemPool[i];
                    }
                    else
                    {
                        itemPool[i].SetActive(false);
                    }
                }

                //Uses a Method to Determine the Exact Amount of the Item, Unnecessary for Weapons
                GameObject.Find("ItemTitle").GetComponent<Text>().text = "Gold (" + getNumberOfGivenItem("Gold") + ")";
                GameObject.Find("ItemDescription").GetComponent<Text>().text = "For a Supposedly Gold Coin, This Really Smells of Cheese";

                break;

            case "Scroll":

                refreshDisplayItems();

                for (int i = 0; i < itemPool.Length; i++)
                {
                    if (itemPool[i] == GameObject.Find("DisplayScroll"))
                    {
                        itemPool[i].SetActive(true);
                        displayitem = itemPool[i];
                    }
                    else
                    {
                        itemPool[i].SetActive(false);
                    }
                }

                
                GameObject.Find("ItemTitle").GetComponent<Text>().text = "Scroll";
                GameObject.Find("ItemDescription").GetComponent<Text>().text = "";

                break;

        }
    }

}
