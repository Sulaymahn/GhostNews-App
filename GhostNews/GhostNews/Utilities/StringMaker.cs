using GhostNews.Constants;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GhostNews.Utilities
{
    public static class StringMaker
    {
        static readonly Random rnd = new Random();
        static List<string> MaleNamePool { get; set; }
        static List<string> FemaleNamePool { get; set; }
        static List<string> ArticlePool { get; set; }
        static List<string> AdjectivePool { get; set; }
        static List<string> NounPool { get; set; }
        static List<string> VerbPool { get; set; }
        static List<string> PronounPool { get; set; }
        static List<string> QuestionPool { get; set; }
        static StringMaker()
        {
            InitializePools();
        }
        private static void InitializePools()
        {
            #region FemalePool
            FemaleNamePool = new List<string>();
            FemaleNamePool.Add("Sameerah");
            FemaleNamePool.Add("Ameerah");
            FemaleNamePool.Add("Hafsat");
            FemaleNamePool.Add("Hamidah");
            FemaleNamePool.Add("Halimah");
            FemaleNamePool.Add("Maryam");
            FemaleNamePool.Add("Saratu");
            FemaleNamePool.Add("Lubabatu");
            FemaleNamePool.Add("Victoria");
            FemaleNamePool.Add("Jummai");
            FemaleNamePool.Add("Faiza");
            FemaleNamePool.Add("Jamila");
            FemaleNamePool.Add("Farida");
            FemaleNamePool.Add("Fatima");
            FemaleNamePool.Add("Saliha");
            FemaleNamePool.Add("Zainab");
            FemaleNamePool.Add("Asmau");
            FemaleNamePool.Add("Gihan");
            FemaleNamePool.Add("Amal");
            FemaleNamePool.Add("Husna");
            FemaleNamePool.Add("Surayya");
            FemaleNamePool.Add("Sumayya");
            FemaleNamePool.Add("Safiyya");
            FemaleNamePool.Add("Humayrah");
            FemaleNamePool.Add("Hadiza");
            FemaleNamePool.Add("Khadija");
            #endregion

            #region MalePool
            MaleNamePool = new List<string>();
            MaleNamePool.Add("Ghaalib");
            MaleNamePool.Add("Khalid");
            MaleNamePool.Add("Usman");
            MaleNamePool.Add("Hamza");
            MaleNamePool.Add("Yusuf");
            MaleNamePool.Add("Musa");
            MaleNamePool.Add("Sulaymahn");
            MaleNamePool.Add("Khalifa");
            MaleNamePool.Add("Sultan");
            MaleNamePool.Add("Shareef");
            MaleNamePool.Add("Muhammad");
            MaleNamePool.Add("Aliyu");
            MaleNamePool.Add("Farouk");
            MaleNamePool.Add("Mahmud");
            MaleNamePool.Add("Sambo");
            MaleNamePool.Add("Jamilu");
            MaleNamePool.Add("Salihu");
            MaleNamePool.Add("Saminu");
            MaleNamePool.Add("Mukhtar");
            MaleNamePool.Add("Ishaq");
            MaleNamePool.Add("Dawud");
            MaleNamePool.Add("Ismael");
            #endregion

            #region ArticlePool
            ArticlePool = new List<string>();
            ArticlePool.Add("A");
            ArticlePool.Add("An");
            ArticlePool.Add("The");
            ArticlePool.Add("Some");
            #endregion

            #region PronounPool
            PronounPool = new List<string>();
            PronounPool.Add("Their");
            PronounPool.Add("Our");
            PronounPool.Add("Your");
            PronounPool.Add("His");
            PronounPool.Add("Her");
            PronounPool.Add("My");
            #endregion

            #region QuestionPool
            QuestionPool = new List<string>();
            QuestionPool.Add("When");
            QuestionPool.Add("Who");
            QuestionPool.Add("Why");
            QuestionPool.Add("How");
            QuestionPool.Add("Where");
            QuestionPool.Add("What");
            QuestionPool.Add("Which");
            #endregion

            #region VerbPool
            VerbPool = new List<string>();
            VerbPool.Add("To Kill");
            VerbPool.Add("To Take");
            VerbPool.Add("To Beat");
            VerbPool.Add("To Shake");
            VerbPool.Add("To Make");
            VerbPool.Add("To Wake");
            VerbPool.Add("To Return");
            VerbPool.Add("To Slap");
            VerbPool.Add("To Destroy");
            VerbPool.Add("To Elevate");
            VerbPool.Add("To Smile");
            VerbPool.Add("To Reject");
            VerbPool.Add("To Drink");
            VerbPool.Add("To Eat");
            VerbPool.Add("To Sleep");
            VerbPool.Add("To Fish out");
            VerbPool.Add("To Jump off");
            VerbPool.Add("To Call");
            VerbPool.Add("To Go");
            VerbPool.Add("To Frown");
            VerbPool.Add("To Dance");
            VerbPool.Add("To Fake");
            VerbPool.Add("To Stay");
            VerbPool.Add("To Clap");
            VerbPool.Add("To Start");
            VerbPool.Add("To Easen");
            VerbPool.Add("To Need");
            #endregion

            #region AdjectivePool
            AdjectivePool = new List<string>();
            AdjectivePool.Add("Adorable");
            AdjectivePool.Add("Adventurous");
            AdjectivePool.Add("Aggressive");
            AdjectivePool.Add("Angry");
            AdjectivePool.Add("Arrogant");
            AdjectivePool.Add("Beautiful");
            AdjectivePool.Add("Average");
            AdjectivePool.Add("Ashamed");
            AdjectivePool.Add("Awful");
            AdjectivePool.Add("Calm");
            AdjectivePool.Add("Careful");
            AdjectivePool.Add("Cheerful");
            AdjectivePool.Add("Clever");
            AdjectivePool.Add("Confused");
            AdjectivePool.Add("Cooperative");
            AdjectivePool.Add("Envious");
            AdjectivePool.Add("Lazy");
            AdjectivePool.Add("Proud");
            AdjectivePool.Add("Powerful");
            AdjectivePool.Add("Ugly");
            AdjectivePool.Add("Black");
            AdjectivePool.Add("Wrong");
            #endregion

            #region NounPool
            NounPool = new List<string>();
            NounPool.Add("Apple");
            NounPool.Add("Holiday");
            NounPool.Add("House");
            NounPool.Add("Actor");
            NounPool.Add("Hamburger");
            NounPool.Add("Wife");
            NounPool.Add("Carrot");
            NounPool.Add("Ferarri");
            NounPool.Add("Juice");
            NounPool.Add("Boy");
            NounPool.Add("Girl");
            NounPool.Add("Woman");
            NounPool.Add("Man");
            NounPool.Add("Wife");
            NounPool.Add("Husband");
            NounPool.Add("Money");
            #endregion
        }

        public static string GenerateID()
        {
            StringBuilder sb = new StringBuilder();
            int lenght = rnd.Next(8, 17);
            string characters = @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&/";

            for (int i = 0; i < lenght; i++)
            {
                sb.Append(characters[rnd.Next(0, characters.Length)]);
            }

            return sb.ToString();
        }
        public static string RandomMaleName()
        {
            return MaleNamePool[rnd.Next(0, MaleNamePool.Count)];
        }
        public static string RandomName()
        {
            if (rnd.Next(0, 2) == 0) return RandomFemaleName();
            else return RandomMaleName();
        }
        public static string RandomFemaleName()
        {
            return FemaleNamePool[rnd.Next(0, FemaleNamePool.Count)];
        }
        public static string MakeUsername(string firstname, string surnanme)
        {
            return $"{AddRandomAdjective()}{surnanme[0]}{firstname}";
        }
        public static Gender ParseName(string name)
        {
            if (FemaleNamePool.Contains(name)) return Gender.Female;
            else if (MaleNamePool.Contains(name)) return Gender.Male;
            else
            {
                var rnd = new Random();
                int result = rnd.Next(0, 3);
                switch (result)
                {
                    case 0:
                        return Gender.Other;
                    case 1:
                        return Gender.RatherNot;
                    case 2:
                    default:
                        return Gender.Unspecified;
                }
            }
        }

        private static string AddRandomArticle()
        {
            return ArticlePool[rnd.Next(0, ArticlePool.Count)];
        }
        private static string AddRandomVerb()
        {
            return VerbPool[rnd.Next(0, VerbPool.Count)];
        }
        private static string AddRandomQuestion()
        {
            return QuestionPool[rnd.Next(0, QuestionPool.Count)];
        }
        private static string AddRandomAdjective(string recent = null)
        {
            if(recent != null)
            {
                switch (recent.ToLower())
                {
                    case "a":
                        var consonantPool = AdjectivePool.Where((adjective) => !IsVowel(adjective[0])).ToList();
                        return consonantPool[rnd.Next(0, consonantPool.Count())];
                    case "an":
                        var vowelPool = AdjectivePool.Where((adjective) => IsVowel(adjective[0])).ToList();
                        return vowelPool[rnd.Next(0, vowelPool.Count())];
                    case "the":
                    default:
                        return AdjectivePool[rnd.Next(0, AdjectivePool.Count)];
                }
            }

            return AdjectivePool[rnd.Next(0, AdjectivePool.Count)];
        }
        private static bool IsVowel(char letter)
        {
            if (!char.IsLetter(letter)) return false;
            letter = char.ToLower(letter);

            switch (letter)
            {
                case 'a': return true;
                case 'e': return true;
                case 'i': return true;
                case 'o': return true;
                case 'u': return true;
                default: return false;
            }
        }
        private static string AddRandomNoun()
        {
            return NounPool[rnd.Next(0, NounPool.Count)];
        }
        public static string RandomTitle()
        {
            string question = AddRandomQuestion();
            string verb = AddRandomVerb();
            string article = AddRandomArticle();
            string adjective = AddRandomAdjective(article);
            string noun = AddRandomNoun();

            return string.Join(" ", question, verb, article, adjective, noun);
        }
    }
}
