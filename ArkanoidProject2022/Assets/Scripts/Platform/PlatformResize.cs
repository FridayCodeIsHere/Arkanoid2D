using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformResize : MonoBehaviour
{
    [SerializeField] private GameObject _Platform;
    Vector3 scaleChange = new Vector3(0.1f, 0, 0);
    private static int _BoardUpgradeID = 1;

    // Start is called before the first frame update
    void Start()
    {

        //int UpgradeSizeBought = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, 1];
        int UpgradeSizeBought = ShopManagerScript.Instance.getQuantity(_BoardUpgradeID);
        _Platform.transform.localScale += UpgradeSizeBought*scaleChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
