using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public int coins;
    public Text CoinsTXT;
    public static ShopManagerScript Instance { get; private set; }

    public static int _SizeUpgradeID = 1;
    public static int _LifesUpgradeID = 2;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) {
            addCoins(10);
            updateCoinsText();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            decreaseCoins(10);
            updateCoinsText();
        }
    }
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins", 0);

        //ID's
        shopItems[1, 1] = 1; //size
        shopItems[1, 2] = 2; //lifes
        shopItems[1, 3] = 3; //null
        shopItems[1, 4] = 4; //null

        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 20;
        shopItems[2, 3] = 30;
        shopItems[2, 4] = 40;

        //Quantity
        shopItems[3, 1] = PlayerPrefs.GetInt("qty_1", 0);
        shopItems[3, 2] = PlayerPrefs.GetInt("qty_2", 0);
        shopItems[3, 3] = PlayerPrefs.GetInt("qty_3", 0);
        shopItems[3, 4] = PlayerPrefs.GetInt("qty_4", 0);

        updateCoinsText();

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Buying").GetComponent<EventSystem>().currentSelectedGameObject;

        int itemId = ButtonRef.GetComponent<ButtonInfo>().ItemID;
        int price = shopItems[2, itemId];
        if (coins >= price) {
            coins -= price;
            shopItems[3, itemId]++; //add quantity
            updateCoinsText();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, itemId].ToString();

            //SAVE
            saveCoins();
            PlayerPrefs.SetInt("qty_" + itemId, shopItems[3, itemId]);
        }
    }

    public int getQuantity(int itemID) {
        if (itemID <= shopItems.Length)
        {
            return shopItems[3, itemID];
        }
        else return 0;
    }

    public void addCoins(int increase) {
       setCoins(getCoins() + increase);
        saveCoins();
    }

    public void decreaseCoins(int decrease) {
        int current = getCoins();
        if (current < decrease)
        {
            setCoins(0);
        }
        else {
            setCoins(current - decrease);
        }
        saveCoins();
    }

    public static int getCoins() {
        return Instance.coins;
    }

    public static void setCoins(int c) {
        Instance.coins = c;
    }

    public void saveCoins()
    {
        PlayerPrefs.SetInt("coins", getCoins());
    }

    public void updateCoinsText() {
        if (Instance.CoinsTXT != null) {
            Instance.CoinsTXT.text = "Coins:" + getCoins().ToString();
        }
    }

}
