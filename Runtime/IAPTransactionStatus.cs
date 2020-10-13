using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
public class IAPTransactionStatus : MonoBehaviour
{
    private static IAPTransactionStatus instance;
    public static IAPTransactionStatus Instance
    {
        get { return instance; }
    }
    [SerializeField] private Text transactionStatus, buyStatus;
    [SerializeField] private GameObject panel;
    private bool autoClose = false;
    private float timeStamp, clickTimeStamp;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Update()
    {
        if (autoClose)
        {
            if (Time.time - timeStamp > 7)
            {
                panel.SetActive(false);
                autoClose = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - clickTimeStamp < 0.25f)
                {
                    panel.SetActive(false);
                    autoClose = false;
                }
                clickTimeStamp = Time.time;
            }
        }
    }
    public void OpenTransactionOverlay()
    {
        transactionStatus.text = "Processing";
        buyStatus.text = "";
        panel.SetActive(true);
    }
    public void ShowStatus(bool isSuccess, UnityEngine.Purchasing.Product product, PurchaseFailureReason reason = PurchaseFailureReason.Unknown)
    {
        if (!autoClose)
        {
            if (isSuccess)
                panel.SetActive(false);
            else
            {
                transactionStatus.text = "Failed";
                if (product != null)
                    buyStatus.text = product.definition.id + "\n" + reason.ToString() + "\n\n<color=#005ed2>Double tap to close.</color>";
                autoClose = true;
            }
            timeStamp = Time.time;
        }
    }
}
