using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombineCodePractice
{
    /// <summary>
    /// A Question that holds the prompt, Answer and SeenInGame value
    /// </summary>
    internal class Question
    {
        internal string Prompt { get; }
        internal string Answer { get; }
        //Unused, was meant for some kind of 'Purist' mode, but I'd be damned if I cared enough.
        internal bool SeenInGame { get; }
        internal Question(string prompt, string answer, bool seenInGame = false)
        {
            Prompt = prompt;
            Answer = answer;
            SeenInGame = seenInGame;
        }
    }
}
