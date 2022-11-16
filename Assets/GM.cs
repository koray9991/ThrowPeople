using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public int level;
    public GameObject level1,level2,level3;
    void Start()
    {
        level = 1;
    }
    public void ButtonSs(int ButtonNo)
    {
        if (ButtonNo == 1)
        {
            if (level == 1)
            {
                level++;
                Instantiate(level2, transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Level1"));
            }
            if (level == 2)
            {
                level++;
                Instantiate(level3, transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Level2"));
            }
            if (level == 3)
            {
                level++;
                Instantiate(level1, transform.position, Quaternion.identity);
                Destroy(GameObject.FindGameObjectWithTag("Level3"));
            }
        }
    }

}
