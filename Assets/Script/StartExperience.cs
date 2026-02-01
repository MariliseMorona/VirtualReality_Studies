using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartExperience : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [Tooltip("Câmera AR (deixe vazio para usar Main Camera)")]
    [SerializeField] private Camera arCamera;
    [Tooltip("Distância à frente da câmera onde os blocos aparecem")]
    [SerializeField] private float distanceInFrontOfCamera = 1.5f;
    [Tooltip("Altura acima do ponto de spawn para os blocos caírem com física")]
    [SerializeField] private float fallHeight = 2f;
    [Tooltip("Quantidade de blocos que caem")]
    [SerializeField] private int blockCount = 5;
    [Tooltip("Espaçamento entre os blocos ao spawnar")]
    [SerializeField] private float blockSpacing = 0.4f;

    public void OnStratExperiente(ARPlane plane)
    {
        if (cube == null)
        {
            Debug.LogError("StartExperience: O prefab do cubo não está atribuído no Inspector. Arraste o prefab Cube para o campo 'Cube'.");
            return;
        }

        Camera cam = arCamera != null ? arCamera : Camera.main;
        if (cam == null)
        {
            Debug.LogError("StartExperience: Nenhuma câmera encontrada. Atribua a câmera AR no Inspector.");
            return;
        }

        // Ponto central à frente da câmera; blocos spawnam acima para cair
        Vector3 basePosition = cam.transform.position + cam.transform.forward * distanceInFrontOfCamera;
        Vector3 right = cam.transform.right;
        Vector3 up = Vector3.up;

        for (int i = 0; i < blockCount; i++)
        {
            // Espalha os blocos em um grid e coloca acima do chão para caírem
            float offsetX = (i % 2 - 0.5f) * blockSpacing;
            float offsetZ = (i / 2 - 0.5f) * blockSpacing;
            Vector3 offset = right * offsetX + cam.transform.forward * offsetZ;
            Vector3 spawnPos = basePosition + offset + up * fallHeight;

            GameObject block = Instantiate(cube, spawnPos, Quaternion.identity);
            // Garante que o Rigidbody está com gravidade (cair)
            var rb = block.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }
        }
    }
}
