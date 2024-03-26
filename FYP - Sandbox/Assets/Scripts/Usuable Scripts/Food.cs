using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Food : MonoBehaviour
{
    public float curHunger= 0;
    public float maxHunger = 100f;
    public float HungerTimeToDrain = 0.1f;
    public Image Hunger;
    public Text FoodAmount;
    
    // Start is called before the first frame update
    void Start()
    {   
        curHunger = maxHunger;
        FoodAmount.text = curHunger.ToString();
        Hunger.GetComponent<Image>().color = new Color32(243,117 ,1,255);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(curHunger >= 0){
            ReduceHunger(HungerTimeToDrain * Time.deltaTime);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            AddHunger(10);
        }
    }

    public void ReduceHunger( float reduce )
    {
        curHunger -= reduce;
        int intCurHunger = (int)curHunger;
        FoodAmount.text = intCurHunger.ToString();
    }

    public void AddHunger( float increase )
    {
        curHunger += increase;
        int intCurHunger = (int)curHunger;
        FoodAmount.text = intCurHunger.ToString();
    }
}
