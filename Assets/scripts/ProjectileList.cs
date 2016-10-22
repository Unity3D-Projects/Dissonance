﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic; //for List!

public class Projectile
{
    public Projectile(int type, int lane)
    {
        m_type = type;
        m_lane = lane;

        switch(type)
        {
            case 1:
                m_height = 1;
                m_velocity = 1;
                break;
            case 2:
                m_height = ApplicationModel.height - 1;
                m_velocity = -1;
                break;
            default:
                Debug.Log("Error, not correct type for projectile");
                break;       
        }
    }

    public int m_velocity;
    public int m_type;
    public int m_lane;
    public int m_height;
}

public class ProjectileList : MonoBehaviour {
    
    List<Projectile> projectileList = new List<Projectile>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void move () {
        for (int i = 0; i < projectileList.Count; i++)
        {
            projectileList[i].m_height += projectileList[i].m_velocity;

            //have some effect if player is there, and delete
            if (projectileList[i].m_height <=0 || projectileList[i].m_height >= 8)
            {
                projectileList.RemoveAt(i);
                i--; //upper elements shift down into empty spot, check index again
            }
        }
	}
}
