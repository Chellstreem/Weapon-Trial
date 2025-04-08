using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ProjectileSwitchButton : MonoBehaviour
{
    [SerializeField] private Button switchButton;
    [SerializeField] private TextMeshProUGUI buttonText;

    private IProjectileSwitcher projectileSwitcher;

    [Inject]
    public void Construct(IProjectileSwitcher projectileSwitcher)
    {
        this.projectileSwitcher = projectileSwitcher;
    }

    private void Start()
    {
        switchButton.onClick.AddListener(OnSwitchClicked);
        UpdateButtonText();
    }   

    private void OnSwitchClicked()
    {
        projectileSwitcher.SwitchToNextProjectile();
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        buttonText.text = $"Переключиться на тип {projectileSwitcher.NextProjectileIndex + 1}";

    }

    private void OnDestroy()
    {
        switchButton.onClick.RemoveListener(OnSwitchClicked);
    }
}
