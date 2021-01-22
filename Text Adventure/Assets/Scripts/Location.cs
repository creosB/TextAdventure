using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    public List<Item> items = new List<Item>();

	// Use this for initialization
	void OnStart ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public string GetItemsText()
    {
        if (items.Count ==0) return "";

        string result = "You see ";
        bool first = true;
        foreach(Item item in items)
        {
            if (item.itemEnabled)
            {
                if (!first) result += " and ";
                result += item.description;
                first =false;
            }
        }
        result += "\n";
        return result;
    }

    public string GetConnectionsText()
    {
        string result = "";
        foreach(Connection connection in connections)
        {
            if (connection.connectionEnabled)
                result += connection.description + "\n";
        }
        return result;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach(Item item in items)
        {
            if (item == itemToCheck && item.itemEnabled)
                return true;
        }
        return false;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach(Connection connection in connections)
        {
            if (connection.connectionName.ToLower() == connectionNoun.ToLower())
                return connection;
        }
        return null;
    }
}
