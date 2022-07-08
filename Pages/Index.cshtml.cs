using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSD601_Counting_Letters_in_sentence.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        //text field to hold words
        public string Text { get; set; }
        //list to hold letters
        public List<string> LetterCount { get; set; }

        public IndexModel()
        {
            LetterCount = new List<string>();
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            CountLetters(Text);
        }



        private void CountLetters(string text)
        {
           var Letters = new Dictionary<char, int>();

         //   var Letters = new SortedDictionary<char, int>();


            //if there is no text use the sentance 
            if (string.IsNullOrEmpty(text))
            {
                text = "if word is the word and bird is the word then word is the bird";
            }

            // for each letter in the word
            foreach (char letter in text)
            {
                //if there is no entry in the dictionary then add a new entry with 1 as the counter
                if (Letters.ContainsKey(letter) == false)
                {
                    Letters.Add(letter, 1);
                }
                else  // if its already in the dictionary increase the number (value) by one.
                {
                    //finds the key and adds 1 to the value, basically counts up
                    Letters[letter]++;
                }
            }
            //loop through the dictionary and get out the key/value pairs 

            foreach (KeyValuePair<char, int> pair in Letters)
            {
                LetterCount.Add(pair.Key + " --> " + pair.Value);
            }
        }



    }
}