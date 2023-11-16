using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{

    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public ShopManagerScript ShopManager = ShopManagerScript.Instance;

    // Update is called once per frame
    void Update()
    {
        if (ShopManager == null) {
            ShopManager = ShopManagerScript.Instance;
        }
        PriceTxt.text = "Price: " + ShopManager.shopItems[2, ItemID].ToString();
        QuantityTxt.text = ShopManager.shopItems[3, ItemID].ToString();
    }
}
