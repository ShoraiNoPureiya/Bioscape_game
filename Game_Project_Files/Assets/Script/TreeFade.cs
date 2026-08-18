using UnityEngine;

/// <summary>
/// Coloca esse script em cada árvore individual (as que estão em
/// arvores_individuais.csv). Faz a árvore ficar semi-transparente quando o
/// jogador entra na área de trás dela (fica "atrás" visualmente) e volta ao
/// normal quando ele sai.
///
/// CONFIGURAÇÃO DE CADA ÁRVORE (GameObject):
/// - SpriteRenderer com um dos arvore_variante_X.png
/// - Sorting: veja o script TreeYSort.cs (ordena por posição Y automaticamente,
///   pra árvore desenhar na frente/atrás do jogador certo)
/// - Um CircleCollider2D ou BoxCollider2D marcado como "Is Trigger" = true,
///   cobrindo a coroa/copa da árvore (a parte de cima, mais larga) — é essa
///   área que detecta o jogador "por trás"
/// - (separado) um CircleCollider2D pequeno SEM trigger, só no tronco (base),
///   pra bloquear o jogador de atravessar o tronco
///
/// O jogador precisa ter a tag "Player" (ou troque playerTag abaixo).
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class TreeFade : MonoBehaviour
{
    [Header("Config")]
    public string playerTag = "Player";
    [Range(0f, 1f)] public float alphaQuandoAtras = 0.45f;
    public float velocidadeFade = 8f;

    private SpriteRenderer sr;
    private float alphaAlvo = 1f;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sr == null) return;
        Color c = sr.color;
        float novoAlpha = Mathf.MoveTowards(c.a, alphaAlvo, velocidadeFade * Time.deltaTime);
        if (!Mathf.Approximately(c.a, novoAlpha))
        {
            c.a = novoAlpha;
            sr.color = c;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            alphaAlvo = alphaQuandoAtras;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
            alphaAlvo = 1f;
    }
}
