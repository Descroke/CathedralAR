using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject ItemImagePrefab;
    public GameObject ItemImageContainer;

    private void Start()
    {
        Sprite[] items = Resources.LoadAll<Sprite>("Items");

        foreach (Sprite item in items)
        {
            GameObject container = Instantiate (ItemImagePrefab) as GameObject;
            container.GetComponent<Image>().sprite = item;

            container.transform.SetParent(ItemImageContainer.transform,false);


        }
    }

}
