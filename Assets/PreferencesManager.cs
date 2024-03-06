using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PreferencesManager : MonoBehaviour
{
    [SerializeField] GameObject[] bars;
    [SerializeField] int[] nums;

    private void FixedUpdate()
    {
        setBars(nums);
    }

    public void setBars(int[] nums)
    {
        for(int i = 0; i < 4; i++)
        {
            bars[i].GetComponent<BarRender>().setImage(nums[i]);
        }
    }
}
