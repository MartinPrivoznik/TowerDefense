﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class HeroesGenerator : MonoBehaviour
{

    public List<GameObject> Heroes;
    public float SpawningPeriod;

    private GameObject _heroesEmpty;
    private System.Random index;
    private float _spawningPeriod;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var hero in Heroes) //Assign rigidbody at the begining so we dont have to do it manually
        {
            hero.AddComponent<Rigidbody2D>();
            hero.GetComponent<Rigidbody2D>().gravityScale = 0;
            hero.GetComponent<SpriteRenderer>().sortingOrder = 2;
            hero.tag = "Hero";
        }

        _heroesEmpty = GameObject.Find("Heroes");

        index = new System.Random();

        _spawningPeriod = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawningPeriod != SpawningPeriod)
        {
            CancelInvoke(nameof(generateNewRandomHero));
            _spawningPeriod = SpawningPeriod;
            if (_spawningPeriod != -1)
                InvokeRepeating(nameof(generateNewRandomHero), 1.5f, _spawningPeriod);
        }

        if (!IsInvoking(nameof(generateNewRandomHero)) && _spawningPeriod != -1f)
        {
            _spawningPeriod = SpawningPeriod;
            InvokeRepeating(nameof(generateNewRandomHero), 1.5f, _spawningPeriod);
        }
    }

    private void generateNewRandomHero()
    {
        try
        {
            GameObject hero = Instantiate(Heroes[index.Next(0, Heroes.Count)]) as GameObject;    //Instantiating a new random enemy
            hero.transform.parent = _heroesEmpty.transform;
            hero.transform.position = new Vector2(6.5f, UnityEngine.Random.Range(-1.3f, 1.5f));

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
            hero.transform.position = new Vector2(6.5f, UnityEngine.Random.Range(-1.3f, 1.5f));

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
                hero.AddComponent<Hero>().StartDefault(10, 2, 2, 2, false, 10);
                break;
            case "Ashe":
                hero.AddComponent<Hero>().StartDefault(10, 2, 3, 1, true, 10);
                break;
            case "Karthus":
                hero.AddComponent<Hero>().StartDefault(8, 5, 2, 1, true, 10);
                break;
            case "Taric":
                hero.AddComponent<Hero>().StartDefault(-1, 12, 3, 0.5f, false, 10);
                break;
            case "Teemo":
                hero.AddComponent<Hero>().StartDefault(6, 6, 6, 0.7f, true, 10); //Easter-EGG
                break;
            case "Cho":
                hero.AddComponent<Hero>().StartDefault(4, 8, 2, 1, false, 10);
                break;
            case "Alistar":
                hero.AddComponent<Hero>().StartDefault(4, 5, 1.4f, 1.3f, false, 10);
                break;
        }
    }
}
