using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InitialSetup : MonoBehaviour
{
    [SerializeField] private float requiredArea;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private GameObject startExperienceUI;
    [SerializeField] private StartExperience startExperience;


    void OnEnable()
    {
        if (planeManager != null)
            planeManager.planesChanged += OnPlanesUpdated;
    }

    void OnDisable()
    {
        if (planeManager != null)
            planeManager.planesChanged -= OnPlanesUpdated;
    }

    public void OnClickStartExperience()
    {
        // Debug.Log("Iniciando a experience AR ...");
        // CloseModal();
        // OnStartExperienceAfterModalClosed();
        Debug.Log("Iniciando a experience AR ...");
        startExperienceUI.SetActive(false);
        planeManager.enabled = false;
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(false);
        }
        startExperience.OnStratExperiente(GetLargestPlane());
    }

    /// <summary>
    /// Chamado pelo GreetingModalClose após fechar a modal (botão na própria modal).
    /// </summary>
    public void OnStartExperienceAfterModalClosed()
    {
        if (planeManager != null)
            planeManager.enabled = false;
        if (startExperience != null)
            startExperience.OnStratExperiente(GetLargestPlane());
    }

    /// <summary>
    /// Fecha a modal (GreetingCTA) ao clicar em Let's go! Usa referência ou busca por nome.
    /// </summary>
    private void CloseModal()
    {
        if (startExperienceUI != null)
        {
            startExperienceUI.SetActive(false);
            return;
        }
        var modal = GameObject.Find("GreetingCTA");
        if (modal != null)
        {
            modal.SetActive(false);
            return;
        }
        var canvas = GameObject.Find("UI");
        if (canvas != null && canvas.transform.childCount > 0)
        {
            canvas.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void OnPlanesUpdated(ARPlanesChangedEventArgs args)
    {
        if (startExperienceUI == null) return;

        foreach (var plane in args.updated)
        {
            if (plane.extents.x * plane.extents.y >= requiredArea)
            {
                CenterModalOnScreen();
                startExperienceUI.SetActive(true);
                break;
            }
        }
    }

    /// <summary>
    /// Garante que a modal fique no centro da tela (em runtime).
    /// </summary>
    private void CenterModalOnScreen()
    {
        if (startExperienceUI == null) return;
        var rect = startExperienceUI.GetComponent<RectTransform>();
        if (rect == null) return;
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = Vector2.zero;
        rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0f);
    }

    
    private ARPlane GetLargestPlane()
    {
        ARPlane biggestPlane = null;
        float biggestArea = 0f;

        foreach (var plane in planeManager.trackables)
        {
            float area = plane.extents.x * plane.extents.y;
            if (area > biggestArea)
            {
                biggestArea = area;
                biggestPlane = plane;
            }
        }

        //  if (planeManager == null) return null;
        // {
        //         startExperienceUI.SetActive(true);
        // }

        return biggestPlane;
    }
}
