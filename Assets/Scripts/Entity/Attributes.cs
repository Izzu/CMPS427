﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Container for entity attributes. Contains accessor methods for each attribute.
/// If an entity needs more attributes than what this class provides, this class should be extended to include
/// the extra attributes.
/// </summary>
public class Attributes 
{
    // Since different objects can have different limits, these need to be set on a per object basis.
    private float attackSpeedMin, attackSpeedMax;
    private float moveSpeedMin, moveSpeedMax;
    public enum Stats
    {
        HEALTH,
        RESOURCE,
        POWER,
        DEFENSE,
        ATTACK_SPEED,
        MOVEMENT_SPEED,
        MIN_DAMAGE,
        MAX_DAMAGE

    };

    private Dictionary<Stats, float> statList;

    /// <summary>
    /// Adds the required keys to the dictionary.
    /// </summary>
    public Attributes()
    {
        statList = new Dictionary<Stats, float>();
		// Default values for clamps, to prevent errors.
		attackSpeedMin = moveSpeedMin = 0.5f;
		attackSpeedMax = moveSpeedMax = 2.0f;
        foreach (Stats stat in Enum.GetValues(typeof(Stats)))
            statList.Add(stat, 0);
    }

    #region Health
    public float Health
    {
        get
        {
            try
            {
                return statList[Stats.HEALTH];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.HEALTH, 0);
                return 0;
            }
        }
        set 
        {
            try
            {
                statList[Stats.HEALTH] = value;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.HEALTH, value);
            }
        }
    }
    #endregion

    #region Resource
    public float Resource
    {
        get 
        {
            try
            {
                return statList[Stats.RESOURCE];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.RESOURCE, 0);
                return 0;
            }
        }
        set 
        {
            try
            {
                statList[Stats.RESOURCE] = value;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.RESOURCE, value);
            }
        }
    }
    #endregion

    #region Power
    public float Power
    {
        get 
        {
            try
            {
                return statList[Stats.POWER];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.POWER, 0);
                return 0;
            }
        }
        set 
        {
            try
            {
                statList[Stats.POWER] = value;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.POWER, value);
            }
        }
    }
    #endregion

    #region Defense
    public float Defense
    {
        get 
        {
            try
            {
                return statList[Stats.DEFENSE];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.DEFENSE, 0);
                return 0;
            }
        }
        set 
        {
            try
            {
                statList[Stats.DEFENSE] = value;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.DEFENSE, value);
            }
        }
    }
    #endregion

    #region Attack Speed
    public float AttackSpeed
    {
        get 
        {
            try
            {
                return statList[Stats.ATTACK_SPEED];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.ATTACK_SPEED, 0);
                return 0;
            }
        }
        set 
        {
			float newValue = Mathf.Clamp (value, attackSpeedMin, attackSpeedMax);
            try
            {
				statList[Stats.ATTACK_SPEED] = newValue;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.ATTACK_SPEED, newValue);
            }
        }
    }
    #endregion

    #region Movement Speed
    public float MovementSpeed
    {
        get 
        {
            try
            {
                return statList[Stats.MOVEMENT_SPEED];
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.MOVEMENT_SPEED, 0);
                return 0;
            }
        }
        set 
        {
			float newValue = Mathf.Clamp (value, moveSpeedMin, moveSpeedMax);
            try
            {
                statList[Stats.MOVEMENT_SPEED] = newValue;
            }
            catch (Exception e)
            {
                Debug.Log(e);
                AddKey(Stats.MOVEMENT_SPEED, newValue);
            }
        }
    }

    #endregion


    #region Min Damage
    public float MinDamage
    {
        get { return statList[Stats.MIN_DAMAGE]; }
        set { statList[Stats.MIN_DAMAGE] = value; }
    }

    #endregion


    #region Max Damage
    public float MaxDamage
    {
        get { return statList[Stats.MAX_DAMAGE]; }
        set { statList[Stats.MAX_DAMAGE] = value; }
    }

    #endregion



    #region Arithmetic Operations
    /// <summary>
    /// Adds attributes to the current attribute object.
    /// </summary>
    /// <param name="other">Object whose attributes will be added to the caller.</param>
    public void Add(Attributes other)
    {
        Health += other.Health;
        Resource += other.Resource;
        Power += other.Power;
        Defense += other.Defense;
        AttackSpeed += other.AttackSpeed;
        MovementSpeed += other.MovementSpeed;
        MinDamage += other.MinDamage;
        MaxDamage += other.MaxDamage;
    }

    /// <summary>
    /// Subtracts attributes to the current attribute object.
    /// </summary>
    /// <param name="other">Object whose attributes will be subtracted from the caller.</param>
    public void Subtract(Attributes other)
    {
        Health -= other.Health;
        Resource -= other.Resource;
        Power -= other.Power;
        Defense -= other.Defense;
        AttackSpeed -= other.AttackSpeed;
        MovementSpeed -= other.MovementSpeed;
        MinDamage -= other.MinDamage;
        MaxDamage -= other.MaxDamage;
    }
    #endregion

    #region Setters for Min/Max caps.
    public void SetAttackSpeedClamps(float min, float max)
    {
        attackSpeedMin = min;
        attackSpeedMax = max;
    }

    public void SetMovementSpeedClamps(float min, float max)
    {
        moveSpeedMin = min;
        moveSpeedMax = max;
    }
    #endregion

    /// <summary>
    /// Adds a key to the stat list.
    /// </summary>
    /// <param name="stat">Key</param>
    /// <param name="value">Default value.</param>
    private void AddKey(Stats stat, float value)
    {
        Debug.Log("Adding key for " + stat.ToString());
        statList.Add(stat, value);
    }
}
