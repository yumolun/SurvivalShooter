using UnityEngine;
using System.Collections;

public class ShopController : MonoBehaviour
{
    public Canvas ShopCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            OpenShop();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OpenShop()
    {
        ShopCanvas.enabled = true;
        Time.timeScale = 0;
    }

    public void CloseShop()
    {
        ShopCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
