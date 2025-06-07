using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUser : MonoBehaviour
{
    ISkill[] skillSlots = new ISkill[2];
	private IInputReader input;
	[SerializeField] private DashSkillData dashData;
	private Rigidbody2D rb;
	private Player player;
	private void Awake()
	{
		input = GetComponent<IInputReader>();
		rb = GetComponent<Rigidbody2D>();
		player = GetComponent<Player>();
	}

	void Start()
    {
        skillSlots[0] = new DashSkill(rb,dashData,transform,player);
		skillSlots[1] = new FireballSkill();
	}

    void Update()
    {
        UseSkill();
	}

	public void SetSkill(int index, ISkill skill)
	{
		if (index >= 0 && index < skillSlots.Length)
		{
			skillSlots[index] = skill;
		}
	}

	public void UseSkill(int index)
	{
		if (index >= 0 && index < skillSlots.Length && skillSlots[index] != null)
		{
			skillSlots[index].Use();
		}
	}

	private void UseSkill()
    {
		if (input.Skill1Triggered()) skillSlots[0]?.Use();

		if (input.Skill2Triggered()) skillSlots[1]?.Use();
	}

}
