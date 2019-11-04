using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class HeroesGenerator : MonoBehaviour
{

    public List<GameObject> Heroes;

    private GameObject _heroesEmpty;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var hero in Heroes) //Assign rigidbody at the begining so we dont have to do it manually
        {
            hero.AddComponent<Rigidbody2D>();
            hero.GetComponent<Rigidbody2D>().gravityScale = 0;
            hero.GetComponent<SpriteRenderer>().sortingOrder = 1;
            hero.tag = "Hero";
        }

        _heroesEmpty = GameObject.Find("Heroes");
        generateNewRandomHero();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void generateNewRandomHero()
    {
        try
        {
            System.Random index = new System.Random();
            System.Random y_Position = new System.Random();
            GameObject hero = Instantiate(Heroes[index.Next(Heroes.Count - 1)]) as GameObject;    //Instantiating a new random enemy
            hero.transform.parent = _heroesEmpty.transform;
            hero.transform.position = new Vector2(6.5f, float.Parse(y_Position.Next(-15, 12).ToString()) / 10);

            heroInit(hero);

        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    private void generateNewSpecificHero(GameObject _hero)
    {
        try
        {
            System.Random y_Position = new System.Random();
            GameObject hero = Instantiate(_hero) as GameObject;    //Instantiating a new random enemy
            hero.transform.parent = _heroesEmpty.transform;
            hero.transform.position = new Vector2(6.5f, float.Parse(y_Position.Next(-15, 12).ToString()) / 10);

            heroInit(hero);
        }

        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    private void heroInit(GameObject hero)
    {
        //Split name by uppercase so we can just access hero name
        string[] split = Regex.Split(hero.name, @"(?<!^)(?=[A-Z])");
        name = split[0];

        switch (name)
        {
            case "Nocturne":
                hero.AddComponent<Hero>().StartDefault(10, 2, 2, 2, false);
                break;
        }
    }
}
