using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Packs
{
    public Pack[] packs;
    public Pack GetPackById(string packId)
    {
        foreach (Pack pack in packs)
            if (pack.id == packId)
                return pack;
        return null;
    }
    public float GetPackPrice(string packId)
    {
        foreach (var pack in packs)
            if (pack.id == packId)
                return pack.price;
        return 0;
    }
    public float GetPackLifeTime(string packId)
    {
        foreach (var pack in packs)
            if (pack.id == packId)
                return pack.lifeTime;
        return 0;
    }
}
[System.Serializable]
public class Pack
{
    public string id;
    public float price;
    public float lifeTime;//total live time in second
    public int rubyAmount;
}
public class IAPSilentProcesser : MonoBehaviour
{
    private List<string> iapPacks = new List<string>();
    public bool canProcessIAP = false;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        while (!canProcessIAP)
            yield return null;
        foreach (var packId in iapPacks)
            ProcessPurchase(packId);
        Destroy(gameObject);
    }
    private void ProcessPurchase(string packId)
    {
        TextAsset data = null;
        data = Resources.Load<TextAsset>("iap_packs");
        string packsData = data.text;
        Packs packs = JsonUtility.FromJson<Packs>(packsData);
        Pack pack = packs.GetPackById(packId);
        if (pack != null)
        {
            if (pack.rubyAmount > 0){
                //Write the code to increase ruby here
                //Example DataController.Instance.Ruby += pack.rubyAmount;
            }
        }
    }
    public void OnCompletePurchase(UnityEngine.Purchasing.Product product)
    {
        iapPacks.Add(product.definition.id);
    }
    public void OnFailPurchase(UnityEngine.Purchasing.Product product, UnityEngine.Purchasing.PurchaseFailureReason reason)
    {

    }
}
