using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChild : MonoBehaviour
{
    [SerializeField] private List<Color> listColor;

    // Start is called before the first frame update
    void Start()
    {
        RandomColorAndChild();
    }

    // Update is called once per frame
    public void RandomColorAndChild()
    {

        foreach (Transform g in transform)
        {
            g.gameObject.SetActive(true);
        }
        List<Color> listRandom = new List<Color>();

        foreach (var cl in listColor)
        {
            listRandom.Add(cl);
        }
        
        var color = listRandom[Random.Range(0, listRandom.Count)];
        listRandom.Remove(color);
        GetComponent<SpriteRenderer>().color = color;
        
        color = listRandom[Random.Range(0, listRandom.Count)];
        listRandom.Remove(color);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        
        color = listRandom[Random.Range(0, listRandom.Count)];
        listRandom.Remove(color);
        transform.GetChild(1).GetComponent<SpriteRenderer>().color = color;
        
        color = listRandom[Random.Range(0, listRandom.Count)];
        listRandom.Remove(color);
        transform.GetChild(2).GetComponent<SpriteRenderer>().color = color;

        int t = Random.Range(0, 6);
        
        if(t ==0) transform.GetChild(0).gameObject.SetActive(false);
        if(t ==1) transform.GetChild(1).gameObject.SetActive(false);
        if(t ==2) transform.GetChild(2).gameObject.SetActive(false);
        if (t == 3)
        {
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if (t == 4)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        if (t == 5)
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
