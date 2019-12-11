using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class HeroesGenerator : MonoBehaviour
{

    public List<GameObject> Heroes;
    public float SpawningPeriod = 5.0f;

    private GameObject _heroesEmpty;
    private System.Random index;

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

        index = new System.Random();

        InvokeRepeating(nameof(generateNewRandomHero), 2.0f, SpawningPeriod);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void generateNewRandomHero()
    {
        try
        {
            GameObject hero = Instantiate(Heroes[index.Next(0, Heroes.Count)]) as GameObject;    //Instantiating a new random enemy
            hero.transform.parent = _heroesEmpty.transform;
            hero.transform.position = new Vector2(6.5f, UnityEngine.Random.Range(-1.5f, 1.2f));

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

            GameObject hero = Instantiate(_hero) as GameObject;    //Instantiating a new random enemy
            hero.transform.parent = _heroesEmpty.transform;
            hero.transform.position = new Vector2(6.5f, UnityEngine.Random.Range(-1.5f, 1.2f));

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
            case "Ashe":
                hero.AddComponent<Hero>().StartDefault(10, 2, 2, 1, true);
                break;
        }
    }
}
