using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignerPdfViewer
{
    class Program
    {
        // Complete the designerPdfViewer function below.
        static int designerPdfViewer(int[] heights, string word)
        {
            var characterGroups = word.GroupBy(character => character)
                .Select(group => new
                {
                    Character = group.Key,
                    Count = group.Count()
                });

            var characters = Enumerable.Range('a', 'z'-'a' + 1).
                     Select(c => (char)c);

            var charactersWithHeights = characters.Zip(
                heights,
                (character, height) => new
                {
                    Character = character,
                    Height = height
                });

            var characterGroupsWithHeights = characterGroups.Join(
                charactersWithHeights,
                characterGroup => characterGroup.Character,
                characterWithHeight => characterWithHeight.Character,
                (characterGroup, characterWithHeight) => new
                {
                    characterGroup.Character,
                    characterGroup.Count,
                    characterWithHeight.Height
                });

            var ordered = characterGroupsWithHeights
                .OrderByDescending(item => item.Height).First();

            var individualCharacterWidthInMillimeters = 1;
            var numberOfCharacters = word.Length;
            var areaRequiredForWordInMillimeterSquares = 
                numberOfCharacters * individualCharacterWidthInMillimeters * ordered.Height;

            return areaRequiredForWordInMillimeterSquares;
        }

        static int designerPdfViewerNonOptimized(int[] heights, string word)
        {
            var characterGroups = word.GroupBy(character => character)
                .Select(group => new
                {
                    Character = group.Key,
                    Count = group.Count()
                }).ToList();

            var characters = Enumerable.Range('a', 'z' - 'a' + 1).
                     Select(c => (char)c)
                     .ToList();

            var charactersWithHeights = characters.Zip(
                heights,
                (character, height) => new
                {
                    Character = character,
                    Height = height
                }).ToList();

            var characterGroupsWithHeights = characterGroups.Join(
                charactersWithHeights,
                characterGroup => characterGroup.Character,
                characterWithHeight => characterWithHeight.Character,
                (characterGroup, characterWithHeight) => new
                {
                    characterGroup.Character,
                    characterGroup.Count,
                    characterWithHeight.Height
                }).ToList();

            var ordered = characterGroupsWithHeights
                .OrderByDescending(item => item.Height).First();

            var individualCharacterWidthInMillimeters = 1;
            var numberOfCharacters = word.Length;
            var areaRequiredForWordInMillimeterSquares =
                numberOfCharacters * individualCharacterWidthInMillimeters * ordered.Height;

            return areaRequiredForWordInMillimeterSquares;
        }

        static void Main(string[] args)
        {
            var heights1 = new int[] {1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 1, 1, 5, 5, 1, 5, 2, 5, 5, 5, 5, 5, 5 };
            string word1 = "torn";

            int result1 = designerPdfViewer(heights1, word1); // 8

            var heights2 = new int[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            string word2 = "abc";

            int result2 = designerPdfViewer(heights2, word2); // 9

            var heights3 = new int[] { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 7 };
            string word3 = "zaba";

            int result3 = designerPdfViewer(heights3, word3); // 28
        }
    }
}
