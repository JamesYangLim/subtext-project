using System.Collections.Generic;

namespace SubtextProject
{
    public class Subtext
    {
        public string Text { get; set; }

        public string SubText { get; set; }

        public Subtext()
        {
            Text = "";
            SubText = "";
        }

        public Subtext(string text, string subtext)
        {
            Text = text;
            SubText = subtext;
        }

        public List<int> FindAllSubtextPositions()
        {
            var lower_text = Text.ToLower();
            var lower_subtext = SubText.ToLower();

            var positions = new List<int>();
            int startIndex = 0;
            while (true)
            {
                int index = lower_text.IndexOf(lower_subtext, startIndex);

                if (index == -1)
                {
                    break;
                }
                else 
                {
                    positions.Add(index);
                    startIndex = (index + lower_subtext.Length);
                }
            }
            return positions;
        }
    }
}
