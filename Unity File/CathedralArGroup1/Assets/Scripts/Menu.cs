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

        string filePath = System.IO.Path.Combine(Application.persistentDataPath, "testFile.txt");


        bool object1 = false;
        bool object2 = false;

        try
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (line == " Object 1 tracked: True")
                {
                    object1 = true;
                }
                else if (line == " Object 2 tracked: True")
                {
                    object2 = true;

                };
            }
        }
        catch { };
       

        foreach (Sprite item in items)
        {
            if(item.name == "uniLincoln1" && object1 == true)
            {
                //nothing
            }
            else if(item.name == "Lincoln-Cathedral" && object2 == true)
            {
                //nothing
            }
            else
            {
                GameObject container = Instantiate(ItemImagePrefab) as GameObject;
                container.GetComponent<Image>().sprite = item;

                container.transform.SetParent(ItemImageContainer.transform, false);
            }




        }
    }

}
