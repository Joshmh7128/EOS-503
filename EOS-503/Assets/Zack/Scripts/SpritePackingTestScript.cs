using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpritePackingTestScript : MonoBehaviour
{
    public Image m_DisplayImage;
    public Sprite m_Sprite1, m_Sprite2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CombineSpritesCoroutine());
        }
    }

    private IEnumerator CombineSpritesCoroutine()
    {
        Sprite[] spritesToCombine = new Sprite[2];

        for (int x = 0; x < spritesToCombine.Length; x++)
        {
            spritesToCombine[x] = (x % 2 == 0 ? m_Sprite1 : m_Sprite2);
        }

        Sprite finalSprite = null;
        yield return finalSprite = CombineSpriteArray(spritesToCombine);

        m_DisplayImage.sprite = finalSprite;
    }

	public Sprite CombineSpriteArray(Sprite[] spritesArray)
	{
		int spritesWidth = (int)spritesArray[0].rect.width;
		int spritesHeight = (int)spritesArray[0].rect.height;

		Texture2D combinedTexture = new Texture2D(spritesWidth/* * spritesArray.Length*/, spritesHeight);

		for (int x = 0; x < spritesArray.Length; x++)
		{
			combinedTexture.SetPixels(0/*x * spritesWidth*/, 0, spritesWidth, spritesHeight, spritesArray[x].texture.GetPixels());
		}
		combinedTexture.Apply();

		return Sprite.Create(combinedTexture, new Rect(0.0f, 0.0f, combinedTexture.width, combinedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
		}
}
