using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : ISkill
{
	public bool UsesState => false;

	public void Use()
	{
		Debug.Log("Fireball skill used!");
	}
}

