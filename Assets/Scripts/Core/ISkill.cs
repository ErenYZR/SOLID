using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
	void Use();
	bool UsesState { get; }
}
