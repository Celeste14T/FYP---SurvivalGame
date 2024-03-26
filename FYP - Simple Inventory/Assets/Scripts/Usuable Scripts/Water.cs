using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Water : MonoBehaviour
{
    public float curWater= 0;
    public float maxWater = 100f;
    public float WaterTimeToDrain = 0.1f;
    public Image Thirst;
    public Text WaterAmount;

    // Start is called before the first frame update
    void Start()
    {
        curWater = maxWater;
        WaterAmount.text = curWater.ToString();
        Thirst.GetComponent<Image>().color = new Color32(0,242 ,255,255);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(curWater >= 0){
            ReduceWater(WaterTimeToDrain * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            AddWater(10);
        }
    }

    public void ReduceWater( float reduce )
    {
        curWater -= reduce;
        int intCurWater = (int)curWater;
        WaterAmount.text = intCurWater.ToString();
    }

    public void AddWater( float increase )
    {
        curWater += increase;
        int intCurWater = (int)curWater;
        WaterAmount.text = intCurWater.ToString();
    }
}
