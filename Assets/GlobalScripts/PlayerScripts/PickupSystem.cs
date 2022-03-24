using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    private bool objEquipped;
    private GameObject EquippedItem;
    private GameObject pickupObj;
    private Vector3 originalItemScale;
    void Start()
    {
        objEquipped = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] sphereHit = Physics.OverlapSphere(transform.position,4f);
        foreach(Collider obj in sphereHit)
        {
            if(obj.tag == "Gun")
            {
                pickupObj = obj.gameObject;
            }
        }
        if(pickupObj != null && Input.GetKeyDown(KeyCode.E) && objEquipped == false)
        {
            EquipItem(pickupObj);
            objEquipped = true;
            EquippedItem = pickupObj;
        }

        if(objEquipped == true && Input.GetKeyDown(KeyCode.Q))
        {
            ThrowItem(EquippedItem);
            objEquipped = false;
            EquippedItem = null;
        }
    }

    void EquipItem(GameObject pickupObj)
    {
        pickupObj.GetComponent<Rigidbody>().isKinematic = true;
        pickupObj.GetComponent<BoxCollider>().enabled = false;
        pickupObj.transform.SetParent(Camera.main.transform);
        pickupObj.transform.localPosition = new Vector3(0.381f,-0.104f,0.375f);
        pickupObj.transform.localEulerAngles = new Vector3(-90f,0f,201.29f);
        originalItemScale = pickupObj.transform.localScale;
        pickupObj.transform.localScale = Vector3.one;
        pickupObj.transform.Find("BulletOrigin").GetComponent<BulletEmitter>().enabled = true;
        Debug.Log("Picked");

    }

    void ThrowItem(GameObject EquippedItem)
    {
        EquippedItem.GetComponent<Rigidbody>().isKinematic = false;
        EquippedItem.GetComponent<BoxCollider>().enabled = true;
        EquippedItem.transform.SetParent(null);
        EquippedItem.GetComponent<Rigidbody>().AddForce(transform.forward*EquippedItem.GetComponent<Rigidbody>().mass*10f,ForceMode.Impulse);
        EquippedItem.transform.Find("BulletOrigin").GetComponent<BulletEmitter>().enabled = false;
        EquippedItem.transform.localScale = originalItemScale;
    }

    //Gizmos
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,4f);
    }
}
