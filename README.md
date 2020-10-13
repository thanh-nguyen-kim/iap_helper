# IAP Helper

<https://killertee.wordpress.com/about/>

A collection of scripts to handle Unity IAP Transaction.

+ IAPSilentProcesser.cs process IAP transaction after a game crash.
+ IAPTransactionStatus.cs display an overlay to block interact with game when user purchases iap.

## Set up IAPSilentProcesser

+ First, You must manual create a Resources folder and config your iap_packs.json inside it.
+ Then, Enable and import Unity IAP to your project.
+ Next, Set up your first scene similar with the example scene.
+ Finally, When your game is fully loaded, You must set the canProcessIAP=true by using the following code

```cs

FindObjectOfType<IAPSilentProcesser>().canProcessIAP=true;

```

## Set up IAPTransactionStatus.cs

+ Call OpenTransactionOverlay() when buy a IAP item/
+ Call ShowStatus(bool isSuccess, UnityEngine.Purchasing.Product product, PurchaseFailureReason reason = PurchaseFailureReason.Unknown) after Unity IAP finishes processed Transaction.
