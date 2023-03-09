﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TagSceneHandler : MonoBehaviour
{
    private static List<TagArea> tagAreaList = new List<TagArea>();
    private List<GameObject> tempTagAreaList = new List<GameObject>();

    /**
    * Change the current scene to the main menu scene
    **/
    public void SwitchToMenuScene()
    {
        foreach (GameObject go in tempTagAreaList)
        {
            tagAreaList.Add(new TagArea(go.tag, go.transform.position, go.transform.localScale, go.transform.localRotation));
        }

        SceneManager.LoadScene("MenuAndVisualizer");
    }

    /**
    * Create a tag area prefab in the scene
    *
    * @param tag : the associated tag of the tag area 
    **/
    public void GenerateTagArea(string tag)
    {
        GameObject tagAreaPrefab = Instantiate(Resources.Load("TagAreaPrefab")) as GameObject;
        tagAreaPrefab.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = tag;
        tagAreaPrefab.tag = tag;

        tempTagAreaList.Add(tagAreaPrefab);
    }

    /**
    * Return the list of placed tag areas in the scene
    *
    * @return a list of tag areas
    **/
    static public List<TagArea> GetTagAreaList()
    {
        return tagAreaList;
    }
}