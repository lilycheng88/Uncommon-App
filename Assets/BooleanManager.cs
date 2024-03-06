using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BooleanManager : MonoBehaviour
{
    [SerializeField] GameObject[] bools;
    [SerializeField] bool[] booleans;

    private void FixedUpdate()
    {
        setChecks(booleans);
    }

    public void setChecks(bool[] booleans)
    {
        for (int i = 0; i < 3; i++)
        {
            Toggle currToggle = bools[i].GetComponent<Toggle>();
            if (booleans[i])
            {
                currToggle.isOn = true;
            } else
            {
                currToggle.isOn = false;
            }
        }
    }
}
