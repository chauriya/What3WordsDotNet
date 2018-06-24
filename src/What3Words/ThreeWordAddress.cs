namespace What3Words
{
    public class ThreeWordAddress
    {
        public string FirstWord { get; private set; }
        public string SecondWord { get; private set; }
        public string ThirdWord { get; private set; }

        public ThreeWordAddress(string firstWord, string secondWord, string thirdWord)
        {
            FirstWord = firstWord;
            SecondWord = secondWord;
            ThirdWord = thirdWord;
        }

        public override string ToString()
        {
            return $"{FirstWord}.{SecondWord}.{ThirdWord}";
        }
    }
}
