using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Slider slider;
     float slidervalue = 30f;
 
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Counting());
        
    }
    public IEnumerator Counting()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("time out");
        while (true && slidervalue !=0)
        {
            yield return new WaitForSeconds(1);
            slidervalue--;
            Debug.Log("" + slidervalue);
        }
        SceneManager.LoadScene("Gameover");

    }
    // Update is called once per frame
    void Update()
    {
        slider.value = slidervalue;
        
        
        
    }
}
