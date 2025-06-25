using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI healthText;
	[SerializeField] private Image healthBarImage;

	[SerializeField] private PlayerHealth healthSource;

	private IHealth playerHealth;

	private void Awake()
	{
		playerHealth = healthSource;
	}


	private void OnEnable()
	{
		playerHealth.OnHealthChanged += UpdateHealthUI;
	}

	private void OnDisable()
	{
		playerHealth.OnHealthChanged -= UpdateHealthUI;
	}

	private void Start()
	{
		UpdateHealthUI(playerHealth.CurrentHealth, playerHealth.MaxHealth);
	}


	private void UpdateHealthUI(float currentHealth, float maxHealth)
	{
		float fillAmount = currentHealth / maxHealth;
		healthBarImage.fillAmount = fillAmount;


		healthText.text = $"Health: {(int)currentHealth} / {(int)maxHealth}";
		Debug.Log($"Player Health Updated: {currentHealth}");
	}
}