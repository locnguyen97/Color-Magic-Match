using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectMoveByDrag : MonoBehaviour
{
    [SerializeField] List<GameObject> particleVFXs;
    [SerializeField] private List<Color> listColor;

    private Vector3 startPos;
    private Transform target;

    private void Start()
    {
        var color = listColor[Random.Range(0, listColor.Count)];
        listColor.Remove(color);
        GetComponent<SpriteRenderer>().color = color;
        
        color = listColor[Random.Range(0, listColor.Count)];
        listColor.Remove(color);
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
        
        color = listColor[Random.Range(0, listColor.Count)];
        listColor.Remove(color);
        transform.GetChild(1).GetComponent<SpriteRenderer>().color = color;
        
        color = listColor[Random.Range(0, listColor.Count)];
        listColor.Remove(color);
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

    private void OnEnable()
    {
        startPos = transform.position;
    }

    public void PickUp()
    {
        //transform.rotation = new Quaternion(0,0,0,0);
    }

    public void CheckOnMouseUp()
    {
        //transform.position = startPos;
        if (target)
        {
            GameObject explosion = Instantiate(particleVFXs[Random.Range(0,particleVFXs.Count)], transform.position, transform.rotation);
            Destroy(explosion, .75f);
            target.GetChild(0).GetComponent<RandomChild>().RandomColorAndChild();
            transform.position = target.position;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].RemoveObject(gameObject);
            Destroy(gameObject);
            GameManager.Instance.CheckLevelUp();
        }
        else
        {
            transform.position = startPos;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "target")
        {
            target = collision.transform;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "target")
        {
            target = null;
        }
    }
}
