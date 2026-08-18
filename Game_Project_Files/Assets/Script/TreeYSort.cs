using UnityEngine;

/// <summary>
/// Coloca junto com o TreeFade em cada árvore (e também no Player, se ele
/// ainda não tiver algo parecido). Ajusta o "Order in Layer" do SpriteRenderer
/// automaticamente com base na posição Y — quem está mais embaixo na tela
/// desenha na frente.
///
/// Sem isso, a árvore sempre desenha na frente (ou sempre atrás) do jogador,
/// independente da posição, e o efeito de transparência fica estranho.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class TreeYSort : MonoBehaviour
{
    [Tooltip("Quanto maior, mais preciso o ordenamento — 100 já é suficiente pra a maioria dos casos")]
    public int precisao = 100;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        sr.sortingOrder = -(int)(transform.position.y * precisao);
    }
}
