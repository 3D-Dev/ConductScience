using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class EmojiSpritesGen : MonoBehaviour {

    public TMP_SpriteAsset spriteAsset;
    public TMP_SpriteAsset extendedAsset;

    public TextAsset emoji_data;
    public Texture2D spriteSheet;

    private static string GetConvertedHex(string inputString, out int unicode, ref bool extended)
    {
        string[] converted = inputString.Split('-');
        int[] range = new int[converted.Length];

        for (int j = 0; j < converted.Length; j++)
        {
            range[j] = Convert.ToInt32(converted[j], 16);
            converted[j] = char.ConvertFromUtf32(range[j]);
        }

        unicode = range[0];
        extended = converted.Length > 1 ? true : false;

        return string.Join(string.Empty, converted);
    }

    public void Rebuild()
    {
        spriteAsset.spriteSheet = spriteSheet;
        extendedAsset.spriteSheet = spriteSheet;

        int width = spriteSheet.width;
        int height = spriteSheet.height;
        string inputString = emoji_data.text;

        List<TMP_Sprite> newSprites = new List<TMP_Sprite>();
        List<TMP_Sprite> extendedSprites = new List<TMP_Sprite>();

        using (StringReader reader = new StringReader(inputString))
        {
            string line = reader.ReadLine();
            while (line != null && line.Length > 1)
            {
                // We add each emoji to emojiRects
                string[] split = line.Split(' ');
                int x = (int)(float.Parse(split[1], System.Globalization.CultureInfo.InvariantCulture) * width);
                int y = (int)(float.Parse(split[2], System.Globalization.CultureInfo.InvariantCulture) * height);
                int w = (int)(float.Parse(split[3], System.Globalization.CultureInfo.InvariantCulture) * width);
                int h = (int)(float.Parse(split[4], System.Globalization.CultureInfo.InvariantCulture) * height);

                int unicode;
                bool extended = false;
                string string_utf32 = GetConvertedHex(split[0], out unicode, ref extended);

                TMP_Sprite sprite = new TMP_Sprite();
                sprite.unicode = unicode;
                sprite.name = split[0];//string_utf32;
                sprite.x = x;
                sprite.y = y;
                sprite.width = w;
                sprite.height = h;
                sprite.xOffset = 0;
                sprite.yOffset = h * 0.9f;
                sprite.xAdvance = w;
                sprite.pivot = new Vector2(0.5f, 0.5f);
                sprite.scale = 1f;

                if (extended)
                {
                    sprite.id = extendedSprites.Count;
                    extendedSprites.Add(sprite);
                }
                else
                {
                    sprite.id = newSprites.Count;
                    newSprites.Add(sprite);
                }

                line = reader.ReadLine();
            }
        }

        spriteAsset.spriteInfoList = newSprites;
        extendedAsset.spriteInfoList = extendedSprites;
    }
}
